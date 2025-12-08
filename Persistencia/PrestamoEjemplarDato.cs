using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PrestamoEjemplarDato : Entity<ClavePrestamoEjemplar>
    {
        //private int idPrestamo;        
        //private int codigoEjemplar;
        private DateTime fechaDevolucion;

        
        public int IdPrestamo { get; private set; }
        public int CodigoEjemplar { get; private set; }
        public DateTime FechaDevolucion { get; private set; }

        public PrestamoEjemplarDato(int idPrestamo, int codigoEjemplar, DateTime fechaDevolucion) : base(new ClavePrestamoEjemplar(idPrestamo, codigoEjemplar))
        {
            this.fechaDevolucion = fechaDevolucion;
        }
    }
}
