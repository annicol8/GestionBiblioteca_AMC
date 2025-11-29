using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalSala: Personal
    {
        public PersonalSala(string dni, string nombre): base(dni, nombre) 
        {
            this.tipo = TipoPersonal.personalSala;
        }
    }
}
