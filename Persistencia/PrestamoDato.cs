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
        private DateTime fechaPrestamo;
        private DateTime fechaDevolucion;
        private EstadoPrestamo estado;
        private string dniUsuario;
        private string dniPersonal;


        public PrestamoDato(int id, DateTime fechaPrestamo, DateTime fechaDevolucion, EstadoPrestamo estado, string dniUsuario, string dniPersonal) : base(id)
        {
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
            Estado = estado;
            DniUsuario = dniUsuario;
            DniPersonal = dniPersonal;
        }

        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public EstadoPrestamo Estado { get; private set; }
        public string DniUsuario { get; private set; }
        public string DniPersonal{  get; private set; }
        
        
    }
}


