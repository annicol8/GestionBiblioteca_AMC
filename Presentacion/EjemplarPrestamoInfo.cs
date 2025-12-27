namespace Presentacion
{
    // EjemplarPrestamoInfo: Clase auxiliar para la vista que combina datos de Ejemplar y Documento
    // Evita exponer objetos del modelo de dominio directamente en la UI y permite agregar 
    // propiedades específicas de presentación (como "Estado") sin modificar las entidades originales
    public class EjemplarPrestamoInfo
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }  // Título del documento
        public string Isbn { get; set; }
        public string Estado { get; set; } = "No devuelto";

        public override string ToString()
        {
            return $"Código: {Codigo} - {Titulo}";
        }
    }
}
