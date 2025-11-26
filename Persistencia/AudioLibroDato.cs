using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class AudioLibroDato: Entity<String>
    {
        private string isbn; // Clave primaria
        private string formatoDigital;
        private int duracion;

        
        public string Isbn { get; private set; }
        public AudioLibroDato(string isbn) : base(isbn)
        {
            Isbn = isbn;
        }
    }
}
