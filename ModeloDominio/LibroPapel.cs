using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class LibroPapel : Documento
    {
        public override int DiasPrestamoPermitidos()
        {
            return 15;
        }
    }
}
