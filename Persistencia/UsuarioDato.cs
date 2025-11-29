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

        public string Nombre { get; private set;}
        public bool DadoAlta { get; private set;}

        public string Dni { get; }

        public UsuarioDato(String dni, String nombre, bool dadoAlta) : base(dni)
        {
            Nombre = nombre;
            DadoAlta = dadoAlta;
        }
    }
}
