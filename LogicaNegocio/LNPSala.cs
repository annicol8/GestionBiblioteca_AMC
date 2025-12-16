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
        public LNPSala(Personal personal) : base(personal)
        {
        }


        public int AltaPrestamo(Prestamo prestamo)
        {
            return Persistencia.Persistencia.AltaPrestamo(prestamo);
        }

        public void DevolverEjemplar(int idPrestamo, int codigoEjemplar)
        {
            // Verificar que el ejemplar existe en el préstamo
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
            */

            return null;
        }

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

        public Prestamo GetPrestamo(int idPrestamo)
        {
            return Persistencia.Persistencia.GetPrestamoPorId(idPrestamo);
        }

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

        public List<Prestamo> GetPrestamosPorDocumento(string isbn)
        {
            List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);

            List<Prestamo> prestamos = new List<Prestamo>();
            HashSet<int> idsPrestamosAgregados = new HashSet<int>();

            foreach (Ejemplar ejemplar in ejemplares)
            {
                List<Prestamo> prestamosDelEjemplar =
                    Persistencia.Persistencia.GetPrestamosPorEjemplar(ejemplar.Codigo);

                foreach(Prestamo p in prestamosDelEjemplar)
                {
                    if (!prestamos.Contains(p))
                    {
                        prestamos.Add(p);
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

        public List<Prestamo> GetTodosPrestamos()
        {
            return Persistencia.Persistencia.GetPrestamos();
        }
    }
}
