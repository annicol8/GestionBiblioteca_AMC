using System;
using System.Collections.Generic;
using System.Linq;
using ModeloDominio;

namespace Persistencia
{
    public static class Persistencia
    {

        public static void CargarDatosPrueba()
        {
            BD.CargarDatosPrueba();
        }

        #region USUARIO
        //PRE: u != null
        //POST: devuelve true si se insertó correctamente, false si ya existía un usuario con ese DNI
        public static bool AltaUsuario(Usuario u)
        {
            return BD.INSERT(BD.TablaUsuarios, Transformers.UsuarioAUsuarioDato(u));
        }

        //PRE: u != null
        //POST: devuelve el Usuario si existe en BD, null en caso contrario
        public static Usuario GetUsuario(Usuario u)
        {
            UsuarioDato ud = BD.READ(BD.TablaUsuarios, Transformers.UsuarioAUsuarioDato(u));
            if (ud != null)
            {
                return Transformers.UsuarioDatoAUsuario(ud);
            }
            else return null;
        }

        //PRE: dni != null && dni != ""
        //POST: devuelve el Usuario con ese DNI si existe, null en caso contrario
        public static Usuario GetUsuario(string dni)
        {
            UsuarioDato ud = BD.READ_ALL(BD.TablaUsuarios)
                       .FirstOrDefault(u => u.Clave == dni);

            if (ud != null)
            {
                return Transformers.UsuarioDatoAUsuario(ud);
            }
            return null;
        }
        
        //PRE: u != null && existe un usuario con el DNI de u en la BD
        //POST: devuelve true si se eliminó correctamente, false si no existía
       public static bool BajaUsuario(Usuario u)
       {
            return BD.DELETE(BD.TablaUsuarios, Transformers.UsuarioAUsuarioDato(u));
       }


        //PRE: u != null && existe un usuario con el DNI de u en la BD
        //POST: devuelve true si se actualizó correctamente, false si no existía
        public static bool UpdateUsuario(Usuario u)
        {
            return BD.UPDATE(BD.TablaUsuarios, Transformers.UsuarioAUsuarioDato(u));
        }

        //PRE: ninguna
        //POST: devuelve lista con todos los usuarios de la BD (puede estar vacía)
        public static List<Usuario> GetUsuarios()
        {
            return BD.READ_ALL(BD.TablaUsuarios)
                     .Select(Transformers.UsuarioDatoAUsuario)
                     .ToList();
        }
        #endregion

        #region AUDIOLIBRO
        /*
PRE: al != null
POST: devuelve true si se insertó correctamente, false si ya existía un audiolibro con ese ISBN
*/
        public static bool AltaAudioLibro(AudioLibro al)
        {
            return BD.INSERT(BD.TablaAudioLibros, Transformers.AudioLibroAAudioLibroDato(al));
        }
        /*
PRE: al != null && existe en la BD
POST: devuelve true si se eliminó correctamente, false si no existía
*/
        public static bool BajaAudioLibro(AudioLibro al)
        {
            return BD.DELETE(BD.TablaAudioLibros, Transformers.AudioLibroAAudioLibroDato(al));
        }
        /*
PRE: al != null
POST: devuelve el AudioLibro si existe en BD, null en caso contrario
*/
        public static AudioLibro GetAudioLibro(AudioLibro al)
        {
            AudioLibroDato ald = BD.READ(BD.TablaAudioLibros, Transformers.AudioLibroAAudioLibroDato(al));
            if (ald != null)
            {
                return Transformers.AudioLibroDatoAAudioLibro(ald);
            }
            else return null;
        }
        /*
PRE: al != null && existe en la BD
POST: devuelve true si se actualizó correctamente, false si no existía
*/
        public static bool UpdateAudioLibro(AudioLibro al)
        {
            return BD.UPDATE(BD.TablaAudioLibros, Transformers.AudioLibroAAudioLibroDato(al));
        }
        /*
PRE: ninguna
POST: devuelve lista con todos los audiolibros (puede estar vacía)
*/
        public static List<AudioLibro> GetAudioLibros()
        {
            return BD.READ_ALL(BD.TablaAudioLibros)
                     .Select(Transformers.AudioLibroDatoAAudioLibro)
                     .ToList();
        }
        #endregion

