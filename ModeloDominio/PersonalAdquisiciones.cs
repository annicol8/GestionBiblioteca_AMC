using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalAdquisiciones: Personal
    {
        //PRE: parametros de entrada no nulos y válidos
        //POST: Se crea una instancia de PersonalAdquisiciones asignando automáticamente el tipo de personal a personalAdquisiciones. Los demás atributos heredados están inicializados
        public PersonalAdquisiciones(string dni, string nombre, string contraseña) : base(dni, nombre, contraseña) 
        {
            Tipo = TipoPersonal.personalAdquisiciones;
        }

        //PRE: parametros de entrada no nulos y válidos
        //POST: Se crea una instancia de PersonalAdquisiciones asignando automáticamente el tipo de personal a personalAdquisiciones y con dni como contraseña por defecto. Los demás atributos heredados están inicializados
        public PersonalAdquisiciones(string dni, string nombre)
            : base(dni, nombre)
        {
            tipo = TipoPersonal.personalAdquisiciones;
        }

        //Constructor búsqueda
        //PRE: parametros de entrada no nulos y válidos
        //POST: Se crea una instancia de PersonalAdquisiciones asignando automáticamente, aquí solo dni esta inicializado
        public PersonalAdquisiciones(string dni) : base(dni)
        {
            tipo = TipoPersonal.personalAdquisiciones;
        }
    }
}
