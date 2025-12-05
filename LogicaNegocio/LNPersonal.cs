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
    public abstract class LNPersonal : ILNPersonal
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
                Persistencia.Persistencia.BajaUsuario(usuarioBD);
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
            //List<Usuario> activos = new List<Usuario>();
            return todos.Where(u => u.DadoAlta).ToList();
            /* //antes de usar LINQ
             * foreach (var usuario in todos)
            {
                if (usuario.DadoAlta)
                {
                    activos.Add(usuario);
                }
            }
            return activos;
            */
        }

        public List<Usuario> GetTodosUsuarios()
        {
            return Persistencia.Persistencia.GetUsuarios();
        }


        /*
        public bool HayEjemplaresDisponibles(string isbn)
        {
            List<Ejemplar> listaEjemplares = Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);
            foreach (Ejemplar e in listaEjemplares)
            {
                if (e.Activo && !EstaEjemplarPrestado)
                {
                    return true;
                }
            }
            return false;
        }

        protected bool EstaEjemplarPrestado(int codEj)
        {
            List<PrestamoEjemplarDato> prestamos = Persistencia.Persistencia.GetPrestamosPorEjemplar(codigoEjemplar);
            DateTime hoy = DateTime.Now;

            foreach (PrestamoEjemplarDato ep in prestamos)
            {
                Prestamo p = Persistencia.Persistencia.GetPrestamo(new Prestamo(ep.IdPrestamo));
                if (p != null && p.Estado == EstadoPrestamo.enProceso && ep.FechaDevolucion >= hoy)
                    return true;
            }
            return false;
        }
        */


    }
}
