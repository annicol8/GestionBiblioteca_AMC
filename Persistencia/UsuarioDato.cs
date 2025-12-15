using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class UsuarioDato: Entity<string>   
    {
        private string nombre;
        private bool dadoAlta;

        public string Nombre {
            get { return nombre; } set { nombre = value; }
        }
        public bool DadoAlta {
            get { return dadoAlta; } set { dadoAlta = value; }
        }

        public UsuarioDato(String dni, String nombre, bool dadoAlta) : base(dni)
        {
            Nombre = nombre;
            DadoAlta = dadoAlta;
        }
    }
}
