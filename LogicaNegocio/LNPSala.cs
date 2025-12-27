using System;
using System.Collections.Generic;
using System.Linq;
using ModeloDominio;

namespace LogicaNegocio
{
    public class LNPSala : LNPersonal, ILNPSala
    {
        //PRE: personal no nulo y debe ser de tipo personalSala
        //POST: Se inicializa la clase llamando al constructor base. Si es null, se lanza excepción desde la clase base
        public LNPSala(Personal personal) : base(personal)
        {
        }

        //PRE:
        //POST:
        public int AltaPrestamo(Prestamo prestamo)
        {
            return Persistencia.Persistencia.AltaPrestamo(prestamo);
        }

        //PRE:
        //POST: 
        public void DevolverEjemplar(int idPrestamo, int codigoEjemplar)
        {
            if (Persistencia.Persistencia.GetPrestamoEjemplar(idPrestamo, codigoEjemplar) == null)
            {
                throw new Exception("El ejemplar no pertenece a este préstamo");
            }

            Persistencia.Persistencia.UpdatePrestamoEjemplar(idPrestamo, codigoEjemplar, DateTime.Now);

            List<Ejemplar> ejemplaresNoDevueltos = GetEjemplaresNoDevueltos(idPrestamo);

            if (ejemplaresNoDevueltos.Count == 0)
            {
                Prestamo p = Persistencia.Persistencia.GetPrestamoPorId(idPrestamo);
                Persistencia.Persistencia.UpdatePrestamo(new Prestamo(
                    p.Id, p.FechaPrestamo, p.FechaDevolucion,
                    EstadoPrestamo.finalizado, p.DniPersonal, p.DniUsuario));
            }
        }


        /*
        public List<Ejemplar> GetEjemplaresNoDevueltos(int idPrestamo)
        {
            /*
             *  no se como sacarlo sin que sea un metodo de persistencia
             * 
             * List<PrestamoEjemplar> ejemplaresDePrestamo = Persistencia.Persistencia.GetEjemplaresDePrestamo(idPrestamo);
            List<Ejemplar> ejemplaresNoDevueltos = new List<Ejemplar>();

            foreach (Ejemplar e in ejemplaresDePrestamo)
            {
                if (e.)
            }

            return Persistencia.Persistencia.GetEjemplaresNoDevueltosDePrestamo(idPrestamo); // Si el idPrestamo no existe, qué devuelve? Lista vacia o null?
            

            return null;
        }*/

        /*
PRE: idPrestamo > 0
POST: devuelve lista con los ejemplares del préstamo que aún no han sido devueltos (puede estar vacía)
*/
        public List<Ejemplar> GetEjemplaresNoDevueltos(int idPrestamo)
        {
            // Obtener todos los ejemplares del préstamo
            List<Ejemplar> todosEjemplares = Persistencia.Persistencia.GetEjemplaresDePrestamo(idPrestamo);
            List<Ejemplar> ejemplaresNoDevueltos = new List<Ejemplar>();

            foreach (Ejemplar ej in todosEjemplares)
            {
                // Obtener la información del préstamo-ejemplar
                var prestamoEjemplar = Persistencia.Persistencia.GetPrestamoEjemplar(idPrestamo, ej.Codigo);

                // Si no se ha devuelto (FechaDevolucion == DateTime.MinValue)
                if (prestamoEjemplar != null && prestamoEjemplar.FechaDevolucion == DateTime.MinValue)
                {
                    ejemplaresNoDevueltos.Add(ej);
                }
            }

            return ejemplaresNoDevueltos;
        }

        //PRE:
        //POST:
        public EstadoPrestamo? GetEstadoPrestamo(int idPrestamo)
        {
            Prestamo prestamo = Persistencia.Persistencia.GetPrestamoPorId(idPrestamo);
            if (prestamo == null)
            {
                return null; // esto o lanzamos excepciones?
                //throw new Exception("El préstamo no existe");
            }
            return prestamo.Estado;
        }

        //PRE:
        //POST:
        public Prestamo GetPrestamo(int idPrestamo)
        {
            return Persistencia.Persistencia.GetPrestamoPorId(idPrestamo);
        }

        //PRE:
        //POST:
        public List<Prestamo> GetPrestamosFueraDePlazo()
        {
            List<Prestamo> prestamos = Persistencia.Persistencia.GetPrestamos();
            List<Prestamo> prestamosFueraDePlazo = new List<Prestamo>();

            foreach (Prestamo prestamo in prestamos)
            {
                if (prestamo.Caducado())
                {
                    prestamosFueraDePlazo.Add(prestamo);
                }
            }

            return prestamosFueraDePlazo;
        }

        //PRE:
        //POST:
        public List<Prestamo> GetPrestamosPorDocumento(string isbn)
        {
            List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);

            List<Prestamo> prestamos = new List<Prestamo>();
            HashSet<int> idsPrestamosAgregados = new HashSet<int>();

            foreach (Ejemplar ejemplar in ejemplares)
            {
                List<Prestamo> prestamosDelEjemplar =
                    Persistencia.Persistencia.GetPrestamosPorEjemplar(ejemplar.Codigo);

                foreach (Prestamo p in prestamosDelEjemplar)
                {
                    if (!prestamos.Contains(p))
                    {
                        prestamos.Add(p);
                    }
                }
            }
            return prestamos;
        }

