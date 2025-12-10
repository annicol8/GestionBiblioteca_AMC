
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Prestamo: IEquatable<Prestamo>
    {
        private int id;
        private DateTime fechaPrestamo;
        private DateTime fechaDevolucion;
        private EstadoPrestamo estado;
        private string dniUsuario;
        private string dniPersonal;
        //private List<Ejemplar> prestamoEjemplares;
        

        public int Id { get; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }

        public EstadoPrestamo Estado { get; set; } //ver si lo ponemos aqui o se obtiene directamente en la tabla Prestamo_Ejemplar
        public string DniUsuario { get; }
        public string DniPersonal { get; }

       
        public Prestamo(int id, DateTime fechaPrestamo, DateTime fechaDevolucion, EstadoPrestamo estado, string dniPersonal, string dniUsuario) //List<Ejemplar> prestamoEjemplares si eso añadir este arg
        {
            this.id = id;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucion = fechaDevolucion;
            this.estado = estado;
            this.dniPersonal = dniPersonal;
            this.dniUsuario = dniUsuario;
            //this.prestamoEjemplares = new List<Ejemplar>();
        }

        // Constructor para préstamo nuevo 
        public Prestamo(string dniUsuario, string dniPersonal, DateTime fechaDevolucion)
        {
            this.fechaPrestamo = DateTime.Now;
            this.fechaDevolucion = fechaDevolucion;
            this.estado = EstadoPrestamo.enProceso;
            this.dniUsuario = dniUsuario;
            this.dniPersonal = dniPersonal;
        }

        public bool Caducado()
        {
            return DateTime.Now > fechaDevolucion && Estado == EstadoPrestamo.enProceso;
        }

        // Constructor búsquedas
        public Prestamo(int id)
        {
            this.id = id;
        }

        public bool Equals(Prestamo other)
        {
            if (other == null) return false;
            return this.id == other.id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

    }
}
