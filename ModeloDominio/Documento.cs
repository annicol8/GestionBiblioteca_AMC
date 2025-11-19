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
        public string Isbn { get; }
        public string Titulo { get; }
        public string Autor { get; }
        public string Editorial { get; }
        public int AnoEdicion { get; }

        // Relación
        public List<Ejemplar> Ejemplares { get; set; }

        // Método abstracto
        public abstract int DiasPrestamoPermitidos();

    }
}
