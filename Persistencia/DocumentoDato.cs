using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal abstract class DocumentoDato : Entity<string>
    {
        // Atributos
        private string titulo;
        private string autor;
        private string editorial;
        private int anoEdicion;

        // Propiedades públicas
        public string Titulo { 
            get { return titulo; } set { titulo = value; }
        }
        public string Autor { 
            get { return autor; } set { autor = value; }
        }
        public string Editorial { 
            get { return editorial; } set { editorial = value; }
        }
        public int AnoEdicion { 
            get { return anoEdicion; } set { anoEdicion = value; }
        }

        //poiner para transformador??
        //public string TipoDocumento { get; private set; } // "AudioLibro" o ""LibroPapel


        protected DocumentoDato(string isbn, string titulo, string autor, string editorial, int anoEdicion) : base(isbn)
        {
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            AnoEdicion = anoEdicion;
        }
    }
}
