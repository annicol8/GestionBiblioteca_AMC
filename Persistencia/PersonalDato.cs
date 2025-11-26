using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PersonalDato: Entity<String>
    {
        private String dni;
        private String nombre;
        private String tipoPersonal;

        public String Dni { get; private set; }
        public String Nombre { get; private set; }
        public String TipoPersonal { get; private set; }
        public PersonalDato(String dni, String nombre, String tipo): base(dni) {
            
            this.dni = dni;
            this.nombre = nombre;
            this.tipoPersonal = tipo;
        }
    }
}
