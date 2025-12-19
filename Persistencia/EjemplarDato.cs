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
        private string dniPersonalAdq;  // Clave foránea


        // Propiedades públicas
        public string IsbnDocumento { 
            get { return isbn; } set { isbn = value; }
        }
        public bool Activo { 
            get { return activo; } set { activo = value; }
        }
        public string DniPersonalAdq { 
            get { return dniPersonalAdq; } set { dniPersonalAdq = value; }
        }
        

        public EjemplarDato(int codigo, string isbn, bool activo, string dniPersonalAdq) : base(codigo)
        {
            IsbnDocumento = isbn;
            Activo = activo;
            DniPersonalAdq = dniPersonalAdq;
        }
    }
}
