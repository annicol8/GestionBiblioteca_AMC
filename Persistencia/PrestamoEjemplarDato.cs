using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class PrestamoEjemplarDato : Entity<ClavePrestamoEjemplar>
    {
        private int idPrestamo;        // Esto tiene que estar???
        private int codigoEjemplar;
        private DateTime fechaDevolucion;

        
        public int IdPrestamo {
            get { return idPrestamo; } set { idPrestamo = value; }
        }

        
        
        public int CodigoEjemplar { 
            get { return codigoEjemplar; } set { codigoEjemplar = value; }
        }
        

        public DateTime FechaDevolucion {
            get { return fechaDevolucion; } set { fechaDevolucion = value; }
        }

        public PrestamoEjemplarDato(int idPrestamo, int codigoEjemplar, DateTime fechaDevolucion) : base(new ClavePrestamoEjemplar(idPrestamo, codigoEjemplar))
        {
            FechaDevolucion = fechaDevolucion;
        }
    }
}
