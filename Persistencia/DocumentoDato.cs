using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class DocumentoDato : Entity<string>
    {

        // Atributos
        private string titulo;
        private string autor;
        private string editorial;
        private int anoEdicion;
        public string tipoDocumento;

        // Propiedades públicas
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string Editorial { get; private set; }
        public int AnoEdicion { get; private set; }
        //poiner para transformador??
        //public string TipoDocumento { get; private set; } // "AudioLibro" o ""LibroPapel


        public DocumentoDato(string isbn, string titulo, string autor, string editorial, int anoEdicion) : base(isbn)
        {
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            AnoEdicion = anoEdicion;
        }
    }
}