        #region LIBROPAPEL
        /*
PRE: lp != null
POST: devuelve true si se insertó correctamente, false si ya existía
*/
        public static bool AltaLibroPapel(LibroPapel lp)
        {
            return BD.INSERT(BD.TablaLibrosPapel, Transformers.LibroPapelALibroPapelDato(lp));
        }
        /*
PRE: lp != null
POST: devuelve el LibroPapel si existe en BD, null en caso contrario
*/
        public static LibroPapel GetLibroPapel(LibroPapel lp)
        {
            LibroPapelDato lpd = BD.READ(BD.TablaLibrosPapel, Transformers.LibroPapelALibroPapelDato(lp));
            if (lpd != null)
            {
                return Transformers.LibroPapelDatoALibroPapel(lpd);
            }
            else return null;
        }
        /*
PRE: lp != null && existe en la BD
POST: devuelve true si se actualizó correctamente, false si no existía
*/
        public static bool UpdateLibroPapel(LibroPapel lp)
        {
            return BD.UPDATE(BD.TablaLibrosPapel, Transformers.LibroPapelALibroPapelDato(lp));
        }
        /*
PRE: lp != null && existe en la BD
POST: devuelve true si se eliminó correctamente, false si no existía
*/
        public static bool BajaLibroPapel(LibroPapel lp)
        {
            return BD.DELETE(BD.TablaLibrosPapel, Transformers.LibroPapelALibroPapelDato(lp));
        }
        /*
PRE: ninguna
POST: devuelve lista con todos los libros en papel (puede estar vacía)
*/
        public static List<LibroPapel> GetLibrosPapel()
        {
            return BD.READ_ALL(BD.TablaLibrosPapel)
                     .Select(Transformers.LibroPapelDatoALibroPapel)
                     .ToList();
        }
        #endregion

        #region DOCUMENTO
        /*
PRE: isbn != null && isbn != ""
POST: devuelve el Documento (LibroPapel o AudioLibro) con ese ISBN si existe, null si no
*/
        public static Documento GetDocumento(string isbn)

        {
            var lp = GetLibroPapel(new LibroPapel(isbn));
            if (lp != null) return lp;

            return GetAudioLibro(new AudioLibro(isbn));
        }
        /*
PRE: codigo > 0
POST: devuelve el Documento asociado al ejemplar con ese código, null si el ejemplar no existe
*/
        public static Documento GetDocumentoPorCodEjemplar(int codigo)
        {
            Ejemplar ejemplar = GetEjemplar(new Ejemplar(codigo));

            if (ejemplar == null) // Esto no se haría en la lógica de negocio?
                return null;

            return GetDocumento(ejemplar.IsbnDocumento);
        }
        /*
PRE: ninguna
POST: devuelve lista con todos los documentos (libros papel + audiolibros), puede estar vacía
*/
        public static List<Documento> GetTodosDocumentos()
        {
            List<Documento> documentos = new List<Documento>();
            documentos.AddRange(GetLibrosPapel());
            documentos.AddRange(GetAudioLibros());
            return documentos;
        }
        #endregion

        #region PERSONAL

        /*
PRE: ninguna
POST: devuelve lista con todo el personal de la BD (puede estar vacía)
*/
        public static List<Personal> GetPersonal()
        {
            return BD.READ_ALL(BD.TablaPersonales).Select(Transformers.PersonalDatoAPersonal).ToList();
        }
        /*
PRE: nombre != null && nombre != ""
POST: devuelve el Personal con ese nombre y tipo si existe, null en caso contrario
*/
        public static Personal BuscarPersonalPorNombreYTipo(string nombre, TipoPersonal tipo)
        {
            List<Personal> todosPersonales = GetPersonal();

            foreach (Personal p in todosPersonales)
            {
                if (p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) && p.Tipo == tipo)
                {
                    return p;
                }
            }
            return null;
        }
        /*
PRE: dni != null && dni != ""
POST: devuelve el Personal con ese DNI si existe, null en caso contrario
*/
        public static Personal GetPersonal(string dni)
        {
            PersonalDato pd = BD.READ_ALL(BD.TablaPersonales)
                        .FirstOrDefault(p => p.Clave == dni);

            return pd != null ? Transformers.PersonalDatoAPersonal(pd) : null;
        }

        /*
PRE: p != null
POST: devuelve true si se insertó correctamente, false si ya existía
*/
        public static bool AltaPersonal(Personal p)
        {
            return BD.INSERT(BD.TablaPersonales, Transformers.PersonalAPersonalDato(p));
        }
        /*
PRE: p != null && existe en la BD
POST: devuelve true si se eliminó correctamente, false si no existía
*/
        public static bool BajaPersonal(Personal p)
        {
            return BD.DELETE(BD.TablaPersonales, Transformers.PersonalAPersonalDato(p));
        }
        /*
PRE: p != null && existe en la BD
POST: devuelve true si se actualizó correctamente, false si no existía
*/
        public static bool UpdatePersonal(Personal p)
        {
            return BD.UPDATE(BD.TablaPersonales, Transformers.PersonalAPersonalDato(p));
        }
        /*
PRE: p != null
POST: devuelve el Personal si existe en BD, null en caso contrario
*/
        public static Personal GetPersonal(Personal p)
        {
            PersonalDato pd = BD.READ(BD.TablaPersonales, Transformers.PersonalAPersonalDato(p));
            if (pd != null)
            {
                return Transformers.PersonalDatoAPersonal(pd);
            }
            else return null;
        }
        /*
PRE: ninguna
POST: devuelve lista con todo el personal (puede estar vacía)
*/
        public static List<Personal> GetPersonales()
        {
            return BD.READ_ALL(BD.TablaPersonales)
                     .Select(Transformers.PersonalDatoAPersonal)
                     .ToList();
        }
        #endregion

