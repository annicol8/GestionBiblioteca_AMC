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

        public Usuario(string dni, string nombre, bool dadoAlta)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.dadoAlta = dadoAlta;
        }

        //constructor para búsquedas
        public Usuario(string dni)
        {
            this.dni = dni;
            this.nombre = null;
            this.dadoAlta = false;
        }

        public string Dni { get { return dni; } }
        
        public string Nombre {  get { return nombre; } }

        public bool DadoAlta { get { return dadoAlta; } set { dadoAlta = value; } }

        
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
