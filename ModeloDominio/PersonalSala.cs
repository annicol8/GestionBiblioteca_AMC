using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalSala: Personal
    {
        //PRE: parametros de entrada no nulos y válidos
        //POST: Se crea una instancia de PersonalAdquisiciones asignando automáticamente el tipo de personal a personalSala. Los demás atributos heredados están inicializados
        public PersonalSala(string dni, string nombre, string contraseña): base(dni, nombre, contraseña) 
        {
            Tipo = TipoPersonal.personalSala;
        }

        //PRE: parametros de entrada no nulos y válidos
        //POST: Se crea una instancia de PersonalAdquisiciones asignando automáticamente el tipo de personal a personalSala y con dni como contraseña por defecto. Los demás atributos heredados están inicializado
        public PersonalSala(string dni, string nombre)
            : base(dni, nombre)
        {
            tipo = TipoPersonal.personalSala;
        }

        //Constructor búsqueda
        //PRE: parametros de entrada no nulos y válidos
        //POST: Se crea una instancia de personalSala asignando automáticamente, aquí solo dni esta inicializado
        public PersonalSala(string dni) : base(dni)
        {
            tipo = TipoPersonal.personalSala;
        }
    }
}
