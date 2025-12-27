using ModeloDominio;

namespace Persistencia
{
    internal class PersonalDato : Entity<string>
    {
        private string nombre;
        private TipoPersonal tipoPersonal;
        private string contraseña;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public TipoPersonal TipoPersonal
        {
            get { return tipoPersonal; }
            set { tipoPersonal = value; }
        }

        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }
        /*
PRE: dni != null && dni != "" && nombre != null && nombre != "" && 
     contraseña != null && contraseña != ""
POST: crea un nuevo PersonalDato con los datos proporcionados
*/
        public PersonalDato(string dni, string nombre, string contraseña, TipoPersonal tipoPersonal) : base(dni)
        {
            Nombre = nombre;
            Contraseña = contraseña;
            TipoPersonal = tipoPersonal;
        }
    }
}
