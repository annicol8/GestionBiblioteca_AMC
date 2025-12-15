using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Usuario: IEquatable<Usuario>
    {
        private string dni;
        private string nombre;
        private bool dadoAlta;

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

        public Usuario(string dni, string nombre, bool dadoAlta)
        {
            Dni = dni;
            Nombre = nombre;
            DadoAlta = dadoAlta;
        }

        //constructor para búsquedas
        public Usuario(string dni)
        {
            Dni = dni;
            Nombre = null;
            DadoAlta = false;
        }       
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
