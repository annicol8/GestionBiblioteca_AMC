using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    internal class Usuario
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

        public string getDni()
        {
            return this.dni;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public bool estaDadoAlta()
        {
            return this.dadoAlta;
        }

        public void actualizarAlta(bool b)
        {
            this.dadoAlta = b;
        }

    }
}
