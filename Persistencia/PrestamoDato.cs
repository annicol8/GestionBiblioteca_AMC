using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistencia
{
    internal class PrestamoDato : Entity<int>
    {
        //Atributos
        private int id;
        private DateTime fechaPrestamo;
        private DateTime fechaDevolucion;
        private EstadoPrestamo estado;
        private string dniUsuario;
        private string dniPersonal;
        private List<Ejemplar> listaEjemplares;


        public PrestamoDato(int id, DateTime fechaPrestamo, DateTime fechaDevolucion, EstadoPrestamo estado, String dniPersonal, String dniUsuario, List<Ejemplar> ejemplarPrestado) : base(id)
        {
            this.id = id;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucion = fechaDevolucion;
            this.EstadoPrestamo = estado;
            this.dniPersonal = dniPersonal;
            this.dniUsuario = dniUsuario;
            this.listaEjemplares = ejemplarPrestado;
        }

        public int getId() { return id; }
        public DateTime getFechaPrestamo() { return fechaPrestamo; }
        public DateTime getFechaDevolucion() { return fechaDevolucion; }
        public EstadoPrestamo getEstadoPrestamo() { return estado; }
        public string getPersonalSala() { return this.dniPersonal; }
        public string getDniUsuario() { return this.dniUsuario; }
    }
}


