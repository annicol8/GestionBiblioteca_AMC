using System;
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


        public DateTime FechaPrestamo
        {
            get { return fechaPrestamo; }
            set { fechaPrestamo = value; }
        }
        public DateTime FechaDevolucion
        {
            get { return fechaDevolucion; }
            set { fechaDevolucion = value; }
        }
        public EstadoPrestamo Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string DniUsuario
        {
            get { return dniUsuario; }
            set { dniUsuario = value; }
        }
        public string DniPersonal
        {
            get { return dniPersonal; }
            set { dniPersonal = value; }
        }
        /*
PRE: id > 0 && dniUsuario != null && dniUsuario != "" && 
     dniPersonal != null && dniPersonal != "" && fechaPrestamo <= fechaDevolucion
POST: crea un nuevo PrestamoDato con los datos proporcionados
*/
        public PrestamoDato(int id, DateTime fechaPrestamo, DateTime fechaDevolucion, EstadoPrestamo estado, string dniUsuario, string dniPersonal) : base(id)
        {
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
            Estado = estado;
            DniUsuario = dniUsuario;
            DniPersonal = dniPersonal;
        }




    }
}