        #region EJEMPLAR
        /*
        PRE: e != null
        POST: devuelve true si se insertó correctamente, false si ya existía un ejemplar con ese código
        */
        public static bool AltaEjemplar(Ejemplar e)
        {
            return BD.INSERT(BD.TablaEjemplares, Transformers.EjemplarAEjemplarDato(e));
        }
        /*
PRE: e != null
POST: devuelve el Ejemplar si existe en BD, null en caso contrario
*/
        public static Ejemplar GetEjemplar(Ejemplar e)
        {
            EjemplarDato ed = BD.READ(BD.TablaEjemplares, Transformers.EjemplarAEjemplarDato(e));
            if (ed != null)
            {
                return Transformers.EjemplarDatoAEjemplar(ed);
            }
            else return null;
        }
        /*
PRE: e != null && existe en la BD
POST: devuelve true si se eliminó correctamente, false si no existía
*/
        public static bool BajaEjemplar(Ejemplar e)
        {
            return BD.DELETE(BD.TablaEjemplares, Transformers.EjemplarAEjemplarDato(e));
        }
        /*
PRE: e != null && existe en la BD
POST: devuelve true si se actualizó correctamente, false si no existía
*/
        public static bool UpdateEjemplar(Ejemplar e)
        {
            return BD.UPDATE(BD.TablaEjemplares, Transformers.EjemplarAEjemplarDato(e));
        }
        /*
PRE: ninguna
POST: devuelve lista con todos los ejemplares (puede estar vacía)
*/
        public static List<Ejemplar> GetEjemplares()
        {
            return BD.READ_ALL(BD.TablaEjemplares)
                     .Select(Transformers.EjemplarDatoAEjemplar)
                     .ToList();
        }
        /*
PRE: isbn != null && isbn != ""
POST: devuelve lista con todos los ejemplares del documento con ese ISBN (puede estar vacía)
*/
        public static List<Ejemplar> GetEjemplaresPorDocumento(string isbn)
        {
            return BD.READ_ALL(BD.TablaEjemplares)
                     .Where(e => e.IsbnDocumento == isbn)
                     .Select(Transformers.EjemplarDatoAEjemplar)
                     .ToList();
        }
        #endregion

        #region PRESTAMO
        
        //PRE: p != null
        //POST: devuelve el ID generado para el nuevo préstamo, el préstamo se inserta en BD
        public static int AltaPrestamo(Prestamo p)
        {
            int nuevoID = BD.GenerarIdPrestamo();
            Prestamo prestamoNuevo = new Prestamo(nuevoID, p.FechaPrestamo, p.FechaDevolucion, p.Estado, p.DniUsuario, p.DniPersonal);
            BD.INSERT(BD.TablaPrestamos, Transformers.PrestamoAPrestamoDato(prestamoNuevo));
            return nuevoID;
        }
        
        //PRE: p != null && existe en la BD
        //POST: devuelve true si se eliminó correctamente, false si no existía
        public static bool BajaPrestamo(Prestamo p)
        {
            return BD.DELETE(BD.TablaPrestamos, Transformers.PrestamoAPrestamoDato(p));
        }

                
        //PRE: p != null
        //POST: devuelve el Prestamo si existe en BD, null en caso contrario
        public static Prestamo GetPrestamo(Prestamo p)
        {
            PrestamoDato pd = BD.READ(BD.TablaPrestamos, Transformers.PrestamoAPrestamoDato(p));
            if (pd != null)
            {
                return Transformers.PrestamoDatoAPrestamo(pd);
            }
            else return null;
        }

        
        //PRE: p != null && existe en la BD
        //POST: devuelve true si se actualizó correctamente, false si no existía
        public static bool UpdatePrestamo(Prestamo p)
        {
            return BD.UPDATE(BD.TablaPrestamos, Transformers.PrestamoAPrestamoDato(p));
        }

          
        //PRE: 
        //POST: devuelve lista con todos los préstamos (puede estar vacía)
        public static List<Prestamo> GetPrestamos()
        {
            return BD.READ_ALL(BD.TablaPrestamos)
                     .Select(Transformers.PrestamoDatoAPrestamo).Where(p => p != null)
                     .ToList();
        }

        
        //PRE: dniUsuario != null && dniUsuario != ""
        //POST: devuelve lista con los préstamos del usuario ordenados por fecha descendente (puede estar vacía)

