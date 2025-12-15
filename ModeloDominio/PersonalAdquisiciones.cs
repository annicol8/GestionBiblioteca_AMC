using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalAdquisiciones: Personal
    {
        public PersonalAdquisiciones(string dni, string nombre) : base(dni, nombre) 
        {
            Tipo = TipoPersonal.personalAdquisiciones;
        }
    }
}
