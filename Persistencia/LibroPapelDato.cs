using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class LibroPapelDato : DocumentoDato
    {
        public string Isbn { get; }
        public LibroPapelDato(string isbn, string titulo, string autor, string editorial, int anoEdicion) 
            : base(isbn,titulo,autor,editorial,anoEdicion)
        {
        }
    }
}
