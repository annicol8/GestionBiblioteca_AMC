namespace Persistencia
{
    internal class EjemplarDato : Entity<int>
    {

        private string isbn;           // Clave foránea
        private bool activo;
        private string dniPersonalAdq;  // Clave foránea


        public string IsbnDocumento
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public string DniPersonalAdq
        {
            get { return dniPersonalAdq; }
            set { dniPersonalAdq = value; }
        }

        /*
PRE: codigo > 0 && isbn != null && isbn != "" && dniPersonalAdq != null && dniPersonalAdq != ""
POST: crea un nuevo EjemplarDato con los datos proporcionados
*/
        public EjemplarDato(int codigo, string isbn, bool activo, string dniPersonalAdq) : base(codigo)
        {
            IsbnDocumento = isbn;
            Activo = activo;
            DniPersonalAdq = dniPersonalAdq;
        }
    }
}
