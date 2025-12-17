using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PersonalDato: Entity<string>
    {
        private string nombre;
        private TipoPersonal tipoPersonal;

        public string Nombre { 
            get { return nombre; }
            set { nombre = value; }
        }
        public TipoPersonal TipoPersonal { 
            get { return tipoPersonal; }
            set {  tipoPersonal = value; }
        }

        public PersonalDato(string dni, string nombre, TipoPersonal tipoPersonal): base(dni)
        {
            Nombre = nombre;
            TipoPersonal = tipoPersonal;
        }
    }
}
