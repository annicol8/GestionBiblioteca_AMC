using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;


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
            this.estado = estado;
            this.dniPersonal = dniPersonal;
            this.dniUsuario = dniUsuario;
            this.listaEjemplares = ejemplarPrestado;
        }

        

        public int Id { get; }
        public DateTime FechaPrestamo { get; }
        public DateTime FechaDevolucion { get;  }
        public EstadoPrestamo EstadoPrestamo { get; }
        public string PersonalSala {  get; }
        public string DniUsuario { get; }
    }
}


