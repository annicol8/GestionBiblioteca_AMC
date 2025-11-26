using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class UsuarioDato: Entity<string>
        
    {
        private String nombre;
        private bool dadoAlta;

        public String Nombre { get; private set;}
        public bool DadoAlta { get; private set;}
        public UsuarioDato(String dni, String nombre, bool dadoAlta) : base(dni) {

            this.nombre = nombre;
            this.dadoAlta = dadoAlta;
        }
    }
}
