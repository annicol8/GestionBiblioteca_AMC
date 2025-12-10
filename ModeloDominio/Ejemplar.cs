using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Ejemplar: IEquatable<Ejemplar>
    {
        // Atributos
        private int codigo;         // Clave primaria
        private bool activo;          // Para bajas lógicas
        

        // Propiedades
        public int Codigo { get; }
        public bool Activo { get; set; }
        public string DniPAdq { get; } 

        // Relaciones
        public string IsbnDocumento { get; }  // Clave foranea
        public Documento Documento { get; set; }    // Documento asociado

        public Ejemplar(int cod)
        {
            this.codigo = cod;
            this.activo = true;
        }

        public Ejemplar(int codigo, bool activo, string isbnDocumento, string dniPersonalAdq)
        {
            this.codigo = codigo;
            this.activo = activo;
            IsbnDocumento = isbnDocumento;
            DniPAdq = dniPersonalAdq;
        }

        public bool Equals(Ejemplar other)
        {
            if (other == null) return false;
            return this.codigo == other.codigo;
        }

        public override int GetHashCode()
        {
            return codigo.GetHashCode();
        }

        //public List<Prestamo> Prestamos { get; set; }

        // Métodos 
        /*public bool EstaPrestado()
        {
            return Prestamos?.Any(p => p.Estado == EstadoPrestamo.EnProceso) ?? false;
        }*/
    }
}
