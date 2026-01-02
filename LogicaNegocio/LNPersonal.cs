using System;
using System.Collections.Generic;
using System.Linq;
using ModeloDominio;

namespace LogicaNegocio
{
    //Clase abstracta con la lógica comun para los dos tipos de personales
    public abstract class LNPersonal : ILNPersonal
    {
        //Atributo
        protected Personal personal;

        //Propiedad
        public Personal Personal { get { return personal; } }

        //PRE: personal != null 
        //POST: se inicializa this.personal con el personal porporcionado, en caso de ser null se lanza excepcion
        public LNPersonal(Personal personal)
        {
            if (personal == null)
            {
                throw new ArgumentNullException("El personal no puede ser nulo");
            }
            this.personal = personal;

        }

        //Método estático para obtener un personal en el formulario - Por ser estático da error si lo intentas poner en la interfaz
        //PRE: nombre y contraseña distinto de null y válidos, tipo puede ser o personalSala o personalAdquisiciones
        //POST: Si existe un Personal con ese nombre y tipo, y la contraseña coincide retorna el objeto Personal logueado, si no existe o la contraseña es incorrecta retorna null. No modifica ningún dato del sistema
        public static Personal Login(string nombre, string contraseña, TipoPersonal tipo)
        {
            Personal personal = Persistencia.Persistencia
               .GetPersonales()
               .FirstOrDefault(p =>
                   p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)
                   && p.Tipo == tipo);

            if (personal == null) { return null; }
            if (!personal.ValidarContraseña(contraseña))
                return null;
            return personal;
        }


        //Operaciones comunes a usuarios
        //PRE: u distinto de null y u.Dni no null ni vacío. El usuario que ejecuta la operacion debe tener permisos, puede ser cualquier tipo de personal
        //POST: si u no existe se crea un nuevo usuario en la BD con DadoAlta=true; 
        //      si u existe y esta activo se lanza excepcion de que ya existe uno dado de alta con el mismo dni
        //      si u existe y esta inactivo se reactiva cambiando DadoAlta=true y se actualiza el nombre por si hubo algún cambi
        //      se sigue conmprobando que u no sea nulo ni vacio, en caso contrario se lanza excepción
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

