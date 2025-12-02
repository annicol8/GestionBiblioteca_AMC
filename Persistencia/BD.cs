using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ModeloDominio;

namespace Persistencia
{
    internal static class BD
    {
        private static Tabla<string, AudioLibroDato> tablaAudioLibros;
        private static Tabla<string, DocumentoDato> tablaDocumentos;
        private static Tabla<int, EjemplarDato> tablaEjemplares;
        private static Tabla<string, LibroPapelDato> tablaLibrosPapel;
        private static Tabla<string, PersonalDato> tablaPersonales;
        private static Tabla<int, PrestamoDato> tablaPrestamos;
        private static Tabla<ClavePrestamoEjemplar, PrestamoEjemplarDato> tablaPrestamoEjemplar;
        private static Tabla<string, UsuarioDato> tablaUsuarios;

        private static int ultimoIdPrestamo = 0;

        public static Tabla<string, AudioLibroDato> TablaAudioLibros
        {
            get
            {
                if (tablaAudioLibros == null) { tablaAudioLibros = new Tabla<string, AudioLibroDato>(); }
                return tablaAudioLibros;
            }
        }

        public static Tabla<string, DocumentoDato> TablaDocumentos
        {
            get
            {
                if (tablaDocumentos == null) { tablaDocumentos = new Tabla<string, DocumentoDato>(); }
                return tablaDocumentos;
            }
        }

        public static Tabla<int, EjemplarDato> TablaEjemplares
        {
            get
            {
                if (tablaEjemplares == null) { tablaEjemplares = new Tabla<int, EjemplarDato>(); }
                return tablaEjemplares;
            }
        }

        public static Tabla<string, LibroPapelDato> TablaLibrosPapel
        {
            get
            {
                if (tablaLibrosPapel == null) { tablaLibrosPapel = new Tabla<string, LibroPapelDato>(); }
                return tablaLibrosPapel;
            }
        }

        public static Tabla<string, PersonalDato> TablaPersonales
        {
            get
            {
                if (tablaPersonales == null) { tablaPersonales = new Tabla<string, PersonalDato>(); }
                return tablaPersonales;
            }
        }

        public static Tabla<int, PrestamoDato> TablaPrestamos
        {
            get
            {
                if (tablaPrestamos == null) { tablaPrestamos = new Tabla<int, PrestamoDato>(); }
                return tablaPrestamos;
            }
        }

        public static Tabla<string, UsuarioDato> TablaUsuarios
        {
            get
            {
                if (tablaUsuarios == null) { tablaUsuarios = new Tabla<string, UsuarioDato>(); }
                return tablaUsuarios;
            }
        } 

        public static Tabla<ClavePrestamoEjemplar, PrestamoEjemplarDato> TablaClavePrestamos
        {
            get
            {
                if (tablaPrestamoEjemplar == null) { tablaPrestamoEjemplar = new Tabla<ClavePrestamoEjemplar, PrestamoEjemplarDato> (); }
                return tablaPrestamoEjemplar;
            }
        }

        public static int GenerarIdPrestamo()
        {
            return ++ultimoIdPrestamo;
        }

        //USUARIO
        public static bool INSERT(UsuarioDato u)
        {
            if (TablaUsuarios.Contains(u.Clave))
            {
                return false;
            }
            else
            {
                TablaUsuarios.Add(u);
                return true;
            }
        }

        public static void CREATE(Usuario usuario)
        {
            UsuarioDato uDato = Transformers.UsuarioAUsuarioDato(usuario);
            BD.TablaUsuarios.Add(uDato);
        }

        public static UsuarioDato READ(UsuarioDato u)
        {
            if (TablaUsuarios.Contains(u.Clave))
            {
                foreach(UsuarioDato ud in TablaUsuarios)
                {
                    if (ud.Clave.Equals(u.Clave)) 
                        { return ud; }
                }
            }
            return null;
        }

        public static bool UPDATE(UsuarioDato u)
        {
            if (TablaUsuarios.Contains(u.Clave))
            {
                DELETE(u);
                INSERT(u);
                return true;
            }
            return false;
        }

        public static bool DELETE(UsuarioDato u)
        {
            if (TablaUsuarios.Contains(u.Clave))
            {
                TablaUsuarios.Remove(u.Clave);
                return true;
            }
            return false;
        }


        //PERSONAL
        public static void create(Personal personal)
        {
            PersonalDato pDato = Transformers.PersonalAPersonalDato(personal);
            BD.TablaPersonales.Add(pDato);
        }

        public static bool INSERT(PersonalDato p)
        {
            if (TablaPersonales.Contains(p.Clave))
                return false;
            TablaPersonales.Add(p);
            return true;
        }

        public static PersonalDato READ(PersonalDato p)
        {
            if (TablaPersonales.Contains(p.Clave))
            {
                foreach (PersonalDato pd in TablaPersonales)
                {
                    if (pd.Clave.Equals(p.Clave))
                        return pd;
                }
            }
            return null;
        }

