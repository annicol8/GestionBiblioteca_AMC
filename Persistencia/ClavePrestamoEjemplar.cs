using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class ClavePrestamoEjemplar : IEquatable<ClavePrestamoEjemplar>
    {
        private int idPrestamo;
        private int codigoEjemplar;

        public int IdPrestamo { get; private set; }
        public int CodigoEjemplar { get; private set; }

        public ClavePrestamoEjemplar(int idPrestamo, int codigoEjemplar)
        {
            this.idPrestamo = idPrestamo;
            this.codigoEjemplar = codigoEjemplar;

        }

        public bool Equals(ClavePrestamoEjemplar other)
        {
            return this.idPrestamo == other.idPrestamo &&
                   this.codigoEjemplar == other.codigoEjemplar;
        }

        public override int GetHashCode()
        {
            return idPrestamo.GetHashCode() + codigoEjemplar.GetHashCode();
        }


    }
}
