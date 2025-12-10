using System;
using System.Collections.Generic;
using System.Linq;
using ModeloDominio;

namespace LogicaNegocio
{
    public class LNPAdq : LNPSala, ILNPAdq
    {
        public LNPAdq(PersonalAdquisiciones personal) : base(personal)
        {
        }

        public void AltaLibroPapel(LibroPapel libro)
        {
            if (libro == null)
                throw new ArgumentNullException(nameof(libro), "El libro no puede ser nulo");

            if (string.IsNullOrWhiteSpace(libro.Isbn))
                throw new ArgumentException("El ISBN del libro no puede estar vacío");

            if (string.IsNullOrWhiteSpace(libro.Titulo))
                throw new ArgumentException("El título del libro no puede estar vacío");

            LibroPapel existente = Persistencia.Persistencia.GetLibroPapel(libro.Isbn);
            if (existente != null)
                throw new InvalidOperationException($"Ya existe un libro con ISBN {libro.Isbn}");

            Persistencia.Persistencia.AltaLibroPapel(libro);
        }

        public void AltaAudioLibro(AudioLibro audioLibro)
        {
            if (audioLibro == null)
                throw new ArgumentNullException(nameof(audioLibro), "El audiolibro no puede ser nulo");

            if (string.IsNullOrWhiteSpace(audioLibro.Isbn))
                throw new ArgumentException("El ISBN del audiolibro no puede estar vacío");

            if (string.IsNullOrWhiteSpace(audioLibro.Titulo))
                throw new ArgumentException("El título del audiolibro no puede estar vacío");

            if (audioLibro.Duracion <= 0)
                throw new ArgumentException("La duración del audiolibro debe ser mayor que cero");

            AudioLibro existente = Persistencia.Persistencia.GetAudioLibro(audioLibro.Isbn);
            if (existente != null)
                throw new InvalidOperationException($"Ya existe un audiolibro con ISBN {audioLibro.Isbn}");

            Persistencia.Persistencia.AltaAudioLibro(audioLibro);
        }

        public void BajaLibroPapel(LibroPapel libro)
        {
            if (libro == null)
                throw new ArgumentNullException(nameof(libro), "El libro no puede ser nulo");

            LibroPapel existente = Persistencia.Persistencia.GetLibroPapel(libro.Isbn);
            if (existente == null)
                throw new InvalidOperationException($"No existe un libro con ISBN {libro.Isbn}");

            Persistencia.Persistencia.BajaLibroPapel(libro);
        }

        public void BajaAudioLibro(AudioLibro audioLibro)
        {
            if (audioLibro == null)
                throw new ArgumentNullException(nameof(audioLibro), "El audiolibro no puede ser nulo");

            AudioLibro existente = Persistencia.Persistencia.GetAudioLibro(audioLibro.Isbn);
            if (existente == null)
                throw new InvalidOperationException($"No existe un audiolibro con ISBN {audioLibro.Isbn}");

            Persistencia.Persistencia.BajaAudioLibro(audioLibro);
        }

        public LibroPapel GetLibroPapel(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            return Persistencia.Persistencia.GetLibroPapel(isbn);
        }

        public AudioLibro GetAudioLibro(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            return Persistencia.Persistencia.GetAudioLibro(isbn);
        }

        public List<Documento> GetTodosDocumentos()
        {
            return Persistencia.Persistencia.GetTodosDocumentos();
        }

        public void AltaEjemplar(Ejemplar ejemplar)
        {
            if (ejemplar == null)
                throw new ArgumentNullException(nameof(ejemplar), "El ejemplar no puede ser nulo");

            if (string.IsNullOrWhiteSpace(ejemplar.Codigo))
                throw new ArgumentException("El código del ejemplar no puede estar vacío");

            if (string.IsNullOrWhiteSpace(ejemplar.IsbnDocumento))
                throw new ArgumentException("El ejemplar debe estar asociado a un documento");

            Ejemplar existente = Persistencia.Persistencia.GetEjemplar(ejemplar.Codigo);
            if (existente != null && existente.Activo)
                throw new InvalidOperationException($"Ya existe un ejemplar activo con código {ejemplar.Codigo}");

            Documento documento = Persistencia.Persistencia.GetDocumentoPorIsbn(ejemplar.IsbnDocumento);
            if (documento == null)
                throw new InvalidOperationException($"No existe un documento con ISBN {ejemplar.IsbnDocumento}");

            ejemplar.DniPAdq = this.personal.Dni;
            Persistencia.Persistencia.AltaEjemplar(ejemplar);
        }

        public void BajaEjemplar(Ejemplar ejemplar)
        {
            if (ejemplar == null)
                throw new ArgumentNullException(nameof(ejemplar), "El ejemplar no puede ser nulo");

            Ejemplar existente = Persistencia.Persistencia.GetEjemplar(ejemplar.Codigo);
            if (existente == null)
                throw new InvalidOperationException($"No existe un ejemplar con código {ejemplar.Codigo}");

            if (!existente.Activo)
                throw new InvalidOperationException($"El ejemplar con código {ejemplar.Codigo} ya está dado de baja");

            List<Prestamo> prestamos = Persistencia.Persistencia.GetTodosPrestamos();
            foreach (Prestamo prestamo in prestamos)
            {
                if (prestamo.Estado == EstadoPrestamo.EnProceso)
                {
                    foreach (var ej in prestamo.Ejemplares)
                    {
                        if (ej.Key.Codigo == ejemplar.Codigo && ej.Value == null)
                        {
                            throw new InvalidOperationException($"No se puede dar de baja el ejemplar {ejemplar.Codigo} porque está prestado");
                        }
                    }
                }
            }

            existente.Activo = false;
            Persistencia.Persistencia.UpdateEjemplar(existente);
        }

        public Ejemplar GetEjemplar(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código del ejemplar no puede estar vacío");

            return Persistencia.Persistencia.GetEjemplar(codigo);
        }

        public List<Ejemplar> GetEjemplaresPorDocumento(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            return Persistencia.Persistencia.GetEjemplaresPorDocumento(isbn);
        }

        public List<Ejemplar> GetEjemplaresActivos()
        {
            List<Ejemplar> todosEjemplares = Persistencia.Persistencia.GetTodosEjemplares();
            return todosEjemplares.Where(e => e.Activo).ToList();
        }

        public Documento GetDocumentoMasLeidoUltimoMes()
        {
            DateTime fechaLimite = DateTime.Now.AddMonths(-1);
            List<Prestamo> prestamos = Persistencia.Persistencia.GetTodosPrestamos();
            
            Dictionary<string, int> contadorPrestamos = new Dictionary<string, int>();

            foreach (Prestamo prestamo in prestamos)
            {
                if (prestamo.FechaPrestamo >= fechaLimite)
                {
                    foreach (var ejemplar in prestamo.Ejemplares.Keys)
                    {
                        string isbn = ejemplar.IsbnDocumento;
                        if (contadorPrestamos.ContainsKey(isbn))
                        {
                            contadorPrestamos[isbn]++;
                        }
                        else
                        {
                            contadorPrestamos[isbn] = 1;
                        }
                    }
                }
            }

            if (contadorPrestamos.Count == 0)
                return null;

            string isbnMasLeido = contadorPrestamos.OrderByDescending(kvp => kvp.Value).First().Key;
            return Persistencia.Persistencia.GetDocumentoPorIsbn(isbnMasLeido);
        }
    }
}
