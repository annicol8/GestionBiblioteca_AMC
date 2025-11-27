
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
        private List<Ejemplar> prestamoEjemplares;
        

        public int Id { get; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }

        public EstadoPrestamo Estado; //ver si lo ponemos aqui o se obtiene directamente en la tabla Prestamo_Ejemplar
        public string DniUsuario { get; }
        public string DniPersonal { get; }
        public List<Ejemplar> PrestamoEjemplares { get; set; }

        public Prestamo()
        {
            this.FechaPrestamo = DateTime.Now;
            estado = EstadoPrestamo.enProceso;
            prestamoEjemplares = new List<Ejemplar>();
        }

        
        public Prestamo(int id, DateTime fechaPrestamo, DateTime fechaDevolucion, EstadoPrestamo estado, string dniPersonal, string dniUsuario, List<Ejemplar> prestamoEjemplares)
        {
            this.id = id;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucion = fechaDevolucion;
            this.estado = estado;
            this.dniPersonal = dniPersonal;
            this.dniUsuario = dniUsuario;
            this.prestamoEjemplares = new List<Ejemplar>();
        }

    }
}
