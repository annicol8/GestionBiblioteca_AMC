using System;
using System.Collections.Generic;
using System.Linq;
using ModeloDominio;

namespace LogicaNegocio
{
    public class LNPAdq : LNPersonal, ILNPAdq
    {
        //PRE: personal no nulo y debe ser de tipo personalAdquisiciones
        //POST: Se inicializa la clase llamando al constructor base. Si es null, se lanza excepción desde la clase base
        public LNPAdq(PersonalAdquisiciones personal) : base(personal)
        {

        }

        //PRE: libro no null y libro.Isbn no null ni vacío. El ISBN no debe existir previamente en el sistema y el personal que ejecuta debe ser PersonalAdquisiciones 
        //POST: El libro queda registrado en la BD. Se asocia al trabajador actual. Retorna true si la operación fue exitosa si no lanza excepcion.
        public bool AltaLibroPapel(LibroPapel libro)
        {
            if (libro == null)
                throw new ArgumentNullException("El libro no puede ser null");

            if (string.IsNullOrWhiteSpace(libro.Isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            Documento existente = Persistencia.Persistencia.GetDocumento(libro.Isbn);
            if (existente != null)
                throw new InvalidOperationException("Ya existe un documento con ese ISBN");

            return Persistencia.Persistencia.AltaLibroPapel(libro);
        }

        //PRE: audioLibro no null y audioLibro.Isbn no null ni vacio. El ISBN no debe existir previamente en el sistema y el personal que ejecuta debe ser PersonalAdquisiciones
        //POST: El libro queda registrado en la BD. Se asocia al trabajador actual. Retorna true si la operación fue exitosa si no lanza excepcion.
        public bool AltaAudioLibro(AudioLibro audioLibro)
        {
            if (audioLibro == null)
                throw new ArgumentNullException("El audiolibro no puede ser null");

            if (string.IsNullOrWhiteSpace(audioLibro.Isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            Documento existente = Persistencia.Persistencia.GetDocumento(audioLibro.Isbn);
            if (existente != null)
                throw new InvalidOperationException("Ya existe un documento con ese ISBN");

            return Persistencia.Persistencia.AltaAudioLibro(audioLibro);
        }

        //PRE: isbn no null ni vacio, el documento con dicho isbn debe existir en el sistema. Ninguno de los ejemplares activos del documento puede estar actualmente prestado (estado enProceso)
        //      El personal que ejecuta debe ser PersonalAdquisiciones
        //POST: Todos los ejemplares del documento quedan marcados como inactivos (Activo = false). El documento se elimina de la BD
        //      Retorna true si la operación fue exitosa. Si no lanza excepcion
        public bool BajaDocumento(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            Documento doc = Persistencia.Persistencia.GetDocumento(isbn);
            if (doc == null)
                throw new InvalidOperationException("El documento no existe");

            List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);

            foreach (Ejemplar ej in ejemplares)
            {
                if (ej.Activo && EstaPrestadoEjemplar(ej.Codigo))
                {
                    throw new InvalidOperationException(
                        $"No se puede eliminar el documento porque el ejemplar {ej.Codigo} está actualmente prestado. Debe esperar a que se devuelva."
                    );
                }
            }

            // Marcar todos los ejemplares como inactivos (baja lógica)
            foreach (Ejemplar ej in ejemplares)
            {
                if (ej.Activo)  // Solo si está activo
                {
                    ej.Activo = false;
                    Persistencia.Persistencia.UpdateEjemplar(ej);
                }
            }

            // Eliminar el documento de la base de datos (baja física)
            if (doc is LibroPapel)
            {
                return Persistencia.Persistencia.BajaLibroPapel((LibroPapel)doc);
            }
            else if (doc is AudioLibro)
            {
                return Persistencia.Persistencia.BajaAudioLibro((AudioLibro)doc);
            }

            return false;
        }



        //PRE: isbnDocumneto no null ni vacio, el docuemnto debe existir en el sistema.
        //     El codigo debe ser un entero positivo y no existir previamente. El personal debe ser de adquisiciones
        //POST: El ejemplar queda registrado en la BD con:  Codigo = codigo / Activo = true / IsbnDocumento = isbnDocumento / DniPAdq = DNI del personal actual
        //      Retorna true si la operación fue exitosa. Si no lanza excepcion
        public bool AltaEjemplar(int codigo, string isbnDocumento)
        {
            if (string.IsNullOrWhiteSpace(isbnDocumento))
                throw new ArgumentException("El ISBN no puede estar vacío");

            Documento doc = Persistencia.Persistencia.GetDocumento(isbnDocumento);
            if (doc == null)
                throw new InvalidOperationException("El documento no existe");

            Ejemplar existente = Persistencia.Persistencia.GetEjemplar(new Ejemplar(codigo));
            if (existente != null)
                throw new InvalidOperationException("Ya existe un ejemplar con ese código");

            PersonalAdquisiciones pa = (PersonalAdquisiciones)personal;
            Ejemplar nuevoEjemplar = new Ejemplar(codigo, true, isbnDocumento, pa.Dni);
            return Persistencia.Persistencia.AltaEjemplar(nuevoEjemplar);
        }

        //PRE: El ejemplar con ese código debe existir en el sistema y debe estar activo. El personal que ejecuta debe ser PersonalAdquisiciones
        //POST: El ejemplar queda marcado como inactivo: Activo = false. Se actualiza en la BD. Retorna true si la operación fue exitosa
        public bool BajaEjemplar(int codigo)
        {
            Ejemplar ej = Persistencia.Persistencia.GetEjemplar(new Ejemplar(codigo));
            if (ej == null)
                throw new InvalidOperationException("El ejemplar no existe");
            /* ESta restricción es verdad????
            if (EstaEjemplarPrestado(codigo))
                throw new InvalidOperationException("No se puede dar de baja un ejemplar prestado");
            */
            if (!ej.Activo)
                throw new InvalidOperationException("El ejemplar ya está dado de baja");

            ej.Activo = false;
            return Persistencia.Persistencia.UpdateEjemplar(ej);
        }



        //PRE:
        //POST: Retorna true si el ejemplar está asociado a algún préstamo en estado enProceso, false si el ejemplar no está prestado o no existe
        public bool EstaPrestadoEjemplar(int codigo)
        {
            List<Prestamo> prestamos = Persistencia.Persistencia.GetPrestamosPorEjemplar(codigo);
            return prestamos.Any(p => p.Estado == EstadoPrestamo.enProceso);
        }

        //PRE: ibsn no null y el documento debe tener al menos un ejemplar registrado sino excepcion
        //POST: Retorna true si existe al menos un ejemplar del documento que NO está prestado, false si todos los ejemplares están prestados
        public bool HayEjemplaresDisponibles(string isbn)
        {
            List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);
            if (ejemplares.Count == 0)
                throw new Exception("El documento no tiene ejemplares registrados.");

            return ejemplares.Any(ej => !EstaPrestadoEjemplar(ej.Codigo));
        }

        //PRE:
        //POST: Retorna el ISBN del documento incluido en el mayor número de préstamos en los últimos 30 días (cada préstamo cuenta 1 vez por documento único, sin importar cuántos ejemplares del mismo documento incluya). Si no hay préstamos en el último mes, retorna null
        public string GetDocumentoMasPrestadoUltimoMes()
        {
            DateTime desde = DateTime.Now.AddMonths(-1);
            var prestamos = Persistencia.Persistencia.GetPrestamos()
                .Where(p => p.FechaPrestamo >= desde)
                .ToList();

            var contador = new Dictionary<string, int>();

            foreach (var p in prestamos)
            {
                var ejemplares = Persistencia.Persistencia.GetEjemplaresDePrestamo(p.Id);

                var isbnsUnicos = ejemplares
                    .Select(ej => ej.IsbnDocumento)
                    .Distinct()
                    .ToList();

                foreach (string isbn in isbnsUnicos)
                {
                    if (contador.ContainsKey(isbn))
                        contador[isbn]++;
                    else
                        contador[isbn] = 1;
                }
            }

            if (contador.Count == 0)
                return null;

            return contador
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .FirstOrDefault();
        }

        //PRE:
        //POST: Retorna una lista con TODOS los documentos de la biblioteca (LibroPapel y AudioLibro). Si no hay documentos: retorna lista vacía
        public List<Documento> getDocumentos()
        {
            return Persistencia.Persistencia.GetTodosDocumentos();
        }

        //PRE: isbn no null
        //POST: Retorna una lista con todos los ejemplares del documento especificado
        //      Si el documento no tiene ejemplares o no exist: retorna lista vacía
        public List<Ejemplar> ejemplaresPorDocumento(string isbn)
        {
            return Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);
        }

        //PRE: isbn no null y no vacío
        //POST: Si hay ejemplares activos disponibles, devuelve null
        //      Si todos los ejemplares activos están prestados, devuelve la fecha más próxima de devolución
        //      Si el documento no existe, no tiene ejemplares activos, devuelve null
        public DateTime? GetFechaProximaDisponibilidad(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            Documento doc = Persistencia.Persistencia.GetDocumento(isbn);
            if (doc == null)
                return null;

            List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);
            if (ejemplares.Count == 0)
                return null;

            bool hayDisponible = false;
            foreach (Ejemplar e in ejemplares)
            {
                if (e.Activo && !EstaPrestadoEjemplar(e.Codigo))
                {
                    hayDisponible = true;
                    break;
                }
            }

            if (hayDisponible)
                return null;

            DateTime? fechaMasProxima = null;
            List<Prestamo> prestamosDocumento = GetPrestamosPorDocumento(isbn);

            foreach (Prestamo prestamo in prestamosDocumento)
            {
                if (prestamo.Estado != EstadoPrestamo.enProceso)
                    continue;

                if (!fechaMasProxima.HasValue || prestamo.FechaDevolucion < fechaMasProxima.Value)
                {
                    fechaMasProxima = prestamo.FechaDevolucion;
                }
            }

            return fechaMasProxima;
        }

    }

}
