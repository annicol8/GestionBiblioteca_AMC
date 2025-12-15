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

        public string Titulo
        {
            get { return titulo; }
            private set { titulo = value; }
        }
        public string Autor
        {
            get { return autor; }
            private set { autor = value; }
        }
        public string Editorial
        {
            get { return editorial; }
            private set { editorial = value; }
        }
        public int AnoEdicion
        {
            get { return anoEdicion; }
            private set { anoEdicion = value; }
        }
        public string FormatoDigital
        {
            get { return formatoDigital; }
            private set { formatoDigital = value; }
        }
        public int Duracion
        {
            get { return duracion; }
            private set { duracion = value; }
        }




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
