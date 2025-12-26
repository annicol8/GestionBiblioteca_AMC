using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class LibroPapel : Documento
    {
        //PRE: todos los parametros de entrada deben ser no nulos y el anoEdicion debe ser >1000 y menor o igual al año actual
        //POST: se crea una instancia de LibroPapel con todos los atributos heredados inicializados
        public LibroPapel(string isbn, string titulo, string autor, string editorial, int anoEdicion)
            : base(isbn, titulo, autor, editorial, anoEdicion)
        {
        }

        // Constructor búsqueda
        //PRE: el isbn debe ser distinto de nulo y un isbn válido de 13 números
        //POST: Se crea una instancia de LibroPapel solo con ISBN inicializado
        public LibroPapel(string isbn) : base(isbn)
        {
        }

        //PRE:
        //POST: devuelve 15 como día de préstamo para los LibroPapel, no modifica el estado del objeto
        public override int DiasPrestamoPermitidos()
        {
            return 15;
        }


    }
}
