using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public abstract class Documento: IEquatable<Documento>
    {
        // Atributos
        private string isbn;           // Clave primaria
        private string titulo;
        private string autor;
        private string editorial;
        private int anoEdicion;

        // Propiedades públicas
        public string Isbn {
            get { return isbn; }
            set { isbn = value; }
        }
        public string Titulo { 
            get { return titulo; }
            set { titulo = value; }
        }
        public string Autor {
            get { return autor; }
            set { autor = value; }
        }
        public string Editorial {
            get { return editorial; }
            set { editorial = value; }
        }
        public int AnoEdicion {
            get { return anoEdicion; }
            set { anoEdicion = value; }
        }

        // Relación
        public List<Ejemplar> Ejemplares { get; set; }

        // Método abstracto
        public abstract int DiasPrestamoPermitidos();

        public Documento(string isbn, string titulo, string autor, string editorial, int anoEdicion)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            AnoEdicion = anoEdicion;
        }

        //constructor para busqueda
        public Documento(string isbn)
        {
            this.isbn = isbn;
        }

        public bool Equals(Documento otroDocumento)
        {
            if (otroDocumento == null) return false;
            return this.isbn==otroDocumento.isbn;
        }

        public override int GetHashCode()
        {
            return isbn.GetHashCode();
        }
    }
}
