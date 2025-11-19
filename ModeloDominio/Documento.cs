using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public abstract class Documento
    {
        // Atributos
        private string isbn;           // Clave primaria
        private string titulo;
        private string autor;
        private string editorial;
        private int anoEdicion;

        // Propiedades públicas
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int AnoEdicion { get; set; }

        // Relación
        public List<Ejemplar> Ejemplares { get; set; }

        // Método abstracto
        public abstract int DiasPrestamoPermitidos();

    }
}
