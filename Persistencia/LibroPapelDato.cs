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


        public LibroPapelDato(string isbn, string titulo, string autor, string editorial, int anoEdicion) : base(isbn)
        {
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            AnoEdicion = anoEdicion;
        }
    }
}
