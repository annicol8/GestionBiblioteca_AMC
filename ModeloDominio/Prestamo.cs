
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
        

        public int Id { 
            get { return id; } set { id = value; }
        }
        public DateTime FechaPrestamo { 
            get { return fechaPrestamo; } set { fechaPrestamo = value; }
        }
        public DateTime FechaDevolucion { 
            get { return fechaDevolucion; } set {fechaDevolucion = value; }
        }

        public EstadoPrestamo Estado { 
            get { return estado; } set { estado = value; }
        } //ver si lo ponemos aqui o se obtiene directamente en la tabla Prestamo_Ejemplar
        public string DniUsuario { 
            get { return dniUsuario; } set { dniUsuario = value; }
        }
        public string DniPersonal { 
            get { return dniPersonal; } set {dniPersonal = value; }
        }

       
        public Prestamo(int id, DateTime fechaPrestamo, DateTime fechaDevolucion, EstadoPrestamo estado, string dniPersonal, string dniUsuario) //List<Ejemplar> prestamoEjemplares si eso añadir este arg
        {
            Id = id;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
            Estado = estado;
            DniPersonal = dniPersonal;
            DniUsuario = dniUsuario;
            //this.prestamoEjemplares = new List<Ejemplar>();
        }

        //  Constructor para préstamo nuevo 
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
