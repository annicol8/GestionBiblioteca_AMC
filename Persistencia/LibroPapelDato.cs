using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class LibroPapelDato : Entity<string>
    {
        private string titulo;
        private string autor;
        private string editorial;
        private int anoEdicion;

        // Propiedades públicas
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string Editorial { get; private set; }
        public int AnoEdicion { get; private set; }


        protected LibroPapelDato(string isbn, string titulo, string autor, string editorial, int anoEdicion) : base(isbn)
        {
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            AnoEdicion = anoEdicion;
        }
    }
}
