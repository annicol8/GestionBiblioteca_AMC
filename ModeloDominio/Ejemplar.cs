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

        public string InfoCompleta
        {
            get { return $"Código: {Codigo} - ISBN: {IsbnDocumento}"; }
        }

        //PRE: cod debe ser un entero positivo (>0) 
        //POST: se instancia un Ejemplar con el codigo inicializado y se crea como ejemplar activo por defecto
        public Ejemplar(int cod)
        {
            Codigo = cod;
            Activo = true;
        }

        //PRE: todos los parámetros de entrada distintos de null y válidos
        //POST: Todos los atributos quedan inicializados con los valores proporcionados
        public Ejemplar(int codigo, bool activo, string isbnDocumento, string dniPersonalAdq) : this(codigo)
        {
            Activo = activo;
            IsbnDocumento = isbnDocumento;
            DniPAdq = dniPersonalAdq;
        }

        //PRE:
        //POST: devuelve true si other no es nulo y coinciden los códigos, falso en caso contrario
        public bool Equals(Ejemplar other)
        {
            if (other == null) return false;
            return this.codigo == other.codigo;
        }

        public override int GetHashCode()
        {
            return codigo.GetHashCode();
        }

        /*
        // Métodos 
        public bool EstaPrestado()
        {
            return Prestamos?.Any(p => p.Estado == EstadoPrestamo.EnProceso) ?? false;
        }*/


    }
}