        public static List<Prestamo> GetPrestamosPorUsuario(string dniUsuario)
        {
            return BD.READ_ALL(BD.TablaPrestamos)
                     .Where(p => p.DniUsuario == dniUsuario)
                     .Select(Transformers.PrestamoDatoAPrestamo)
                     .OrderByDescending(p => p.FechaPrestamo).ToList();
        }

                
        //PRE: id > 0
        //POST: devuelve el Prestamo con ese ID si existe, null en caso contrario

        public static Prestamo GetPrestamoPorId(int id)
        {
            var dato = BD.TablaPrestamos.FirstOrDefault(p => p.Clave.Equals(id));
            return dato != null ? Transformers.PrestamoDatoAPrestamo(dato) : null;
        }
        /*
PRE: idPrestamo > 0 && codigoEjemplar > 0
POST: devuelve true si se insertó la relación correctamente, false si ya existía
*/
        public static bool AltaPrestamoEjemplar(int idPrestamo, int codigoEjemplar, DateTime fechaDev)
        {
            return BD.INSERT(
               BD.TablaPrestamoEjemplar,
               new PrestamoEjemplarDato(idPrestamo, codigoEjemplar, fechaDev));
        }
        /*
PRE: idPrestamo > 0 && codigoEjemplar > 0 && la relación existe en BD
POST: devuelve true si se actualizó correctamente, false si no existía
*/
        public static bool UpdatePrestamoEjemplar(int idPrestamo, int codigoEjemplar, DateTime fechaDev)
        {
            return BD.UPDATE(
               BD.TablaPrestamoEjemplar,
               new PrestamoEjemplarDato(idPrestamo, codigoEjemplar, fechaDev));
        }
        /*
PRE: idPrestamo > 0 && codigoEjemplar > 0 && la relación existe en BD
POST: devuelve true si se eliminó correctamente, false si no existía
*/
        public static bool BajaPrestamoEjemplar(int idPrestamo, int codigoEjemplar)
        {

            return BD.DELETE(
                BD.TablaPrestamoEjemplar,
                new PrestamoEjemplarDato(idPrestamo, codigoEjemplar, DateTime.Now));
        }
        /*
PRE: idPrestamo > 0 && codigoEjemplar > 0
POST: devuelve el PrestamoEjemplarDato si existe la relación, null en caso contrario
*/
        public static PrestamoEjemplarDato GetPrestamoEjemplar(int idPrestamo, int codigoEjemplar)
        {
            return BD.READ_ALL(BD.TablaPrestamoEjemplar)
                     .FirstOrDefault(pe => pe.IdPrestamo == idPrestamo &&
                                           pe.CodigoEjemplar == codigoEjemplar);


        }

        /*
PRE: idPrestamo > 0
POST: devuelve lista con los ejemplares asociados al préstamo (puede estar vacía)
*/
        public static List<Ejemplar> GetEjemplaresDePrestamo(int idPrestamo)
        {
            return BD.READ_ALL(BD.TablaPrestamoEjemplar)
                     .Where(pe => pe.IdPrestamo == idPrestamo)
                     .Select(pe => GetEjemplar(new Ejemplar(pe.CodigoEjemplar)))
                     .Where(e => e != null) // Filtrar nulos por si acaso
                     .ToList();
        }

        public static List<Ejemplar> GetEjemplaresPrestamo (int idPrestamo)
        {
            return BD.TablaPrestamoEjemplar
                 .Where(pe => pe.IdPrestamo == idPrestamo)
                 .Select(pe => GetEjemplar(new Ejemplar(pe.CodigoEjemplar)))
                 .Where(e => e != null)
                 .ToList();
        }
        /*
PRE: codigoEjemplar > 0
POST: devuelve lista con todos los préstamos en los que aparece ese ejemplar (puede estar vacía)
*/
        public static List<Prestamo> GetPrestamosPorEjemplar(int codigoEjemplar)
        {
            HashSet<int> idsPrestamos = new HashSet<int>();
            var prestamosEjemplar = BD.READ_ALL(BD.TablaPrestamoEjemplar)
                                      .Where(pe => pe.CodigoEjemplar == codigoEjemplar)
                                      .Select(pe => pe.IdPrestamo)
                                      .Distinct();

            List<Prestamo> prestamos = new List<Prestamo>();
            foreach (var idPrestamo in prestamosEjemplar)
            {
                Prestamo p = GetPrestamoPorId(idPrestamo);
                if (p != null)
                {
                    prestamos.Add(p);
                }
            }
            return prestamos;
        }
        #endregion


    }
}
