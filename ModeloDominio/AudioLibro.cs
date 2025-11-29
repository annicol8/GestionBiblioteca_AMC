using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class AudioLibro : Documento
    {
        // Atributos específicos
        private string formatoDigital;
        private int duracion;  // en segundos

        // Propiedades
        public string FormatoDigital { get; }
        public int Duracion { get; }

        public AudioLibro(string isbn, string titulo, string autor, string editorial, int anoEdicion,
                         string formatoDigital, int duracion)
            : base(isbn, titulo, autor, editorial, anoEdicion)
        {
            this.formatoDigital = formatoDigital;
            this.duracion = duracion;
        }

        // Constructor búsquedas
        public AudioLibro(string isbn) : base(isbn)
        {
        }

        public override int DiasPrestamoPermitidos()
        {
            return 10;
        }
    }
}
