using System;
using System.Collections.Generic;
using System.Linq;
using ModeloDominio;

namespace LogicaNegocio
{
    public class LNPSala : LNPersonal, ILNPSala
    {
        public LNPSala(PersonalSala personal) : base(personal)
        {
        }

        public int AltaPrestamo(Prestamo prestamo)
        {
            if (prestamo == null)
                throw new ArgumentNullException(nameof(prestamo), "El préstamo no puede ser nulo");

            if (string.IsNullOrWhiteSpace(prestamo.DniUsuario))
                throw new ArgumentException("El préstamo debe tener un usuario asociado");

            Usuario usuario = GetUsuario(prestamo.DniUsuario);
            if (usuario == null || !usuario.DadoAlta)
                throw new InvalidOperationException($"No existe un usuario activo con DNI {prestamo.DniUsuario}");

            if (prestamo.Ejemplares == null || prestamo.Ejemplares.Count == 0)
                throw new ArgumentException("El préstamo debe tener al menos un ejemplar");

            foreach (var ejemplar in prestamo.Ejemplares.Keys)
            {
                Ejemplar ej = Persistencia.Persistencia.GetEjemplar(ejemplar.Codigo);
                if (ej == null || !ej.Activo)
                    throw new InvalidOperationException($"El ejemplar {ejemplar.Codigo} no está disponible");

                if (!HayEjemplaresDisponibles(ejemplar.IsbnDocumento))
                    throw new InvalidOperationException($"No hay ejemplares disponibles del documento {ejemplar.IsbnDocumento}");
            }

            prestamo.DniPersonal = this.personal.Dni;
            return Persistencia.Persistencia.AltaPrestamo(prestamo);
        }

        public Prestamo GetPrestamo(int idPrestamo)
        {
            if (idPrestamo <= 0)
                throw new ArgumentException("El ID del préstamo debe ser mayor que cero");

            return Persistencia.Persistencia.GetPrestamoPorId(idPrestamo);
        }

        public Usuario GetUsuarioPrestamo(int idPrestamo)
        {
            Prestamo prestamo = GetPrestamo(idPrestamo);
            if (prestamo == null)
                throw new InvalidOperationException($"No existe un préstamo con ID {idPrestamo}");

            return GetUsuario(prestamo.DniUsuario);
        }

        public EstadoPrestamo GetEstadoPrestamo(int idPrestamo)
        {
            Prestamo prestamo = GetPrestamo(idPrestamo);
            if (prestamo == null)
                throw new InvalidOperationException($"No existe un préstamo con ID {idPrestamo}");

            return prestamo.Estado;
        }

        public List<Ejemplar> GetEjemplaresNoDevueltos(int idPrestamo)
        {
            Prestamo prestamo = GetPrestamo(idPrestamo);
            if (prestamo == null)
                throw new InvalidOperationException($"No existe un préstamo con ID {idPrestamo}");

            List<Ejemplar> noDevueltos = new List<Ejemplar>();
            foreach (var ejemplar in prestamo.Ejemplares)
            {
                if (ejemplar.Value == null)
                {
                    noDevueltos.Add(ejemplar.Key);
                }
            }

            return noDevueltos;
        }

        public List<Prestamo> GetPrestamosPorDocumento(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            List<Prestamo> todosPrestamos = Persistencia.Persistencia.GetTodosPrestamos();
            List<Prestamo> prestamosDocumento = new List<Prestamo>();

            foreach (Prestamo prestamo in todosPrestamos)
            {
                foreach (var ejemplar in prestamo.Ejemplares.Keys)
                {
                    if (ejemplar.IsbnDocumento == isbn)
                    {
                        prestamosDocumento.Add(prestamo);
                        break;
                    }
                }
            }

            return prestamosDocumento;
        }

        public List<Prestamo> GetPrestamosPorUsuario(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI no puede estar vacío");

            return Persistencia.Persistencia.GetPrestamosPorUsuario(dni);
        }

