using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;
using Persistencia;

namespace LogicaNegocio
{
    public class LNPAdq : LNPersonal, ILNPAdq
    {
        public LNPAdq(PersonalAdquisiciones personal) : base(personal)
        {
            
        }


        /*
        public void AltaLibroPapel(LibroPapel lp)
        {
            Persistencia.Persistencia.AltaLibroPapel(lp);
        }

        public void AltaAudioLibro(AudioLibro al)
        //PRE: COMPLETAR
        //POST: Se crea el audiolibro
        {
            Persistencia.Persistencia.AltaAudioLibro(al);
        } 
        public Documento getDocumento(String isbn)
        {
            return Persistencia.Persistencia.GetDocuemnto(isbn);
        }*/

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

       /* public bool BajaDocumento(string isbn)
            //Hacer un método que dé de baja a todos los ejemplares de un libro???
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            Documento doc = Persistencia.Persistencia.GetDocumento(isbn);
            if (doc == null)
                throw new InvalidOperationException("El documento no existe");

            List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);
            foreach (Ejemplar ej in ejemplares)
            {
                if (ej.Activo)
                    throw new InvalidOperationException("No se puede eliminar el documento porque tiene ejemplares activos");
            }
            if (doc is LibroPapel)
                return Persistencia.Persistencia.BajaLibroPapel((LibroPapel)doc);
            else
                return Persistencia.Persistencia.BajaAudioLibro((AudioLibro)doc);
        }
       */

        public bool BajaDocumento(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            Documento doc = Persistencia.Persistencia.GetDocumento(isbn);
            if (doc == null)
                throw new InvalidOperationException("El documento no existe");

            // Obtener todos los ejemplares del documento
            List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);

            // Verificar si hay ejemplares activos prestados
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
        public Documento getDocumento(string isbn)
            //PRE:
            //POST: Si no existe, null; si existe, devuelve el objeto AudLibro o LiPapel
        {
            return Persistencia.Persistencia.GetDocumento(isbn);
        }


        public bool AltaEjemplar(int codigo, string isbnDocumento)
            //Pasarle mejor un objeto ejemplar como parámetro?
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

        public bool BajaEjemplar(int codigo) //Parámetro objeto ejemplar?
            //PRE:
            //POST: El ejemplar con ese código se actualiza en la base de datos (NO se borra)
                  //y se pone su atributo "Activo" a false. Si no existe el ejemplar, excepción
        {
            Ejemplar ej = Persistencia.Persistencia.GetEjemplar(new Ejemplar(codigo));
            if (ej == null)
                throw new InvalidOperationException("El ejemplar no existe");
            /* ESta restricción es verdad????
            if (EstaEjemplarPrestado(codigo))
                throw new InvalidOperationException("No se puede dar de baja un ejemplar prestado");
            */
            ej.Activo = false;
            return Persistencia.Persistencia.UpdateEjemplar(ej);
        }

        public Ejemplar GetEjemplar(int codigo) //paráetro objeto ejemplar??
            //PRE:
            //POST: Si el ejemplar no existe, null; si existe, se devuelve
            
        {
            return Persistencia.Persistencia.GetEjemplar(new Ejemplar(codigo));
        }

        
        public bool EstaPrestadoEjemplar(int codigo)    
            //PRE:
            //POST: true si el ejemplar está presado; false si está disponible
        {
            List<Prestamo> prestamos = Persistencia.Persistencia.GetPrestamosPorEjemplar(codigo);
            return prestamos.Any(p => p.Estado == EstadoPrestamo.enProceso);
        }
        
        public bool HayEjemplaresDisponibles(string isbn) {
            List<Ejemplar> ejemplares = Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);
            if (ejemplares.Count == 0)
                throw new Exception("El documento no tiene ejemplares registrados.");

            return ejemplares.Any(ej => !EstaPrestadoEjemplar(ej.Codigo));
        }
        
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

                foreach (Ejemplar ej in ejemplares)
                {
                    if (contador.ContainsKey(ej.IsbnDocumento))
                        contador[ej.IsbnDocumento]++;
                    else
                        contador[ej.IsbnDocumento] = 1;
                }
            }

            return contador
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .FirstOrDefault();
        }

        public List<Documento> getDocumentos()
        //PRE:
        //POST: todos los documentos de la biblioteca si hay; si no, lista vacía

        //TIene sentido hacerlo si ya se hace en persistencia? No aporta nada
        {
            return Persistencia.Persistencia.GetTodosDocumentos();
        }

        public List<Ejemplar> ejemplaresPorDocumento(string isbn)
            //PRE:
            //POST: ejemplares de un documento si hay; si no, lista vacía

            //TIene sentido hacerlo si ya se hace en persistencia? No aporta nada
        {
            return Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);
        }
        
    }
        //ME FALTA: lo de que si están todos prestados, fecha en la que estará disponible alguno (debería ser devuelto el ejemplar)
}
