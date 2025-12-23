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
        private string contraseña;
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

        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }

        public Personal(string dni, string nombre, string contraseña, TipoPersonal tipo)
        {
            Dni = dni;
            Nombre = nombre;
            Contraseña = contraseña;
            Tipo = tipo;
        }

        public Personal (string dni, string nombre)
        {
            Dni = dni;
            Nombre = nombre;
            Contraseña = dni; //Constraseña por defecto = DNI
        }

        public Personal(string dni, string nombre, string contraseña)
        {
            Dni = dni;
            Nombre = nombre;
            Contraseña = contraseña;
        }

        public Personal(string dni)
        {
            Dni = dni;
        }

        public bool ValidarContraseña(string contraseñaIntroducida)
        {
            return this.contraseña == contraseñaIntroducida;
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
