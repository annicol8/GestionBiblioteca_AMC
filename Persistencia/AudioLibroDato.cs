using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class AudioLibroDato
    {
        private string isbn; // Clave primaria
        public string Isbn { get; private set; }
        public AudioLibroDato(string isbn) : base()
        {
            Isbn = isbn;
        }
    }
}
