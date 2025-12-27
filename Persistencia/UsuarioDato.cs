using System;

namespace Persistencia
{
    internal class UsuarioDato : Entity<string>
    {
        private string nombre;
        private bool dadoAlta;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public bool DadoAlta
        {
            get { return dadoAlta; }
            set { dadoAlta = value; }
        }
        /*
PRE: dni != null && dni != "" && nombre != null && nombre != ""
POST: crea un nuevo UsuarioDato con los datos proporcionados
*/
        public UsuarioDato(String dni, String nombre, bool dadoAlta) : base(dni)
        {
            Nombre = nombre;
            DadoAlta = dadoAlta;
        }
    }
}
