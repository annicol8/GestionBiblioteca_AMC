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
        public static void create(Usuario usuario)
        {
            UsuarioDato uDato = Transformers.UsuarioAUsuarioDato(usuario);
            BD.TablaUsuarios.Add(uDato);
        }

        public static Usuario read(Usuario usuario)
        {
            if (BD.TablaUsuarios.Contains(usuario.Dni))
            {
                UsuarioDato uDato = BD.TablaUsuarios[usuario.Dni];
                return Transformers.UsuarioDatoAUsuario(uDato);
            }
            return null;
        }

        static void update(Usuario usuario)
        {
            if (BD.TablaUsuarios.Contains(usuario.Dni))
            {
                BD.TablaUsuarios.Remove(usuario.Dni);
                create(usuario);
            }
        }

        public static void delete(Usuario usuario)
        {
            if (BD.TablaUsuarios.Contains(usuario.Dni))
            {
                BD.TablaUsuarios.Remove(usuario.Dni);
            }
        }

        public static List<Usuario> ReadAllUsuarios()
        {
            return BD.TablaUsuarios.Select(dato => Transformers.UsuarioDatoAUsuario(dato)).ToList();
        }

        //PERSONAL
        public static void create(Personal personal)
        {
            PersonalDato pDato = Transformers.PersonalAPersonalDato(personal);
            BD.TablaPersonales.Add(pDato);
        }

        public static Personal read(Personal personal)
        {
            if (BD.TablaPersonales.Contains(personal.Dni))
            {
                PersonalDato dato = BD.TablaPersonales[personal.Dni];
                return Transformers.PersonalDatoAPersonal(dato);
            }
            return null;
        }

        public static void delete(Personal personal)
        {
            if (BD.TablaUsuarios.Contains(personal.Dni))
            {
                BD.TablaUsuarios.Remove(personal.Dni);
            }
        }

        public static void update(Personal personal)
        {
            if (BD.TablaPersonales.Contains(personal.Dni))
            {
                BD.TablaUsuarios.Remove(personal.Dni);
                create(personal);
            }
        }

        public static List<Personal> ReadAllPersonal()
        {
            return BD.TablaPersonales.Select(dato => Transformers.PersonalDatoAPersonal(dato)).ToList();
        }

        //DOCUMENTO
        public static void create(Documento documento)
        {
            DocumentoDato dDato = Transformers.DocumentoADocumentoDato(documento);
            BD.TablaDocumentos.Add(dDato);
        }

        public static Documento read(Documento documento)
        {
            if (BD.TablaDocumentos.Contains(documento))
            {
                DocumentoDato dDato = BD.TablaDocumentos[documento.Isbn];
                return Transformers.DocumentoDatoADocumento(dDato);
            }
            return null;
        }

        public static void update(Documento documento)
        {
            if (BD.TablaDocumentos.Contains(documento.Isbn))
            {
                BD.TablaDocumentos.Remove(documento.Isbn);
                create(documento);
            }
        }

        public static void delete(Documento documento)
        {
            if (BD.TablaDocumentos.Contains(documento.Isbn))
            {
                BD.TablaDocumentos.Remove(documento.Isbn);
            }
        }

        public static List<Documento> readAllDocumentos()
        {
            return BD.TablaDocumentos.Select(dato => Transformers.DocumentoDatoADocumento(dato)).ToList();
        }

        //EJEMPLAR
        public static void create(Ejemplar ejemplar)
        {
            EjemplarDato eDato = Transformers.EjemplarAEjemplarDato(ejemplar);
            BD.TablaEjemplares.Add(eDato);
        }

        public static Ejemplar read(Ejemplar ejemplar)
        {
            if (BD.TablaEjemplares.Contains(ejemplar.Codigo))
            {
                EjemplarDato eDato = BD.TablaEjemplares[ejemplar.Codigo];
                return Transformers.EjemplarDatoAEjemplar(eDato);
            }
            return null;
        }






    }
}
