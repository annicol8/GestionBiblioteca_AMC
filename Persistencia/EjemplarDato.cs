using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class EjemplarDato : Entity<int>
    {

        // Atributos
        private int codigo;    // Clave primaria
        private string isbn;           // Clave foránea
        private bool activo;
        private int idPersonalAdq;  // Clave foránea


        // Propiedades públicas
        public int Codigo { get; private set; }
        public string Isbn { get; private set; }
        public bool Activo { get; private set; }
        public int IdPersonalAdq { get; private set; }


        public EjemplarDato(int codigo, string isbn, bool activo) : base(codigo)
        {
            Codigo = codigo;
            Isbn = isbn;
            Activo = activo;
        }
    }
}
