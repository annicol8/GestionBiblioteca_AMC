using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Usuario
    {
        private string dni;
        private string nombre;
        private bool dadoAlta;

        public Usuario(string dni, string nombre, bool dadoAlta)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.dadoAlta = dadoAlta;
        }

        //constructor para búsquedas
        public Usuario(string dni)
        {
            this.dni = dni;
            this.nombre = null;
            this.dadoAlta = false;
        }

        public string Dni { get { return dni; } }
        
        public string getNombre {  get { return nombre; } }

        public bool DadoAlta { get { return dadoAlta; } set { dadoAlta = value; } }

        public void actualizarAlta(bool b)
        {
            this.dadoAlta = b;
        }

    }
}
