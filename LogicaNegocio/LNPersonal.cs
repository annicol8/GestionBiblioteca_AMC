using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;
using Persistencia;

namespace LogicaNegocio
{
    //Clase abstracta con la lógica comun para los dos tipos de personales
    public abstract class LNPersonal
    {
        protected Personal personal;

        public Personal Personal { get { return personal; } }
        protected LNPersonal(Personal personal)
        {
            this.personal = personal;
        }

        //Operaciones comunes a usuarios
        public void AltaUsuario(Usuario u)
        {
            if (u == null)
            {
                throw new ArgumentNullException("El usuario no puede ser null");
            }
            Persistencia.Persistencia.AltaUsuario(u);
        }

        public void BajaUsuario(Usuario u)
        {
            if (u == null)
            {
                throw new ArgumentNullException("El usuario no puede ser null");
            }
            Usuario usuarioBD = Persistencia.Persistencia.GetUsuario(u);
            if (usuarioBD != null)
            {
                usuarioBD.DadoAlta = false;
                Persistencia.Persistencia.UpdateUsuario(usuarioBD);
            }
        }

        public Usuario GetUsuario(string dni)
        { 
            Usuario usuarioBusqueda = new Usuario(dni);
            return Persistencia.Persistencia.GetUsuario(usuarioBusqueda);
        }

        public List<Usuario> GetUsuariosActivos()
        {
            List<Usuario> todos = Persistencia.Persistencia.GetUsuarios();
            List<Usuario> activos = new List<Usuario>();
            foreach (var usuario in todos)
            {
                if (usuario.DadoAlta)
                {
                    activos.Add(usuario);
                }
            }
            return activos;
        }

        public List<Usuario> GetTodosUsuarios()
        {
            return Persistencia.Persistencia.GetUsuarios();
        }

        /*
        public bool DocumentosFueraPlazo(string dni)
        {
            List<Prestamo> prestamosUsuario = Persistencia.Persistencia.GetPrestamosPorUsuario(dni);
            DateTime hoy = DateTime.Now;    

            foreach(Prestamo p in prestamosUsuario)
            {
                if (p.Estado == EstadoPrestamo.enProceso)
                {
                    
                }
            }
        }
        */

        //Operraciones comunes a documentos
        public List<Prestamo> GetPrestamosActivosUsuario(strign dni)
        {
            List<Prestamo> todosPrestamos = Persistencia.Persistencia.GetPrestamos();
            List<Prestamo> prestUser = new List<Prestamo>();
            foreach (Prestamo p in todosPrestamos)
            {

            }
        }




    }
}
