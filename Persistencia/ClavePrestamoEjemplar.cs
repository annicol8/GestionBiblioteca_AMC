using System;

namespace Persistencia
{
    public class ClavePrestamoEjemplar : IEquatable<ClavePrestamoEjemplar>
    {
        private int idPrestamo;
        private int codigoEjemplar;

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
        /*
PRE: idPrestamo > 0 && codigoEjemplar > 0
POST: crea una nueva clave compuesta con el id de préstamo y código de ejemplar
*/
        public ClavePrestamoEjemplar(int idPrestamo, int codigoEjemplar)
        {
            IdPrestamo = idPrestamo;
            CodigoEjemplar = codigoEjemplar;

        }
        /*
PRE: ninguna
POST: devuelve true si other tiene el mismo idPrestamo y codigoEjemplar, false en caso contrario
*/
        public bool Equals(ClavePrestamoEjemplar other)
        {
            if (other == null) return false;
            return IdPrestamo == other.IdPrestamo &&
                   CodigoEjemplar == other.CodigoEjemplar;
        }

        public override int GetHashCode()
        {
            return idPrestamo.GetHashCode() + codigoEjemplar.GetHashCode();
        }

        /*
        PRE: ninguna
        POST: devuelve true si obj es una ClavePrestamoEjemplar con los mismos valores, false en caso contrario
        */
        public override bool Equals(object obj)
        {
            return Equals(obj as ClavePrestamoEjemplar);
        }


    }
}
