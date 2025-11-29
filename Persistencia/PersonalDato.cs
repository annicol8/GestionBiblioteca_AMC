using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PersonalDato: Entity<String>
    {
        private string dni;
        private string nombre;
        private TipoPersonal tipoPersonal;

        public string Dni { get; private set; }
        public string Nombre { get; private set; }
        public string TipoPersonal { get; private set; }

        public PersonalDato(string dni, string nombre, TipoPersonal tipoPersonal): base(dni)
        {
            this.nombre = nombre;
            this.tipoPersonal = tipoPersonal;
        }
    }
}
