using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    internal class Persistencia
    {
        //USUARIO
        public static void AltaUsuario(Usuario u)
        {
            BD.INSERT(Transformers.UsuarioAUsuarioDato(u));
        }

        public static Usuario GetUsuario(Usuario u)
        {
            UsuarioDato ud = BD.READ(Transformers.UsuarioAUsuarioDato(u));
            if (ud != null)
            {
                return Transformers.UsuarioDatoAUsuario(ud);
            }
            else return null;
        }

        public static void BajaUsuario(Usuario u)
        {
            BD.DELETE(Transformers.UsuarioAUsuarioDato(u));
        }

        public static void UpdateUsuario(Usuario u)
        {
            BD.UPDATE(Transformers.UsuarioAUsuarioDato(u));
        }

        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            foreach (UsuarioDato ud in BD.TablaUsuarios)
            {
                lista.Add(Transformers.UsuarioDatoAUsuario(ud));
            }
            return lista;
        }

        public Usuario GetUsarioPorDni (string dni)
        {
            Usuario u = null;
            foreach(UsuarioDato ud in BD.TablaUsuarios)
            {
                if (ud.Clave.Equals(dni))
                {
                    u = Transformers.UsuarioDatoAUsuario(ud);
                }
            }
            return u;
        }

        //PERSONAL
        public static void AltaPersonal(Personal p)
        {
            BD.INSERT(Transformers.PersonalAPersonalDato(p));
        }

        public static Personal GetPersonal(Personal p)
        {
            PersonalDato pd = BD.READ(Transformers.PersonalAPersonalDato(p));
            if (pd != null)
            {
                return Transformers.PersonalDatoAPersonal(pd);
            }
            else return null;
        }

        public static List<Personal> GetPersonal()
        {
            List<Personal> lista = new List<Personal>();
            foreach (PersonalDato pd in BD.TablaPersonales)
            {
                lista.Add(Transformers.PersonalDatoAPersonal(pd));
            }
            return lista;
        }

        //DOCUMENTO
        public static void AltaDocumento(Documento d)
        {
            BD.INSERT(Transformers.DocumentoADocumentoDato(d));
        }

        public static Documento GetDocumento(Documento d)
        {
            DocumentoDato dd = BD.READ(Transformers.DocumentoADocumentoDato(d));
            if (dd != null)
            {
                return Transformers.DocumentoDatoADocumento(dd);
            }
            else return null;
        }

        public static void BajaDocumento(Documento d)
        {
            BD.DELETE(Transformers.DocumentoADocumentoDato(d));
        }

        public static void UpdateDocumento(Documento d)
        {
            BD.UPDATE(Transformers.DocumentoADocumentoDato(d));
        }

        public static List<Documento> GetDocumentos()
        {
            List<Documento> lista = new List<Documento>();
            foreach (DocumentoDato dd in BD.TablaDocumentos)
            {
                lista.Add(Transformers.DocumentoDatoADocumento(dd));
            }
            return lista;
        }

        public Documento GetDocumentoPorIsbn(string isbn)
        {
            Documento d = null;
            foreach (DocumentoDato dd in BD.TablaDocumentos)
            {
                if (dd.Clave.Equals(isbn))
                {
                    d = Transformers.DocumentoDatoADocumento(dd);
                }
            }
            return d;
        }

        //EJEMPLAR
        public static void AltaEjemplar(Ejemplar e)
        {
            BD.INSERT(Transformers.EjemplarAEjemplarDato(e));
        }

        public static Ejemplar GetEjemplar(Ejemplar e)
        {
            EjemplarDato ed = BD.READ(Transformers.EjemplarAEjemplarDato(e));
            if (ed != null)
            {
                return Transformers.EjemplarDatoAEjemplar(ed);
            }
            else return null;
        }

        public static void BajaEjemplar(Ejemplar e)
        {
            BD.DELETE(Transformers.EjemplarAEjemplarDato(e));
        }

        public static void UpdateEjemplar(Ejemplar e)
        {
            BD.UPDATE(Transformers.EjemplarAEjemplarDato(e));
        }

        public static List<Ejemplar> GetEjemplares()
        {
            List<Ejemplar> lista = new List<Ejemplar>();
            foreach (EjemplarDato ed in BD.TablaEjemplares)
            {
                lista.Add(Transformers.EjemplarDatoAEjemplar(ed));
            }
            return lista;
        }

        public static List<Ejemplar> GetEjemplaresPorDocumento(string isbn)
        {
            List<Ejemplar> lista = new List<Ejemplar>();
            foreach (EjemplarDato ed in BD.TablaEjemplares)
            {
                if (ed.Isbn.Equals(isbn))
                {
                    lista.Add(Transformers.EjemplarDatoAEjemplar(ed));
                }
            }
            return lista;
        }

        
        //PRESTAMO
        public static int AltaPrestamo(Prestamo p)
        {
            int nuevoID = BD.GenerarIdPrestamo();
            Prestamo prestamoNuevo = new Prestamo(nuevoID, p.FechaPrestamo, p.FechaDevolucion, p.Estado, p.DniPersonal, p.DniUsuario);
            BD.INSERT(Transformers.PrestamoAPrestamoDato(prestamoNuevo));
            return nuevoID;
        }

        public void BajaPrestamo(Prestamo p)
        {
            BD.DELETE(Transformers.PrestamoAPrestamoDato(p));
        }

        public static Prestamo GetPrestamo(Prestamo p)
        {
            Prestamo pd = BD.READ(Transformers.PrestamoAPrestamoDato(p));
            if (pd != null)
            {
                return Transformers.PrestamoDatoAPrestamo(pd);
            }
            else return null;
        }

        public static void UpdatePrestamo(Prestamo p)
        {
            BD.UPDATE(Transformers.PrestamoAPrestamoDato(p));
        }

        public static List<Prestamo> GetPrestamos()
        {
            List<Prestamo> lista = new List<Prestamo>();
            foreach (PrestamoDato pd in BD.TablaPrestamos)
            {
                lista.Add(Transformers.PrestamoDatoAPrestamo(pd));
            }
            return lista;
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

        public Prestamo GetPrestamoPorId(string id)
        {
            Prestamo p = null;
            foreach (PrestamoDato pd in BD.TablaPrestamos)
            {
                if (pd.Id.Equals(id))
                {
                    p = Transformers.PrestamoDatoAPrestamo(pd);
                }
            }
            return p;
        }

        //PRESTAMO_EJEMPLAR
        /*
        public static void AltaPrestamoEjemplar(PrestamoEjemplar ep)
        {
            BD.INSERT(Transformers.PrestamoEjemplarAPrestamoEjemplarDato(ep));
        }
        */
        //NO SE PUEDE HACER SE DEBERIA AÑADIR A MD LA CLASE PRESTAMOEJEMPLAR

        

    }
}
