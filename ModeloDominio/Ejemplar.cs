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
        private string dniPAdq;
        private string isbnDocumento;
        

        // Propiedades
        public int Codigo {
            get { return codigo; }
            set { codigo = value; }
        }
        public bool Activo {
            get { return activo; } 
            set { activo = value; }
        }

        public string DniPAdq {
            get { return dniPAdq; }
            set { dniPAdq = value; }
        } 
        public string IsbnDocumento {
            get { return isbnDocumento; }
            set { isbnDocumento = value; }
        }
        public Documento Documento { get; set; }    // Documento asociado

        public Ejemplar(int cod)
        {
            Codigo = cod;
            Activo = true;
        }

        //TENDRÁ QUE HEREDAR DEL DE ARRIBA, NO?
        public Ejemplar(int codigo, bool activo, string isbnDocumento, string dniPersonalAdq)
        {
            Codigo = codigo;
            Activo = activo;
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
