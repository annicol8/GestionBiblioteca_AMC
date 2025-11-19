
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Prestamo
    {
        private int id;
        private DateTime fechaPrestamo;
        private DateTime fechaDevolucion;
        private EstadoPrestamo estado;
        private string dniUsuario;
        private string dniPersonal;
        public List<Ejemplar> prestamoEjemplares { get; set; } 

        public int Id { get; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }

        public EstadoPrestamo Estado; //ver si lo ponemos aqui o se obtiene directamente en la tabla Prestamo_Ejemplar
        public string DniUsuario { get; }
        public string DniPersonal { get; }

        public Prestamo()
        {
            this.FechaPrestamo = DateTime.Now;
            estado = EstadoPrestamo.enProceso;
            prestamoEjemplares = new List<Ejemplar>();
        }

        public Prestamo(string dniUsuario, string dniPersonal)
        {
            this.FechaPrestamo = DateTime.Now;
            this.dniUsuario = dniUsuario;
            this.dniPersonal = dniPersonal;
        }

    }
}
