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
        private string isbn;           // Clave foránea
        private bool activo;
        private int idPersonalAdq;  // Clave foránea


        // Propiedades públicas
        public string Isbn { get; private set; }
        public bool Activo { get; private set; }
        public string DniPersonalAdq { get; private set; }
        public int Codigo {  get; private set; }


        public EjemplarDato(int codigo, string isbn, bool activo, string dniPersonalAdq) : base(codigo)
        {
            Isbn = isbn;
            Activo = activo;
            DniPersonalAdq = dniPersonalAdq;
        }
    }
}
