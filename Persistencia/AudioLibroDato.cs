using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class AudioLibroDato : Entity<string>
    {

        private string titulo;
        private string autor;
        private string editorial;
        private int anoEdicion;
        private string formatoDigital;
        private int duracion;

        // Propiedades públicas
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string Editorial { get; private set; }
        public int AnoEdicion { get; private set; }
        public string FormatoDigital { get; private set; }
        public int Duracion { get; private set; }



        public AudioLibroDato(string isbn, string titulo, string autor, string editorial, int anoEdicion, string  formatoDigital, int duracion) : base(isbn)
        {
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            AnoEdicion = anoEdicion;
            FormatoDigital = formatoDigital;
            Duracion = duracion;
        }
        
        
        
        
    }
}
