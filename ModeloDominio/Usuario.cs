using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Usuario: IEquatable<Usuario>
    {
        //Atributos
        private string dni;
        private string nombre;
        private bool dadoAlta;

        //Propiedades
        public string Dni {
            get { return dni; } set { dni = value; }
        }

        public string Nombre
        {
            get { return nombre; } set { nombre = value; }
        }

        public bool DadoAlta
        {
            get { return dadoAlta; } set { dadoAlta = value; }
        }

        //PRE: parámetros de entrada no nulos y válidos
        //POST: se ccrea una instancia de Usuario con todos los atributos incializados con los valores pasados como parámetros
        public Usuario(string dni, string nombre, bool dadoAlta)
        {
            Dni = dni;
            Nombre = nombre;
            DadoAlta = dadoAlta;
        }

        //Constructor búsqueda
        //PRE: dni debe ser no nulo y válido
        //POST: se crea una instancia de Usuario con el dni inicializado con el valor pasado y luego nombre se asigna como null y por defecto dado de alta como false
        public Usuario(string dni)
        {
            Dni = dni;
            Nombre = null;
            DadoAlta = false;
        }   
        
        //PRE:
        //POST: devuelve true si otroUsuario es no nulo y los dnis coinciden, false en caso contrario
        public bool Equals(Usuario otroUsuario)
        {
            if (otroUsuario == null) return false;
            return this.dni == otroUsuario.dni;
        }

        public override int GetHashCode()
        {
            return dni.GetHashCode();
        }

    }
}
