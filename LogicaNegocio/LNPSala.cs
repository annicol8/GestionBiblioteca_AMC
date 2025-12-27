using System;
using System.Collections.Generic;
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
    }
}
