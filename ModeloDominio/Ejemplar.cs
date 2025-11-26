using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Ejemplar
    {
        // Atributos
        private int codigo;         // Clave primaria
        private bool activo;          // Para bajas lógicas

        // Propiedades
        public int Codigo { get; }
        public bool Activo { get; set; }

        // Relaciones
        public string IsbnDocumento { get; set; }  // Clave foránea
        public Documento Documento { get; set; }    // Documento asociado

        public Ejemplar(int cod)
        {
            Codigo = cod;
            Activo = true;
        }
        //public List<Prestamo> Prestamos { get; set; }

        // Métodos 
        /*public bool EstaPrestado()
        {
            return Prestamos?.Any(p => p.Estado == EstadoPrestamo.EnProceso) ?? false;
        }*/
    }
}