            // Si existe pero está inactivo
            if (existente != null && !existente.DadoAlta)
            {
                existente.Nombre = u.Nombre;
                existente.DadoAlta = true;
                Persistencia.Persistencia.UpdateUsuario(existente);
            }
            else
            {
                Persistencia.Persistencia.AltaUsuario(u);
            }
        }

        //PRE: usuario no nulo y debe existir en el sistema
        //POST: El usuario se actualiza en la BD con los nuevos datos proporcionados. Si algo falla se lanza excepcion
        public void ModificarUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            bool resultado = Persistencia.Persistencia.UpdateUsuario(usuario);

            if (!resultado)
                throw new InvalidOperationException("No se pudo actualizar el usuario");
        }

        //PRE: u no nulo y debe existir en el sistema, además debe estar activo
        //POST: u queda marcado como inactivo (dadoAlta = false) y se actualiza en la BD
        public void BajaUsuario(Usuario u)
        {
            if (u == null)
                throw new ArgumentNullException("El usuario no puede ser null");

            Usuario existente = Persistencia.Persistencia.GetUsuario(new Usuario(u.Dni));
            if (existente == null)
                throw new InvalidOperationException($"No existe un usuario con DNI {u.Dni}");

            if (!existente.DadoAlta)
                throw new InvalidOperationException($"El usuario ya está dado de baja");

            existente.DadoAlta = false;
            Persistencia.Persistencia.UpdateUsuario(existente);
        }

        //PRE: dni no null ni vacío
        //POST: si existe un usuario con dicho dni retorna el Usuario, si no devuelve null. No modifica nada en el sistema
        public Usuario GetUsuario(string dni)
        {
            return Persistencia.Persistencia.GetUsuario(dni);
        }

        //PRE:
        //POST: Retorna una lista con todos los usuarios donde DadoAlta = true. Si no hay usuarios activos, retorna lista vacía
        public List<Usuario> GetUsuariosActivos()
        {
            List<Usuario> todos = Persistencia.Persistencia.GetUsuarios();
            return todos.Where(u => u.DadoAlta).ToList();
        }

        //PRE:
        //POST: Retorna una lista con TODOS los usuarios (activos e inactivos) Si no hay usuarios, retorna lista vacía
        public List<Usuario> GetTodosUsuarios()
        {
            return Persistencia.Persistencia.GetUsuarios();
        }

        //PRE: dni no null y el usuario con ese dni debe existir
        //POST: Retorna una lista con todos los ejemplares actualmente prestados al usuario (préstamos en estado enProceso). Si el usuario no tiene préstamos activos, retorna lista vacía
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

        //PRE: dni no null y debe existir el usuario con dicho dni
        //POST: Devuelve true si el usuario tiene al menos un préstamo en estado enProceso y con Caducado() = true, false en caso contrario
        public bool TieneDocumentosFueraPlazo(string dni)
        {
            List<Prestamo> prestamosUsuario = Persistencia.Persistencia.GetPrestamosPorUsuario(dni);

            foreach (Prestamo p in prestamosUsuario)
            {
                if (p.Estado == EstadoPrestamo.enProceso && p.Caducado())
                {
                    return true;
                }
            }
            return false;
        }

        //PRE:  dni no null y debe existir el usuario con dicho dni
        //POST: Retorna una lista con TODOS los préstamos del usuario (activos, finalizados, etc.). Si el usuario no tiene préstamos, retorna lista vacía
        public List<Prestamo> GetPrestamosPorUsuario(string dni)
        {
            return Persistencia.Persistencia.GetPrestamosPorUsuario(dni);
        }

        //PRE: dni no null y debe existir el usuario con dicho dni
        //POST: Retorna el número de préstamos del usuario en estado enProceso.  Si no tiene préstamos activos, retorna 0
        public int GetNumPrestamosActivosPorUsuario(string dni)
        {
            return Persistencia.Persistencia.GetPrestamosPorUsuario(dni).Count(p => p.Estado == EstadoPrestamo.enProceso); ;
        }

        //PRE: dni no null y debe existir el usuario con dicho dni
        //POST: Retorna el número total de ejemplares prestados al usuario en los últimos 30 días (desde DateTime.Now.AddMonths(-1))
        //      Cuenta ejemplares de todos los préstamos realizados en ese período(independientemente del estado). Si no tiene préstamos en ese período, retorna 0
        public int GetNumEjemplaresUltimoMes(string dni)
        {
            DateTime unMesAtras = DateTime.Now.AddMonths(-1);
            var prestamos = GetPrestamosPorUsuario(dni);

            int total = 0;
            foreach (var prestamo in prestamos.Where(p => p.FechaPrestamo >= unMesAtras))
            {
                var ejemplares = Persistencia.Persistencia.GetEjemplaresDePrestamo(prestamo.Id);
                total += ejemplares.Count;
            }
            return total;
        }

        //PRE:  dni no null y debe existir el usuario con dicho dni
        //POST: Retorna el número de préstamos del usuario en estado enProceso y con FechaDevolucion < DateTime.Now.  Si no tiene préstamos vencidos, retorna 0
        public int GetNumPrestamosVencidos(string dni)
        {
            var prestamos = GetPrestamosPorUsuario(dni);
            return prestamos.Count(p => p.Estado == EstadoPrestamo.enProceso && p.FechaDevolucion < DateTime.Now);
        }

        //PRE:  dni no null 
        //POST: Si existe un Personal con ese DNI: retorna el objeto Personal. Si no, retorna null
        public Personal GetPersonal(string dni)
        {
            return Persistencia.Persistencia.GetPersonal(dni);
        }
















        /*
        PRE: codigoEjemplar > 0
        POST: devuelve true si el ejemplar está disponible para préstamo (existe, está activo
              y no está actualmente prestado), false en caso contrario
        */
        public bool EjemplarDisponibleParaPrestamo(int codigoEjemplar)
        {
            Ejemplar ejemplar = Persistencia.Persistencia.GetEjemplar(new Ejemplar(codigoEjemplar));

            if (ejemplar == null || !ejemplar.Activo)
                return false;

            // Verificar si está en un préstamo activo
            List<Prestamo> prestamosDelEjemplar = Persistencia.Persistencia.GetPrestamosPorEjemplar(codigoEjemplar);

            foreach (Prestamo p in prestamosDelEjemplar)
            {
                if (p.Estado == EstadoPrestamo.enProceso)
                {
                    // Verificar si este ejemplar específicamente no ha sido devuelto
                    var prestamoEjemplar = Persistencia.Persistencia.GetPrestamoEjemplar(p.Id, codigoEjemplar);
                    if (prestamoEjemplar != null && prestamoEjemplar.FechaDevolucion == DateTime.MinValue)
                    {
                        return false; // Está prestado y no devuelto
                    }
                }
            }

            return true;
        }


        // PRE: isbn != null y no vacío.
        // POST: Devuelve una lista con todos los préstamos asociados a ejemplares del documento indicado.
        //       No se repiten préstamos. La lista puede estar vacía si el documento no tiene préstamos.
        public List<Prestamo> GetPrestamosPorDocumento(string isbn)
        {
            List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);

            List<Prestamo> prestamos = new List<Prestamo>();
            HashSet<int> idsPrestamosAgregados = new HashSet<int>();

            foreach (Ejemplar ejemplar in ejemplares)
            {
                List<Prestamo> prestamosDelEjemplar =
                    Persistencia.Persistencia.GetPrestamosPorEjemplar(ejemplar.Codigo);

                foreach (Prestamo p in prestamosDelEjemplar)
                {
                    if (!prestamos.Contains(p))
                    {
                        prestamos.Add(p);
                    }
                }
            }
            return prestamos;
        }

    }
}
