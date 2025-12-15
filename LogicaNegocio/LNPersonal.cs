using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public LNPersonal(Personal personal)
        {
            if (personal == null)
            {
                throw new ArgumentNullException("El personal no puede ser nulo");
            }
            this.personal = personal;
        }
        
        //Método estático para obtener un personal en el formulario
        //Por ser estático da error si lo intentas poner en la interfaz
        public static Personal Login(string nombre, TipoPersonal tipo)
        {
            
            return Persistencia.Persistencia
                .GetPersonales()
                .FirstOrDefault(p =>
                    p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)
                    && p.Tipo == tipo);
        }
        

        //Operaciones comunes a usuarios
        public void AltaUsuario(Usuario u)
        {
            if (u == null)
                throw new ArgumentNullException("El usuario no puede ser null");
            if (string.IsNullOrWhiteSpace(u.Dni))
                throw new ArgumentException("El DNI no puede estar vacío");
            
            // Verificar si ya existe
            Usuario existente = Persistencia.Persistencia.GetUsuario(new Usuario(u.Dni));
            if (existente != null && existente.DadoAlta)
                throw new InvalidOperationException($"Ya existe un usuario activo con DNI {u.Dni}");

            // Si existe pero está inactivo, reactivarlo
            if (existente != null && !existente.DadoAlta)
            {
                existente.Nombre = u.Nombre;  // Actualizar el nombre por si cambió
                existente.DadoAlta = true;
                Persistencia.Persistencia.UpdateUsuario(existente);
            }
            else
            {
                // No existe, crear nuevo
                Persistencia.Persistencia.AltaUsuario(u);
            }
        }

        public void BajaUsuario(Usuario u)
        {
            if (u == null)
                throw new ArgumentNullException("El usuario no puede ser null");

            Usuario existente = Persistencia.Persistencia.GetUsuario(new Usuario(u.Dni));
            if (existente == null)
                throw new InvalidOperationException($"No existe un usuario con DNI {u.Dni}");

            if (!existente.DadoAlta)
                throw new InvalidOperationException($"El usuario ya está dado de baja");

            existente.DadoAlta= false;
            Persistencia.Persistencia.UpdateUsuario(existente);
        }

        public Usuario GetUsuario(string dni)
        {
             return Persistencia.Persistencia.GetUsuario(dni);
        }

        public List<Usuario> GetUsuariosActivos()
        {
            List<Usuario> todos = Persistencia.Persistencia.GetUsuarios();
            return todos.Where(u => u.DadoAlta).ToList();
        }

        public List<Usuario> GetTodosUsuarios() 
        {
            return Persistencia.Persistencia.GetUsuarios();
        }

        public List<Ejemplar> GetEjemplaresPrestadosPorUsuario(string dni)
        {
            List<Ejemplar> ejemplaresPrestados = new List<Ejemplar>();  
            List<Prestamo> prestamosUsuario = Persistencia.Persistencia.GetPrestamosPorUsuario(dni);

            foreach (Prestamo p in prestamosUsuario)
            {
                if (p.Estado == EstadoPrestamo.enProceso)
                {
                    List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresDePrestamo(p.Id);
                    ejemplaresPrestados.AddRange(ejemplares);
                }
            }
            return ejemplaresPrestados;
        }

        public bool TieneDocumentosFueraPlazo(string dniUsuario)
        {
            List<Prestamo> prestamosUsuario = Persistencia.Persistencia.GetPrestamosPorUsuario(dniUsuario);
            
            foreach(Prestamo p in prestamosUsuario)
            {
                if (p.Estado == EstadoPrestamo.enProceso && p.Caducado())
                {
                    return true;
                }
            }
            return false;
        }

        

    }
}
