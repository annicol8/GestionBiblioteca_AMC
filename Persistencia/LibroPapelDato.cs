using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class LibroPapelDato : Entity<string>
    {
        private string isbn; // Clave primaria
        public string Isbn { get; private set; }
        public LibroPapelDato(string isbn) : base(isbn)
        {
            Isbn = isbn;
        }
    }
}