        //PRE:
        //POST:
        public Usuario GetUsuarioPrestamo(int idPrestamo)
        {
            Prestamo prestamo = Persistencia.Persistencia.GetPrestamoPorId(idPrestamo);
            if (prestamo == null)
            {
                return null;
            }
            return Persistencia.Persistencia.GetUsuario(prestamo.DniUsuario);
        }

        //PRE:
        //POST:
        public List<Prestamo> GetTodosPrestamos()
        {
            return Persistencia.Persistencia.GetPrestamos();
        }

        //PRE:
        //POST:
        public List<Ejemplar> GetEjemplaresDePrestamo(int id)
        {
            return Persistencia.Persistencia.GetEjemplaresDePrestamo(id);
        }

        //PRE:
        //POST: Si no existe, null; si existe, devuelve el objeto AudLibro o LiPapel

        public Documento GetDocumento(string isbn)
        {
            return Persistencia.Persistencia.GetDocumento(isbn);
        }

        // AÑADIDO 

        /*
PRE: ninguna
POST: devuelve lista con todos los ejemplares activos del sistema (puede estar vacía)
*/
        public List<Ejemplar> GetEjemplaresActivos()
        {
            return Persistencia.Persistencia.GetEjemplares()
                .Where(e => e.Activo)
                .ToList();
        }

        /*
        PRE: codigosExcluidos puede ser null
        POST: devuelve lista con ejemplares activos excluyendo los códigos especificados (puede estar vacía)
        */
        public List<Ejemplar> GetEjemplaresDisponibles(List<int> codigosExcluidos)
        {
            List<Ejemplar> todosActivos = GetEjemplaresActivos();

            if (codigosExcluidos == null || codigosExcluidos.Count == 0)
                return todosActivos;

            return todosActivos.Where(e => !codigosExcluidos.Contains(e.Codigo)).ToList();
        }

        /*
        PRE: prestamo != null && ejemplares != null && ejemplares.Count > 0
        POST: crea el préstamo en la BD, añade todos los ejemplares con estado no devuelto,
              devuelve el ID del préstamo creado. Si falla, lanza excepción
        */
        public int CrearPrestamoCompleto(Prestamo prestamo, List<int> codigosEjemplares)
        {
            if (prestamo == null)
                throw new ArgumentNullException(nameof(prestamo));

            if (codigosEjemplares == null || codigosEjemplares.Count == 0)
                throw new ArgumentException("Debe incluir al menos un ejemplar en el préstamo");

            // Validar que el usuario existe y está activo
            Usuario usuario = GetUsuario(prestamo.DniUsuario);
            if (usuario == null)
                throw new InvalidOperationException($"No existe un usuario con DNI {prestamo.DniUsuario}");

            if (!usuario.DadoAlta)
                throw new InvalidOperationException("El usuario está dado de baja");

            // Crear el préstamo
            int idPrestamo = AltaPrestamo(prestamo);

            // Añadir cada ejemplar al préstamo
            try
            {
                foreach (int codigoEjemplar in codigosEjemplares)
                {
                    Persistencia.Persistencia.AltaPrestamoEjemplar(
                        idPrestamo,
                        codigoEjemplar,
                        DateTime.MinValue // No devuelto
                    );
                }
            }
            catch (Exception ex)
            {
                // Si falla al añadir ejemplares, eliminar el préstamo creado
                Prestamo prestamoCreado = GetPrestamo(idPrestamo);
                if (prestamoCreado != null)
                {
                    Persistencia.Persistencia.BajaPrestamo(prestamoCreado);
                }
                throw new InvalidOperationException($"Error al crear el préstamo: {ex.Message}", ex);
            }

            return idPrestamo;
        }

        /*
        PRE: dni != null
        POST: devuelve true si el usuario puede realizar préstamos (está activo y no tiene documentos vencidos),
              false en caso contrario
        */
        public bool PuedeRealizarPrestamo(string dni)
        {
            Usuario usuario = GetUsuario(dni);

            if (usuario == null || !usuario.DadoAlta)
                return false;

            // Opcional: puedes añadir más restricciones
            // Por ejemplo, si tiene documentos vencidos
            return !TieneDocumentosFueraPlazo(dni);
        }

        /*
        PRE: codigoEjemplar > 0
        POST: devuelve true si el ejemplar está disponible para préstamo (existe, está activo
              y no está actualmente prestado), false en caso contrario
        */
        public bool EjemplarDisponibleParaPrestamo(int codigoEjemplar)
        {
            Ejemplar ejemplar = Persistencia.Persistencia.GetEjemplar(new Ejemplar(codigoEjemplar));

            if (ejemplar == null || !ejemplar.Activo)
                return false;

            // Verificar si está en un préstamo activo
            List<Prestamo> prestamosDelEjemplar = Persistencia.Persistencia.GetPrestamosPorEjemplar(codigoEjemplar);

            foreach (Prestamo p in prestamosDelEjemplar)
            {
                if (p.Estado == EstadoPrestamo.enProceso)
                {
                    // Verificar si este ejemplar específicamente no ha sido devuelto
                    var prestamoEjemplar = Persistencia.Persistencia.GetPrestamoEjemplar(p.Id, codigoEjemplar);
                    if (prestamoEjemplar != null && prestamoEjemplar.FechaDevolucion == DateTime.MinValue)
                    {
                        return false; // Está prestado y no devuelto
                    }
                }
            }

            return true;
        }

        // En ILNPSala/LNPSala
        public Ejemplar GetEjemplar(int codigo)
        {
            return Persistencia.Persistencia.GetEjemplar(new Ejemplar(codigo));
        }

    }
}