        public static bool UPDATE(PersonalDato p)
        {
            if (TablaPersonales.Contains(p.Clave))
            {
                DELETE(p);
                INSERT(p);
                return true;
            }
            return false;
        }

        public static bool DELETE(PersonalDato p)
        {
            if (TablaPersonales.Contains(p.Clave))
            {
                TablaPersonales.Remove(p.Clave);
                return true;
            }
            return false;
        }



        //DOCUMENTO
        public static void create(Documento documento)
        {
            DocumentoDato dDato = Transformers.DocumentoADocumentoDato(documento);
            BD.TablaDocumentos.Add(dDato);
        }

        public static bool INSERT(DocumentoDato d)
        {
            if (TablaDocumentos.Contains(d.Clave))
                return false;
            TablaDocumentos.Add(d);
            return true;
        }

        public static DocumentoDato READ(DocumentoDato d)
        {
            if (TablaDocumentos.Contains(d.Clave))
            {
                foreach (DocumentoDato dd in TablaDocumentos)
                {
                    if (dd.Clave.Equals(d.Clave))
                        return dd;
                }
            }
            return null;
        }

        public static bool UPDATE(DocumentoDato d)
        {
            if (TablaDocumentos.Contains(d.Clave))
            {
                DELETE(d);
                INSERT(d);
                return true;
            }
            return false;
        }

        public static bool DELETE(DocumentoDato d)
        {
            if (TablaDocumentos.Contains(d.Clave))
            {
                TablaDocumentos.Remove(d.Clave);
                return true;
            }
            return false;
        }


        //EJEMPLAR
        public static void create(Ejemplar ejemplar)
        {
            EjemplarDato eDato = Transformers.EjemplarAEjemplarDato(ejemplar);
            BD.TablaEjemplares.Add(eDato);
        }

        public static bool INSERT(EjemplarDato e)
        {
            if (TablaEjemplares.Contains(e.Clave))
                return false;
            TablaEjemplares.Add(e);
            return true;
        }

        public static EjemplarDato READ(EjemplarDato e)
        {
            if (TablaEjemplares.Contains(e.Clave))
            {
                foreach (EjemplarDato ed in TablaEjemplares)
                {
                    if (ed.Clave.Equals(e.Clave))
                        return ed;
                }
            }
            return null;
        }

        public static bool UPDATE(EjemplarDato e)
        {
            if (TablaEjemplares.Contains(e.Clave))
            {
                DELETE(e);
                INSERT(e);
                return true;
            }
            return false;
        }

        public static bool DELETE(EjemplarDato e)
        {
            if (TablaEjemplares.Contains(e.Clave))
            {
                TablaEjemplares.Remove(e.Clave);
                return true;
            }
            return false;
        }

        //PRESTAMO
        public static bool INSERT(PrestamoDato p)
        {
            if (TablaPrestamos.Contains(p.Clave))
                return false;
            TablaPrestamos.Add(p);
            return true;
        }

        public static PrestamoDato READ(PrestamoDato p)
        {
            if (TablaPrestamos.Contains(p.Clave))
            {
                foreach (PrestamoDato pd in TablaPrestamos)
                {
                    if (pd.Clave.Equals(p.Clave))
                        return pd;
                }
            }
            return null;
        }

        public static bool UPDATE(PrestamoDato p)
        {
            if (TablaPrestamos.Contains(p.Clave))
            {
                DELETE(p);
                INSERT(p);
                return true;
            }
            return false;
        }

        public static bool DELETE(PrestamoDato p)
        {
            if (TablaPrestamos.Contains(p.Clave))
            {
                TablaPrestamos.Remove(p.Clave);
                return true;
            }
            return false;
        }

        //EJEMPLAR_PRESTAMO
        public static bool INSERT(PrestamoEjemplarDato e)
        {
            if (tablaPrestamoEjemplar.Contains(e.Clave))
                return false;
            tablaPrestamoEjemplar.Add(e);
            return true;
        }

        public static PrestamoEjemplarDato READ(PrestamoEjemplarDato e)
        {
            if (tablaPrestamoEjemplar.Contains(e.Clave))
            {
                foreach (PrestamoEjemplarDato ed in tablaPrestamoEjemplar)
                {
                    if (ed.Clave.Equals(e.Clave))
                        return ed;
                }
            }
            return null;
        }

        public static bool UPDATE(PrestamoEjemplarDato e)
        {
            if (tablaPrestamoEjemplar.Contains(e.Clave))
            {
                DELETE(e);
                INSERT(e);
                return true;
            }
            return false;
        }

        public static bool DELETE(PrestamoEjemplarDato e)
        {
            if (tablaPrestamoEjemplar.Contains(e.Clave))
            {
                tablaPrestamoEjemplar.Remove(e.Clave);
                return true;
            }
            return false;
        }
    }
}
