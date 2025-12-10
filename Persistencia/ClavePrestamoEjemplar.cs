using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ClavePrestamoEjemplar : IEquatable<ClavePrestamoEjemplar>
    {
        private int idPrestamo;
        private int codigoEjemplar;

        public int IdPrestamo { get; private set; }
        public int CodigoEjemplar { get; private set; }

        public ClavePrestamoEjemplar(int idPrestamo, int codigoEjemplar)
        {
            IdPrestamo = idPrestamo;
            CodigoEjemplar = codigoEjemplar;

        }

        public bool Equals(ClavePrestamoEjemplar other)
        {
            if(other==null) return false;
            return IdPrestamo == other.idPrestamo &&
                   CodigoEjemplar == other.codigoEjemplar;
        }

        public override int GetHashCode()
        {
            return idPrestamo.GetHashCode() + codigoEjemplar.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ClavePrestamoEjemplar);
        }


    }
}
