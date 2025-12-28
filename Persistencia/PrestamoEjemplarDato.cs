using System;

namespace Persistencia
{
    public class PrestamoEjemplarDato : Entity<ClavePrestamoEjemplar>
    {
        private DateTime fechaDevolucion;

        public int IdPrestamo
        {
            get { return Clave.IdPrestamo; }
            set { Clave.IdPrestamo = value; }
        }

        public int CodigoEjemplar
        {
            get { return Clave.CodigoEjemplar; }
            set { Clave.CodigoEjemplar = value; }
        }

        public DateTime FechaDevolucion
        {
            get { return fechaDevolucion; }
            set { fechaDevolucion = value; }
        }
        /*
PRE: idPrestamo > 0 && codigoEjemplar > 0
POST: crea una nueva relación PrestamoEjemplar con la fecha de devolución indicada
      
*/
        public PrestamoEjemplarDato(int idPrestamo, int codigoEjemplar, DateTime fechaDevolucion) : base(new ClavePrestamoEjemplar(idPrestamo, codigoEjemplar))
        {
            FechaDevolucion = fechaDevolucion;
        }
    }
}
