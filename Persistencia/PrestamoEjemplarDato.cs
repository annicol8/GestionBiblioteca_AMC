using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PrestamoEjemplarDato : Entity<ClavePrestamoEjemplar>
    {
        //private int idPrestamo;         // los dos atributos o uno que sea clave?? y en el resto de clases, tienen que tener el atributo que se le pasa en Entity<...>
        //private int codigoEjemplar;
        private DateTime fechaDevolucion;

        public int IdPrestamo { get; private set; }
        public int CodigoEjemplar { get; private set; }
        public int ClavePrestamoEjemplar { get; private set; }
        public DateTime FechaDevolucion { get; private set; }

        public PrestamoEjemplarDato(int idPrestamo, int codigoEjemplar, DateTime fechaDevolucion) : base(new ClavePrestamoEjemplar(idPrestamo, codigoEjemplar))
        {
            this.fechaDevolucion = fechaDevolucion;
        }
    }
}
