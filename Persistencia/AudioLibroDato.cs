using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class AudioLibroDato: DocumentoDato 
    {
        private string formatoDigital;
        private int duracion;
        
        public string Isbn { get; }
        public string FormatoDigital { get; private set; }
        public int Duracion {  get; private set; }
        public AudioLibroDato(string isbn, string titulo, string autor, string editorial, int anoEdicion,
                          string formatoDigital, int duracion)
        : base(isbn, titulo, autor, editorial, anoEdicion)
        {
            FormatoDigital = formatoDigital;
            Duracion = duracion;
        }
    }
}
