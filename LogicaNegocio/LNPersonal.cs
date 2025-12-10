/*using System;
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
       


    }
}
*/
using System;
using System.Collections.Generic;
using System.Linq;
using ModeloDominio;

namespace LogicaNegocio
{
    public abstract class LNPersonal : ILNPersonal
    {
        protected Personal personal;

        public Personal Personal
        {
            get { return personal; }
        }

        protected LNPersonal(Personal personal)
        {
            if (personal == null)
                throw new ArgumentNullException(nameof(personal), "El personal no puede ser nulo");
            
            this.personal = personal;
        }

        public void AltaUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo");
            
            if (string.IsNullOrWhiteSpace(usuario.Dni))
                throw new ArgumentException("El DNI del usuario no puede estar vacío");
            
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new ArgumentException("El nombre del usuario no puede estar vacío");

            Usuario existente = Persistencia.Persistencia.GetUsuario(usuario.Dni);
            if (existente != null && existente.DadoAlta)
                throw new InvalidOperationException($"Ya existe un usuario activo con DNI {usuario.Dni}");

            Persistencia.Persistencia.AltaUsuario(usuario);
        }

        public void BajaUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo");

            Usuario existente = Persistencia.Persistencia.GetUsuario(usuario.Dni);
            if (existente == null)
                throw new InvalidOperationException($"No existe un usuario con DNI {usuario.Dni}");
            
            if (!existente.DadoAlta)
                throw new InvalidOperationException($"El usuario con DNI {usuario.Dni} ya está dado de baja");

            existente.actualizarAlta(false);
            Persistencia.Persistencia.UpdateUsuario(existente);
        }

        public Usuario GetUsuario(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI no puede estar vacío");

            return Persistencia.Persistencia.GetUsuario(dni);
        }

        public List<Usuario> GetUsuariosActivos()
        {
            List<Usuario> todosUsuarios = Persistencia.Persistencia.GetTodosUsuarios();
            return todosUsuarios.Where(u => u.DadoAlta).ToList();
        }

        public List<Usuario> GetTodosUsuarios()
        {
            return Persistencia.Persistencia.GetTodosUsuarios();
        }

        public List<Ejemplar> GetEjemplaresPrestadosPorUsuario(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI no puede estar vacío");

            Usuario usuario = GetUsuario(dni);
            if (usuario == null)
                throw new InvalidOperationException($"No existe un usuario con DNI {dni}");

            List<Prestamo> prestamos = Persistencia.Persistencia.GetPrestamosPorUsuario(dni);
            List<Ejemplar> ejemplaresPrestados = new List<Ejemplar>();

            foreach (Prestamo prestamo in prestamos)
            {
                if (prestamo.Estado == EstadoPrestamo.EnProceso)
                {
                    foreach (var ejemplar in prestamo.Ejemplares)
                    {
                        if (ejemplar.Value == null)
                        {
                            ejemplaresPrestados.Add(ejemplar.Key);
                        }
                    }
                }
            }

            return ejemplaresPrestados;
        }

        public bool UsuarioTieneDocumentosFueraDePlazo(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI no puede estar vacío");

            Usuario usuario = GetUsuario(dni);
            if (usuario == null)
                throw new InvalidOperationException($"No existe un usuario con DNI {dni}");

            List<Prestamo> prestamos = Persistencia.Persistencia.GetPrestamosPorUsuario(dni);
            DateTime fechaActual = DateTime.Now;

            foreach (Prestamo prestamo in prestamos)
            {
                if (prestamo.Estado == EstadoPrestamo.EnProceso)
                {
                    foreach (var ejemplar in prestamo.Ejemplares)
                    {
                        if (ejemplar.Value == null)
                        {
                            Documento documento = Persistencia.Persistencia.GetDocumentoPorIsbn(ejemplar.Key.IsbnDocumento);
                            DateTime fechaLimite = prestamo.FechaPrestamo.AddDays(documento.DiasPrestamoPermitidos());
                            
                            if (fechaActual > fechaLimite)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}

