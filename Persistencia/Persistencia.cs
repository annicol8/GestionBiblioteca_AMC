using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    public static class Persistencia
    {
        #region USUARIO
        //USUARIO
        public static bool AltaUsuario(Usuario u)
        {
            return BD.INSERT(BD.TablaUsuarios, Transformers.UsuarioAUsuarioDato(u));
        }

        public static Usuario GetUsuario(Usuario u)
        {
            UsuarioDato ud = BD.READ(BD.TablaUsuarios, Transformers.UsuarioAUsuarioDato(u));
            if (ud != null)
            {
                return Transformers.UsuarioDatoAUsuario(ud);
            }
            else return null;
        }

        public static Usuario GetUsuario(string dni)
        {
            Usuario busqueda = new Usuario(dni);
            return GetUsuario(busqueda);
        }

        public static bool BajaUsuario(Usuario u)
        {
            return BD.DELETE(BD.TablaUsuarios, Transformers.UsuarioAUsuarioDato(u));
        }

        public static bool UpdateUsuario(Usuario u)
        {
            return BD.UPDATE(BD.TablaUsuarios, Transformers.UsuarioAUsuarioDato(u));
        }

        public static List<Usuario> GetUsuarios()
        {
            return BD.READ_ALL(BD.TablaUsuarios)
                     .Select(Transformers.UsuarioDatoAUsuario)
                     .ToList();
        }
        #endregion

        #region AUDIOLIBRO
        //AUDIOLIBRO
        public static bool AltaAudioLibro(AudioLibro al)
        {
            return BD.INSERT(BD.TablaAudioLibros, Transformers.AudioLibroAAudioLibroDato(al));
        }

        public static bool BajaAudioLibro(AudioLibro al)
        {
            return BD.DELETE(BD.TablaAudioLibros, Transformers.AudioLibroAAudioLibroDato(al));
        }

        public static AudioLibro GetAudioLibro(AudioLibro al)
        {
            AudioLibroDato ald = BD.READ(BD.TablaAudioLibros, Transformers.AudioLibroAAudioLibroDato(al));
            if (ald != null)
            {
                return Transformers.AudioLibroDatoAAudioLibro(ald);
            }
            else return null;
        }

        public static bool UpdateAudioLibro(AudioLibro al)
        {
            return BD.UPDATE(BD.TablaAudioLibros, Transformers.AudioLibroAAudioLibroDato(al));
        }

        public static List<AudioLibro> GetAudioLibros()
        {
            return BD.READ_ALL(BD.TablaAudioLibros)
                     .Select(Transformers.AudioLibroDatoAAudioLibro)
                     .ToList();
        }
        #endregion

        #region LIBROPAPEL
        //LIBRO PAPEL
        public static bool AltaLibroPapel(LibroPapel lp)
        {
            return BD.INSERT(BD.TablaLibrosPapel, Transformers.LibroPapelALibroPapelDato(lp));
        }

        public static LibroPapel GetLibroPapel(LibroPapel lp)
        {
            LibroPapelDato lpd = BD.READ(BD.TablaLibrosPapel, Transformers.LibroPapelALibroPapelDato(lp));
            if (lpd != null)
            {
                return Transformers.LibroPapelDatoALibroPapel(lpd);
            }
            else return null;
        }

        public static bool UpdateLibroPapel(LibroPapel lp)
        {
            return BD.UPDATE(BD.TablaLibrosPapel, Transformers.LibroPapelALibroPapelDato(lp));
        }

        public static bool BajaLibroPapel(LibroPapel lp)
        {
            return BD.DELETE(BD.TablaLibrosPapel, Transformers.LibroPapelALibroPapelDato(lp));
        }

        public static List<LibroPapel> GetLibrosPapel()
        {
            return BD.READ_ALL(BD.TablaLibrosPapel)
                     .Select(Transformers.LibroPapelDatoALibroPapel)
                     .ToList();
        }
        #endregion

        #region DOCUMENTO
        //DOCUMENTOS TANTO AUDIO LIBRO COMO LIBRO PAPEL
        public static Documento GetDocumento(string isbn)
        {
            var lp = GetLibroPapel(new LibroPapel(isbn));
            if (lp != null) return lp;

            return GetAudioLibro(new AudioLibro(isbn));
        }

        public static Documento GetDocumentoPorCodEjemplar(int codigo)
        {
            Ejemplar ejemplar = GetEjemplar(new Ejemplar(codigo));

            if (ejemplar == null)
                return null;

            return GetDocumento(ejemplar.IsbnDocumento);
        }

        public static List<Documento> GetTodosDocumentos()
        {
            List<Documento> documentos = new List<Documento>();
            documentos.AddRange(GetLibrosPapel());
            documentos.AddRange(GetAudioLibros());
            return documentos;
        }
        #endregion

        #region PERSONAL
        //PERSONAL
        public static bool AltaPersonal(Personal p)
        {
            return BD.INSERT(BD.TablaPersonales, Transformers.PersonalAPersonalDato(p));
        }

        public static bool BajaPersonal(Personal p)
        {
            return BD.DELETE(BD.TablaPersonales, Transformers.PersonalAPersonalDato(p));
        }

        public static bool UpdatePersonal(Personal p)
        {
            return BD.UPDATE(BD.TablaPersonales, Transformers.PersonalAPersonalDato(p));
        }
        public static Personal GetPersonal(Personal p)
        {
            PersonalDato pd = BD.READ(BD.TablaPersonales, Transformers.PersonalAPersonalDato(p));
            if (pd != null)
            {
                return Transformers.PersonalDatoAPersonal(pd);
            }
            else return null;
        }

        public static List<Personal> GetPersonales()
        {
            return BD.READ_ALL(BD.TablaPersonales)
                     .Select(Transformers.PersonalDatoAPersonal)
                     .ToList();
        }
        #endregion

        #region EJEMPLAR
        //EJEMPLAR
        public static bool AltaEjemplar(Ejemplar e)
        {
            return BD.INSERT(BD.TablaEjemplares, Transformers.EjemplarAEjemplarDato(e));
        }

        public static Ejemplar GetEjemplar(Ejemplar e)
        {
            EjemplarDato ed = BD.READ(BD.TablaEjemplares, Transformers.EjemplarAEjemplarDato(e));
            if (ed != null)
            {
                return Transformers.EjemplarDatoAEjemplar(ed);
            }
            else return null;
        }

        public static bool BajaEjemplar(Ejemplar e)
        {
            return BD.DELETE(BD.TablaEjemplares, Transformers.EjemplarAEjemplarDato(e));
        }

        public static bool UpdateEjemplar(Ejemplar e)
        {
            return BD.UPDATE(BD.TablaEjemplares, Transformers.EjemplarAEjemplarDato(e));
        }
        public static List<Ejemplar> GetEjemplares()
        {
            return BD.READ_ALL(BD.TablaEjemplares)
                     .Select(Transformers.EjemplarDatoAEjemplar)
                     .ToList();
        }

        public static List<Ejemplar> GetEjemplaresPorDocumento(string isbn)
        {
            return BD.READ_ALL(BD.TablaEjemplares)
                     .Where(e => e.Isbn == isbn)
                     .Select(Transformers.EjemplarDatoAEjemplar)
                     .ToList();
        }
        #endregion

        #region PRESTAMO
        //PRESTAMO
        public static int AltaPrestamo(Prestamo p)
        {
            int nuevoID = BD.GenerarIdPrestamo();
            Prestamo prestamoNuevo = new Prestamo(nuevoID, p.FechaPrestamo, p.FechaDevolucion, p.Estado, p.DniUsuario, p.DniPersonal);
            BD.INSERT(BD.TablaPrestamos, Transformers.PrestamoAPrestamoDato(prestamoNuevo));
            return nuevoID;
        }

        public static bool BajaPrestamo(Prestamo p)
        {
            return BD.DELETE(BD.TablaPrestamos, Transformers.PrestamoAPrestamoDato(p));
        }

        public static Prestamo GetPrestamo(Prestamo p)
        {
            PrestamoDato pd = BD.READ(BD.TablaPrestamos, Transformers.PrestamoAPrestamoDato(p));
            if (pd != null)
            {
                return Transformers.PrestamoDatoAPrestamo(pd);
            }
            else return null;
        }

        public static bool UpdatePrestamo(Prestamo p)
        {
            return BD.UPDATE(BD.TablaPrestamos, Transformers.PrestamoAPrestamoDato(p));
        }

        public static List<Prestamo> GetPrestamos()
        {
            return BD.READ_ALL(BD.TablaPrestamos)
                     .Select(Transformers.PrestamoDatoAPrestamo)
                     .ToList();
        }

        public static List<Prestamo> GetPrestamosPorUsuario(string dniUsuario)
        {
            return BD.READ_ALL(BD.TablaPrestamos)
                     .Where(p => p.DniUsuario == dniUsuario)
                     .Select(Transformers.PrestamoDatoAPrestamo)
                     .ToList();
        }

        public static Prestamo GetPrestamoPorId(int id)
        {
            var dato = BD.TablaPrestamos.FirstOrDefault(p => p.Clave.Equals(id));
            return dato != null ? Transformers.PrestamoDatoAPrestamo(dato) : null;
        }
        #endregion

        //PRESTAMO_EJEMPLAR
        public static bool AltaPrestamoEjemplar(int idPrestamo, int codigoEjemplar, DateTime fechaDev)
        {
            //BD.INSERT(BD.TablaPrestamoEjemplar, Transformers.PrestamoEjemplarAPrestamoEjemplarDato(idPrestamo, codigoEjemplar, fechaDevolucion));

            return BD.INSERT(
               BD.TablaPrestamoEjemplar,
               new PrestamoEjemplarDato(idPrestamo, codigoEjemplar, fechaDev));
        }

        public static bool UpdatePrestamoEjemplar(int idPrestamo, int codigoEjemplar, DateTime fechaDev)
        {
            //BD.UPDATE(BD.TablaPrestamoEjemplar, Transformers.PrestamoEjemplarAPrestamoEjemplarDato(idPrestamo, codigoEjemplar, fechaDevolucion));

            return BD.UPDATE(
               BD.TablaPrestamoEjemplar,
               new PrestamoEjemplarDato(idPrestamo, codigoEjemplar, fechaDev));
        }

        public static bool BajaPrestamoEjemplar(int idPrestamo, int codigoEjemplar) // He cambiado la cabecera para que le hora de devolucion sea la actual
        {
            //BD.DELETE(BD.TablaPrestamoEjemplar, Transformers.PrestamoEjemplarAPrestamoEjemplarDato(idPrestamo, codigoEjemplar, fechaDevolucion));

            return BD.DELETE(
                BD.TablaPrestamoEjemplar,
                new PrestamoEjemplarDato(idPrestamo, codigoEjemplar, DateTime.Now));
        }

        public static PrestamoEjemplarDato GetPrestamoEjemplar(int idPrestamo, int codigoEjemplar)
        {
            return BD.READ(
                BD.TablaPrestamoEjemplar,
                new PrestamoEjemplarDato(idPrestamo, codigoEjemplar, DateTime.Now));
        }

        public static List<PrestamoEjemplarDato> GetEjemplaresDePrestamo(int idPrestamo)
        {
            return BD.READ_ALL(BD.TablaPrestamoEjemplar)
                     .Where(pe => pe.IdPrestamo == idPrestamo)
                     .ToList();
        }
        public static List<PrestamoEjemplarDato> GetPrestamosPorEjemplar(int codigoEjemplar)
        {
            return BD.READ_ALL(BD.TablaPrestamoEjemplar)
                     .Where(pe => pe.CodigoEjemplar == codigoEjemplar)
                     .ToList();
        }

    }
}
