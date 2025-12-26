using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class AudioLibro : Documento
    {
        // Atributos 
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


        //PRE: todos los parametros de entrada deben ser no nulos y el anoEdicion debe ser >1000 y menor o igual al año actual, la duracion debe ser un entero >0
        //POST: se crea una instancia de AudioLibro con todos los atributos inicializados
        public AudioLibro(string isbn, string titulo, string autor, string editorial, int anoEdicion,
                         string formatoDigital, int duracion)
            : base(isbn, titulo, autor, editorial, anoEdicion)
        {
            FormatoDigital = formatoDigital;
            Duracion = duracion;
        }

        // Constructor búsqueda
        //PRE: el isbn debe ser distinto de nulo y un isbn válido de 13 números
        //POST: Se crea una instancia de AudioLibro solo con ISBN inicializado
        public AudioLibro(string isbn) : base(isbn)
        {
        }

        //PRE:
        //POST: devuelve 10 como día de préstamo para los audiolibros, no modifica el estado del objeto
        public override int DiasPrestamoPermitidos()
        {
            return 10;
        }
    }
}
