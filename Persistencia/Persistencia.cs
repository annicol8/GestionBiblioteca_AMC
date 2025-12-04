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
        public static void AltaUsuario(Usuario u)
        {
            BD.INSERT(BD.TablaUsuarios, Transformers.UsuarioAUsuarioDato(u));
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


        public static void BajaUsuario(Usuario u)
        {
            BD.DELETE(BD.TablaUsuarios, Transformers.UsuarioAUsuarioDato(u));
        }

        public static void UpdateUsuario(Usuario u)
        {
            BD.UPDATE(BD.TablaUsuarios, Transformers.UsuarioAUsuarioDato(u));
        }

        public static List<Usuario> GetUsuarios()
        {
            List<UsuarioDato> datosUsuario = BD.READ_ALL(BD.TablaUsuarios);
            return datosUsuario.Select(d => Transformers.UsuarioDatoAUsuario(d)).ToList();
        }
        #endregion

        #region AUDIOLIBRO
        //AUDIOLIBRO
        public static void AltaAudioLibro(AudioLibro al)
        {
            BD.INSERT(BD.TablaAudioLibros, Transformers.AudioLibroAAudioLibroDato(al));
        }

        public static void BajaAudioLibro(AudioLibro al)
        {
            BD.DELETE(BD.TablaAudioLibros, Transformers.AudioLibroAAudioLibroDato(al));
        }

        public static AudioLibro GetAudioLibro(AudioLibro al)
        {
            AudioLibroDato ald = BD.READ(BD.TablaAudioLibros, Transformers.AudioLibroAAudioLibroDato(al));
            if(ald != null) 
            {
                return Transformers.AudioLibroDatoAAudioLibro(ald);
            }
            else return null;
        }

        public static void UpdateAudioLibro(AudioLibro al)
        {
            BD.UPDATE(BD.TablaAudioLibros, Transformers.AudioLibroAAudioLibroDato(al));
        }

        public static List<AudioLibro> GetAudioLibros()
        {
            List<AudioLibroDato> datosALibro = BD.READ_ALL(BD.TablaAudioLibros);
            return datosALibro.Select(d => Transformers.AudioLibroDatoAAudioLibro(d)).ToList();
        }
        #endregion

        #region LIBROPAPEL
        //LIBRO PAPEL
        public static void AltaLibroPapel(LibroPapel lp)
        {
            BD.INSERT(BD.TablaLibrosPapel, Transformers.LibroPapelALibroPapelDato(lp));
        }

        public static LibroPapel GetLibroPapel(LibroPapel lp)
        {
            LibroPapelDato lpd = BD.READ(BD.TablaLibrosPapel, Transformers.LibroPapelALibroPapelDato(lp));
            if (lpd != null)
            {
                return Transformers.LibroPapelDatoALibroPapel(lpd);
            } else return null;  
        }

        public static void UpdateLibroPapel(LibroPapel lp)
        {
            BD.UPDATE(BD.TablaLibrosPapel, Transformers.LibroPapelALibroPapelDato(lp));
        }

        public static void BajaLibroPapel(LibroPapel lp)
        {
            BD.DELETE(BD.TablaLibrosPapel, Transformers.LibroPapelALibroPapelDato(lp));
        }

        public static List<LibroPapel> GetLibrosPapel()
        {
            List<LibroPapelDato> datosLPapel = BD.READ_ALL(BD.TablaLibrosPapel);
            return datosLPapel.Select(d => Transformers.LibroPapelDatoALibroPapel(d)).ToList();
        }
        #endregion

        #region DOCUMENTO
        //DOCUMENTOS TANTO AUDIO LIBRO COMO LIBRO PAPEL
        public static Documento GetDocuemnto(string isbn)
        {
            LibroPapel lp = GetLibroPapel(new LibroPapel(isbn));
            if (lp != null)
            {
                return lp;
            }
            else return GetAudioLibro(new AudioLibro(isbn));
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
        public static void AltaPersonal(Personal p)
        {
            BD.INSERT(BD.TablaPersonales, Transformers.PersonalAPersonalDato(p));
        }

        public static void BajaPersonal(Personal p)
        {
            BD.DELETE(BD.TablaPersonales, Transformers.PersonalAPersonalDato(p));
        }

        public static void UpdatePersonal(Personal p)
        {
            BD.UPDATE(BD.TablaPersonales, Transformers.PersonalAPersonalDato(p));
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

        public static List<Personal> GetPersonal()
        {
            List<PersonalDato> datos = BD.READ_ALL(BD.TablaPersonales);
            return datos.Select(d => Transformers.PersonalDatoAPersonal(d)).ToList();
        }
        #endregion

        #region EJEMPLAR
        //EJEMPLAR
        public static void AltaEjemplar(Ejemplar e)
        {
            BD.INSERT(BD.TablaEjemplares, Transformers.EjemplarAEjemplarDato(e));
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

        public static void BajaEjemplar(Ejemplar e)
        {
            BD.DELETE(BD.TablaEjemplares, Transformers.EjemplarAEjemplarDato(e));
        }

        public static void UpdateEjemplar(Ejemplar e)
        {
            BD.UPDATE(BD.TablaEjemplares, Transformers.EjemplarAEjemplarDato(e));
        }

        public static List<Ejemplar> GetEjemplares()
        {
            List<EjemplarDato> datosEjemplares = BD.READ_ALL(BD.TablaEjemplares);
            return datosEjemplares.Select(d => Transformers.EjemplarDatoAEjemplar(d)).ToList();
        }

        public static List<Ejemplar> GetEjemplaresPorDocumento(string isbn)
        {
            List<EjemplarDato> datosEjemplares = BD.READ_ALL(BD.TablaEjemplares);
            List<EjemplarDato> ejemplaresDoc = datosEjemplares.Where(e => e.Isbn.Equals(isbn)).ToList();
            return ejemplaresDoc.Select(d => Transformers.EjemplarDatoAEjemplar(d)).ToList();
        }
        #endregion

        #region PRESTAMO
        //PRESTAMO
        public static int AltaPrestamo(Prestamo p)
        {
            int nuevoID = BD.GenerarIdPrestamo();
            Prestamo prestamoNuevo = new Prestamo(nuevoID, p.FechaPrestamo, p.FechaDevolucion, p.Estado, p.DniPersonal, p.DniUsuario);
            BD.INSERT(BD.TablaPrestamos, Transformers.PrestamoAPrestamoDato(prestamoNuevo));
            return nuevoID;
        }

        public static void BajaPrestamo(Prestamo p)
        {
            BD.DELETE(BD.TablaPrestamos, Transformers.PrestamoAPrestamoDato(p));
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

        public static void UpdatePrestamo(Prestamo p)
        {
            BD.UPDATE(BD.TablaPrestamos, Transformers.PrestamoAPrestamoDato(p));
        }

        public static List<Prestamo> GetPrestamos()
        {
            List<Prestamo> datosPrestamos = BD.READ_ALL(BD.TablaPrestamos);
            return datosPrestamos.Select(d=>Transformers.PrestamoDatoAPrestamo(d)).ToList();
        }

        public static List<Prestamo> GetPrestamosPorUsuario (string dniUsuario)
        {
            List<Prestamo> lista = new List<Prestamo>();
            foreach (PrestamoDato pd in BD.TablaPrestamos)
            {
                if (pd.DniUsuario.Equals(dniUsuario))
                {
                    lista.Add(Transformers.PrestamoDatoAPrestamo(pd));
                }
            }
            return lista;
        }

        public static Prestamo GetPrestamoPorId(string id)
        {
            Prestamo p = null;
            foreach (PrestamoDato pd in BD.TablaPrestamos)
            {
                if (pd.Clave.Equals(id))
                {
                    p = Transformers.PrestamoDatoAPrestamo(pd);
                }
            }
            return p;
        }
        #endregion

        //PRESTAMO_EJEMPLAR
        public static void AltaPrestamoEjemplar(int idPrestamo, int codigoEjemplar, DateTime fechaDevolucion)
        {
            BD.INSERT(BD.TablaPrestamoEjemplar, Transformers.PrestamoEjemplarAPrestamoEjemplarDato(idPrestamo, codigoEjemplar, fechaDevolucion));
        }

        public static void UpdatePrestamoEjemplar(int idPrestamo, int codigoEjemplar, DateTime fechaDevolucion)
        {
            BD.UPDATE(BD.TablaPrestamoEjemplar, Transformers.PrestamoEjemplarAPrestamoEjemplarDato(idPrestamo, codigoEjemplar, fechaDevolucion));
        }

        public static void BajaPrestamoEjemplar(int idPrestamo, int codigoEjemplar, DateTime fechaDevolucion)
        {
            BD.DELETE(BD.TablaPrestamoEjemplar, Transformers.PrestamoEjemplarAPrestamoEjemplarDato(idPrestamo, codigoEjemplar, fechaDevolucion));
        }

        public static List<PrestamoEjemplarDato> GetEjemplaresDePrestamo(int idPrestamo)
        {
            List<PrestamoEjemplarDato> todos = BD.READ_ALL(BD.TablaPrestamoEjemplar);
            return todos.Where(pe => pe.IdPrestamo == idPrestamo).ToList();
        }
        public static List<PrestamoEjemplarDato> GetPrestamosPorEjemplar(int codigoEjemplar)
        {
            List<PrestamoEjemplarDato> todos = BD.READ_ALL(BD.TablaPrestamoEjemplar);
            return todos.Where(pe => pe.CodigoEjemplar == codigoEjemplar).ToList();
        }

    }
}
