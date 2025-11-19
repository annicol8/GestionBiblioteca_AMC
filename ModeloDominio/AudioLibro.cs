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

        public override int DiasPrestamoPermitidos()
        {
            return 10;
        }
    }
}
