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
       public LNPSala(PersonalSala personal) : base(personal) { }

        public int AltaPrestamo(Prestamo prestamo)
        {
            return Persistencia.Persistencia.AltaPrestamo(prestamo);
        }

        public void DevolverEjemplar(int idPrestamo, string codigoEjemplar)
        {
            throw new NotImplementedException();
        }

        public List<Ejemplar> GetEjemplaresNoDevueltos(int idPrestamo)
        {
            throw new NotImplementedException();
        }

        public EstadoPrestamo GetEstadoPrestamo(int idPrestamo)
        {
            throw new NotImplementedException();
        }

        public Prestamo GetPrestamo(int idPrestamo)
        {
            throw new NotImplementedException();
        }

        public List<Prestamo> GetPrestamosFueraDePlazo()
        {
            throw new NotImplementedException();
        }

        public List<Prestamo> GetPrestamosPorDocumento(string isbn)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioPrestamo(int idPrestamo)
        {
            throw new NotImplementedException();
        }
    }
}
