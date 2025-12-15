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
        public string FormatoDigital {
            get { return formatoDigital; }
            set { formatoDigital = value; }
        }
        public int Duracion {
            get { return duracion; }
            set { duracion = value; }
        }

        public AudioLibro(string isbn, string titulo, string autor, string editorial, int anoEdicion,
                         string formatoDigital, int duracion)
            : base(isbn, titulo, autor, editorial, anoEdicion)
        {
            FormatoDigital = formatoDigital;
            Duracion = duracion;
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
