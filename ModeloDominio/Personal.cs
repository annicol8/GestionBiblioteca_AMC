using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public abstract class Personal
    {
        private string dni;
        private string nombre;
        protected TipoPersonal tipo;

        public string Dni {get; private set;}
        public string Nombre {get; private set;}
        public TipoPersonal Tipo {get; private set;}

        public Personal(string dni, string nombre)
        {
            Dni = dni;
            Nombre = nombre;
        }
    }
}