        public void DevolverEjemplar(int idPrestamo, string codigoEjemplar)
        {
            if (idPrestamo <= 0)
                throw new ArgumentException("El ID del préstamo debe ser mayor que cero");
            
            if (string.IsNullOrWhiteSpace(codigoEjemplar))
                throw new ArgumentException("El código del ejemplar no puede estar vacío");

            Prestamo prestamo = GetPrestamo(idPrestamo);
            if (prestamo == null)
                throw new InvalidOperationException($"No existe un préstamo con ID {idPrestamo}");

            Ejemplar ejemplarADevolver = null;
            foreach (var ejemplar in prestamo.Ejemplares.Keys)
            {
                if (ejemplar.Codigo == codigoEjemplar)
                {
                    ejemplarADevolver = ejemplar;
                    break;
                }
            }

            if (ejemplarADevolver == null)
                throw new InvalidOperationException($"El ejemplar {codigoEjemplar} no pertenece al préstamo {idPrestamo}");

            if (prestamo.Ejemplares[ejemplarADevolver] != null)
                throw new InvalidOperationException($"El ejemplar {codigoEjemplar} ya ha sido devuelto");

            prestamo.Ejemplares[ejemplarADevolver] = DateTime.Now;

            bool todosDevueltos = true;
            foreach (var fecha in prestamo.Ejemplares.Values)
            {
                if (fecha == null)
                {
                    todosDevueltos = false;
                    break;
                }
            }

            if (todosDevueltos)
            {
                prestamo.Estado = EstadoPrestamo.Finalizado;
                prestamo.FechaDevolucion = DateTime.Now;
            }

            Persistencia.Persistencia.UpdatePrestamo(prestamo);
        }

        public List<Prestamo> GetPrestamosFueraDePlazo()
        {
            List<Prestamo> todosPrestamos = Persistencia.Persistencia.GetTodosPrestamos();
            List<Prestamo> fueraDePlazo = new List<Prestamo>();
            DateTime fechaActual = DateTime.Now;

            foreach (Prestamo prestamo in todosPrestamos)
            {
                if (prestamo.Estado == EstadoPrestamo.EnProceso)
                {
                    foreach (var ejemplar in prestamo.Ejemplares)
                    {
                        if (ejemplar.Value == null)
                        {
                            Documento documento = Persistencia.Persistencia.GetDocumentoPorIsbn(ejemplar.Key.IsbnDocumento);
                            DateTime fechaLimite = prestamo.FechaPrestamo.AddDays(documento.DiasPrestamoPermitidos());
                            
                            if (fechaActual > fechaLimite)
                            {
                                fueraDePlazo.Add(prestamo);
                                break;
                            }
                        }
                    }
                }
            }

            return fueraDePlazo;
        }

        public bool HayEjemplaresDisponibles(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);
            if (ejemplares == null || ejemplares.Count == 0)
                return false;

            List<Prestamo> prestamos = Persistencia.Persistencia.GetTodosPrestamos();

            foreach (Ejemplar ejemplar in ejemplares)
            {
                if (!ejemplar.Activo)
                    continue;

                bool prestado = false;
                foreach (Prestamo prestamo in prestamos)
                {
                    if (prestamo.Estado == EstadoPrestamo.EnProceso)
                    {
                        foreach (var ej in prestamo.Ejemplares)
                        {
                            if (ej.Key.Codigo == ejemplar.Codigo && ej.Value == null)
                            {
                                prestado = true;
                                break;
                            }
                        }
                    }
                    if (prestado) break;
                }

                if (!prestado)
                    return true;
            }

            return false;
        }

        public DateTime? GetFechaDisponibilidadDocumento(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            if (HayEjemplaresDisponibles(isbn))
                return DateTime.Now;

            List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);
            if (ejemplares == null || ejemplares.Count == 0)
                return null;

            Documento documento = Persistencia.Persistencia.GetDocumentoPorIsbn(isbn);
            if (documento == null)
                return null;

            List<Prestamo> prestamos = Persistencia.Persistencia.GetTodosPrestamos();
            DateTime? fechaMasCercana = null;

            foreach (Prestamo prestamo in prestamos)
            {
                if (prestamo.Estado == EstadoPrestamo.EnProceso)
                {
                    foreach (var ej in prestamo.Ejemplares)
                    {
                        if (ej.Key.IsbnDocumento == isbn && ej.Value == null)
                        {
                            DateTime fechaDevolucionEsperada = prestamo.FechaPrestamo.AddDays(documento.DiasPrestamoPermitidos());
                            
                            if (fechaMasCercana == null || fechaDevolucionEsperada < fechaMasCercana)
                            {
                                fechaMasCercana = fechaDevolucionEsperada;
                            }
                        }
                    }
                }
            }

            return fechaMasCercana;
        }
    }
}
