using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public abstract class Personal: IEquatable<Personal>
    {
        private string dni;
        private string nombre;
        protected TipoPersonal tipo;

        public string Dni {
            get { return dni; } set { dni = value; }
        }
        public string Nombre {
            get { return nombre; } set { nombre = value; }
        }
        public TipoPersonal Tipo {
            get { return tipo; } set { tipo = value; }
        }

        public Personal(string dni, string nombre)
        {
            Dni = dni;
            Nombre = nombre;
        }

        public Personal(string dni)
        {
            Dni = dni;
        }
        public bool Equals(Personal otroPersonal)
        {
            if (otroPersonal == null) return false;
            return this.dni == otroPersonal.dni;
        }

        public override int GetHashCode()
        {
            return dni.GetHashCode();
        }
    }
}
