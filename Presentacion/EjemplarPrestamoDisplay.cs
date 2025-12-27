namespace Presentacion
{
    internal class EjemplarPrestamoDisplay
    {
        public int Codigo { get; set; }
        public string IsbnDocumento { get; set; }
        public string TituloDocumento { get; set; }
        public bool Prestado { get; set; }

        public EjemplarPrestamoDisplay(int codigo, string isbn, string titulo)
        {
            Codigo = codigo;
            IsbnDocumento = isbn;
            TituloDocumento = titulo;
            Prestado = true;
        }

        public override string ToString()
        {
            return $"ID ejemplar: {Codigo}";
        }

    }
}
