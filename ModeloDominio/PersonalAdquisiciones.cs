using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalAdquisiciones: Personal
    {
        public PersonalAdquisiciones(string dni, string nombre, string contraseña) : base(dni, nombre, contraseña) 
        {
            Tipo = TipoPersonal.personalAdquisiciones;
        }

        public PersonalAdquisiciones(string dni, string nombre)
            : base(dni, nombre)
        {
            tipo = TipoPersonal.personalAdquisiciones;
        }

        public PersonalAdquisiciones(string dni) : base(dni)
        {
            tipo = TipoPersonal.personalAdquisiciones;
        }
    }
}
