using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class LibroPapel : Documento
    {

        public LibroPapel(string isbn, string titulo, string autor, string editorial, int anoEdicion)
            : base(isbn, titulo, autor, editorial, anoEdicion)
        {
        }

        // Constructor búsquedas
        public LibroPapel(string isbn) : base(isbn)
        {
        }

        public override int DiasPrestamoPermitidos()
        {
            return 15;
        }


    }
}
