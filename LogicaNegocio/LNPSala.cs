using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace LogicaNegocio
{
    public class LNPSala : LNPersonal, ILNPSala
    {
        // public LNPSala(PersonalSala personal) : base(personal) { }  NO SE SI HAY QUE PONER EL CONSTRUCTOR

        public int AltaPrestamo(Prestamo prestamo)
        {
            return Persistencia.Persistencia.AltaPrestamo(prestamo);
        }

        public void DevolverEjemplar(int idPrestamo, int codigoEjemplar)
        {
            List<Ejemplar> ejemplaresDePrestamo = Persistencia.Persistencia.GetEjemplaresDePrestamo(idPrestamo);
            foreach (Ejemplar ejemplar in ejemplaresDePrestamo)
            {
                if (ejemplar.Codigo == codigoEjemplar)
                {
                    Persistencia.Persitencia.UpdatePrestamoEjemplar(
                        idPrestamo,
                        codigoEjemplar,
                        DateTime.Now);

                    Prestamo P = Persistencia.Persistencia.GetPrestamoPorId(idPrestamo);
                    Persistencia.Persistencia.UpdatePrestamo(new Prestamo(
                        P.Id,
                        P.FechaPrestamo,
                        P.FechaDevolucion,
                        EstadoPrestamo.Finalizado,
                        P.DniPersonal,
                        P.DniUsuario));
                }
            }
        }

        public List<Ejemplar> GetEjemplaresNoDevueltos(int idPrestamo)
        {
            return Persistencia.Persistencia.GetEjemplaresNoDevueltosDePrestamo(idPrestamo); // Si el idPrestamo no existe, qué devuelve? Lista vacia o null?
        }

        public EstadoPrestamo GetEstadoPrestamo(int idPrestamo)
        {
            Prestamo prestamo = Persistencia.Persistencia.GetPrestamoPorId(idPrestamo);
            if (prestamo == null)
            {
                return null; // esto o lanzamos excepciones?
            }
            return prestamo.Estado;
        }

        public Prestamo GetPrestamo(int idPrestamo)
        {
            return Persistencia.Persistencia.GetPrestamoPorId(idPrestamo);
        }

        public List<Prestamo> GetPrestamosFueraDePlazo()
        {
            throw new NotImplementedException();
        }

        public List<Prestamo> GetPrestamosPorDocumento(string isbn)
        {
            List<Ejemplar> ejemplares =
                           Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);

            List<Prestamo> prestamos = new List<Prestamo>();
            HashSet<int> idsPrestamosAgregados = new HashSet<int>();

            foreach (Ejemplar ejemplar in ejemplares)
            {
                List<PrestamoEjemplarDato> prestamoEjemplares =
                    Persistencia.Persistencia.GetPrestamosPorEjemplar(ejemplar.Codigo);

                foreach (var prestamoEjemplar in prestamoEjemplares)
                {
                    if (!idsPrestamosAgregados.Contains(prestamoEjemplar.IdPrestamo))
                    {
                        Prestamo prestamo =
                            Persistencia.Persistencia.GetPrestamoPorId(prestamoEjemplar.IdPrestamo);

                        if (prestamo != null)
                        {
                            prestamos.Add(prestamo);
                            idsPrestamosAgregados.Add(prestamo.Id);
                        }
                    }
                }
            }
            return prestamos;
        }

        public Usuario GetUsuarioPrestamo(int idPrestamo)
        {
            Prestamo prestamo = Persistencia.Persistencia.GetPrestamoPorId(idPrestamo);
            if (prestamo == null)
            {
                return null;
            }
            return Persistencia.Persistencia.GetUsuario(prestamo.DniUsuario);
        }
    }
}
