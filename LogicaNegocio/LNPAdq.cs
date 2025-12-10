using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;
using Persistencia;

namespace LogicaNegocio
{
    internal class LNPAdq : LNPersonal, ILNPAdq
    {
        public LNPAdq(PersonalAdquisiciones personal) : base(personal)
        {
            ;
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

        public void AltaLibroPapel(LibroPapel libro)
        {
            if (libro == null)
                throw new ArgumentNullException("El libro no puede ser null");

            if (string.IsNullOrWhiteSpace(libro.Isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            Documento existente = Persistencia.Persistencia.GetDocumento(libro.Isbn);
            if (existente != null)
                throw new InvalidOperationException("Ya existe un documento con ese ISBN");

            Persistencia.Persistencia.AltaLibroPapel(libro);
        }

        public void AltaAudioLibro(AudioLibro audioLibro)
        {
            if (audioLibro == null)
                throw new ArgumentNullException("El audiolibro no puede ser null");

            if (string.IsNullOrWhiteSpace(audioLibro.Isbn))
                throw new ArgumentException("El ISBN no puede estar vacío");

            Documento existente = Persistencia.Persistencia.GetDocumento(audioLibro.Isbn);
            if (existente != null)
                throw new InvalidOperationException("Ya existe un documento con ese ISBN");

            Persistencia.Persistencia.AltaAudioLibro(audioLibro);
        }

        public void BajaDocumento(string isbn)
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

            // Eliminar según tipo
            if (doc is LibroPapel)
                Persistencia.Persistencia.BajaLibroPapel((LibroPapel)doc);
            else
                Persistencia.Persistencia.BajaAudioLibro((AudioLibro)doc);
        }

        public string GetDocumentoMasPrestadoUltimoMes()
        {
            return null;
            /*
            DateTime haceUnMes = DateTime.Now.AddMonths(-1);
            List<Prestamo> prestamos = Persistencia.Persistencia.GetPrestamos();
            Dictionary<string, int> contadorPorDocumento = new Dictionary<string, int>();

            foreach (Prestamo p in prestamos)
            {
                if (p.FechaPrestamo >= haceUnMes)
                {
                    List<EjemplarPrestamo> eps = Persistencia.Persistencia.GetEjemplaresDePrestamo(p.Id);
                    foreach (EjemplarPrestamo ep in eps)
                    {
                        Ejemplar ej = Persistencia.Persistencia.GetEjemplar(new Ejemplar(ep.CodigoEjemplar));
                        if (ej != null)
                        {
                            if (contadorPorDocumento.ContainsKey(ej.IsbnDocumento))
                                contadorPorDocumento[ej.IsbnDocumento]++;
                            else
                                contadorPorDocumento[ej.IsbnDocumento] = 1;
                        }
                    }
                }
            }

            if (contadorPorDocumento.Count == 0)
                return null;

            return contadorPorDocumento.OrderByDescending(kvp => kvp.Value).First().Key;
            */
        }

        public void AltaEjemplar(int codigo, string isbnDocumento)
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
            Persistencia.Persistencia.AltaEjemplar(nuevoEjemplar);
        }

        public void BajaEjemplar(int codigo)
        {
            Ejemplar ej = Persistencia.Persistencia.GetEjemplar(new Ejemplar(codigo));
            if (ej == null)
                throw new InvalidOperationException("El ejemplar no existe");

            if (EstaEjemplarPrestado(codigo))
                throw new InvalidOperationException("No se puede dar de baja un ejemplar prestado");

            ej.Activo = false;
            Persistencia.Persistencia.UpdateEjemplar(ej);
        }

        public Ejemplar GetEjemplar(int codigo)
        {
            return Persistencia.Persistencia.GetEjemplar(new Ejemplar(codigo));
        }
    
    }
}
