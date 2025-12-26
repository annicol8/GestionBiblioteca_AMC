using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public abstract class Personal: IEquatable<Personal>
    {
        //Atributos
        private string dni;
        private string nombre;
        private string contraseña;
        protected TipoPersonal tipo;

        //Propiedades
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

        //PRE: todos los parametros de entrada no nulos y dni válido, tipo solo puede ser o personalSala o personalAdquisiciones
        //POST: se crea una instancia de Personal con todos los atributos inicializados
        public Personal(string dni, string nombre, string contraseña, TipoPersonal tipo)
        {
            Dni = dni;
            Nombre = nombre;
            Contraseña = contraseña;
            Tipo = tipo;
        }

        //PRE: dni y nombre no nulos y dni debe ser un dni válido
        //POST: se crea una instancia de Personal pero con dni como contraseña por defecto
        public Personal (string dni, string nombre)
        {
            Dni = dni;
            Nombre = nombre;
            Contraseña = dni; //Constraseña por defecto = DNI
        }

        //PRE: dni, nombre y contraseña no nulos y dni debe ser un dni válido
        //POST: se crea una instancia de Personal pero ahora con contraseña personalizada
        public Personal(string dni, string nombre, string contraseña)
        {
            Dni = dni;
            Nombre = nombre;
            Contraseña = contraseña;
        }

        //Constructor búsqueda
        //PRE: dni no nulo y válido
        //POST:  solo dni queda inicializado
        public Personal(string dni)
        {
            Dni = dni;
        }

        //PRE: contraseñaIntroducida no debe ser null y debe estar inicializada
        //POST: devuelve true si las contraseñas coinciden, false en caso contrario. No se modifica el estado del objeto
        public bool ValidarContraseña(string contraseñaIntroducida)
        {
            return this.contraseña == contraseñaIntroducida;
        }

        //PRE:
        //POST: devuelve true si otroPersonal no es nulo y los dnis coinciden, false en caso contrario.No se modifica el estado del objeto
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
