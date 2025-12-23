using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalSala: Personal
    {
        public PersonalSala(string dni, string nombre, string contraseña): base(dni, nombre, contraseña) 
        {
            Tipo = TipoPersonal.personalSala;
        }

        public PersonalSala(string dni, string nombre)
            : base(dni, nombre)
        {
            tipo = TipoPersonal.personalSala;
        }

        public PersonalSala(string dni) : base(dni)
        {
            tipo = TipoPersonal.personalSala;
        }
    }
}
