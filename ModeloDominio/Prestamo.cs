
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
        //Atributos
        private int id;
        private DateTime fechaPrestamo;
        private DateTime fechaDevolucion;
        private EstadoPrestamo estado;
        private string dniUsuario;
        private string dniPersonal;

        //Propiedades
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

        //PRE: parámetros de entrada no nulos, el id debe ser un entero positivo, fechaPrestamo una fehca válida al igual que fechaDevolucion pero además fechaDevolucion >= fechaPrestamo,
        //     estado puede ser o finalizado o enProceso y tanto el dniPersonal como dniusuario deben ser válidos
        //POST: se crea una instancia de Prestamo con todos los atributos inicializados con los valores proporcionados
        public Prestamo(int id, DateTime fechaPrestamo, DateTime fechaDevolucion, EstadoPrestamo estado, string dniPersonal, string dniUsuario) //List<Ejemplar> prestamoEjemplares si eso añadir este arg
        {
            Id = id;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
            Estado = estado;
            DniPersonal = dniPersonal;
            DniUsuario = dniUsuario;
        }

        //  Constructor para préstamo nuevo 
        //PRE: los dnis deben ser no nulos y válidos al igual que la fechaDevolucion, además fechaDevolucion > DateTime.Now
        //POST: se crea una instancia a Prestamo pero con la fecha de prestamo la fecha actual y el estado como enProceso
        public Prestamo(int id, string dniUsuario, string dniPersonal, DateTime fechaDevolucion): this(id)
        {
            this.fechaPrestamo = DateTime.Now;
            this.fechaDevolucion = fechaDevolucion;
            this.estado = EstadoPrestamo.enProceso;
            this.dniUsuario = dniUsuario;
            this.dniPersonal = dniPersonal;
        }

        //PRE: fechaDevolucion y Estado deben estar inicializados
        //POST: devuelve true si DateTime.Now > fechaDevolucion && Estado == enProceso, false en caso contrario
        public bool Caducado()
        {
            return DateTime.Now > fechaDevolucion && Estado == EstadoPrestamo.enProceso;
        }

        // Constructor búsqueda
        //PRE: id un entero positivo
        //POST: solo id queda inicializado 
        public Prestamo(int id)
        {
            this.id = id;
        }

        //PRE:
        //POST: devuelve true si other no es nulo y los id coinciden, false en caso contrario
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
