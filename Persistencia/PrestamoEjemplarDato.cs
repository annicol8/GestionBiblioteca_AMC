using System;

namespace Persistencia
{
    public class PrestamoEjemplarDato : Entity<ClavePrestamoEjemplar>
    {
        private int idPrestamo;        // Esto tiene que estar???
        private int codigoEjemplar;
        private DateTime fechaDevolucion;


        public int IdPrestamo
        {
            get { return idPrestamo; }
            set { idPrestamo = value; }
        }



        public int CodigoEjemplar
        {
            get { return codigoEjemplar; }
            set { codigoEjemplar = value; }
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
