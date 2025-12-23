using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;


namespace Persistencia
{
    internal static class Transformers
    {
        //USUARIO
        public static Usuario UsuarioDatoAUsuario(UsuarioDato uDato)
        {
            return new Usuario(uDato.Clave, uDato.Nombre, uDato.DadoAlta);
        }

        public static UsuarioDato UsuarioAUsuarioDato(Usuario u)
        {
            return new UsuarioDato(u.Dni, u.Nombre, u.DadoAlta); 
        }

        //PERSONAL
        public static Personal PersonalDatoAPersonal(PersonalDato pDato)
        {
            if (pDato.TipoPersonal.Equals(TipoPersonal.personalSala))
            {
                return new PersonalSala(pDato.Clave, pDato.Nombre, pDato.Contraseña);
            }
            return new PersonalAdquisiciones(pDato.Clave, pDato.Nombre, pDato.Contraseña);
        }

        public static PersonalDato PersonalAPersonalDato(Personal p)
        {
            return new PersonalDato(p.Dni, p.Nombre, p.Contraseña, p.Tipo);
        }

        //LIBRO PAPEL
        public static LibroPapel LibroPapelDatoALibroPapel(LibroPapelDato lpDato)
        {
            return new LibroPapel(lpDato.Clave, lpDato.Titulo, lpDato.Autor, lpDato.Editorial, lpDato.AnoEdicion);
        }

        public static LibroPapelDato LibroPapelALibroPapelDato(LibroPapel lp)
        {
            return new LibroPapelDato(lp.Isbn, lp.Titulo, lp.Autor, lp.Editorial, lp.AnoEdicion);
        }

        //AUDIOLIBRO
        public static AudioLibro AudioLibroDatoAAudioLibro(AudioLibroDato alDato)
        {
            return new AudioLibro(alDato.Clave, alDato.Titulo, alDato.Autor, alDato.Editorial, alDato.AnoEdicion, alDato.FormatoDigital, alDato.Duracion);
        }

        public static AudioLibroDato AudioLibroAAudioLibroDato (AudioLibro ad)
        {
            return new AudioLibroDato(ad.Isbn, ad.Titulo, ad.Autor, ad.Editorial, ad.AnoEdicion, ad.FormatoDigital, ad.Duracion);
        }
        /*HABÏA UNO IGUAL PERO AL REVÉS QUE HE BORRADO
        public static DocumentoDato DocumentoADocumentoDato (Documento d)
        {
            if (d.DiasPrestamoPermitidos() == 15) //Libros en papel
            {
                return new LibroPapelDato(d.Isbn, d.Titulo, d.Autor, d.Editorial, d.AnoEdicion);
            }
            else if (d.DiasPrestamoPermitidos() == 10) // AudioLibro
            {
                return new AudioLibroDato(d.Isbn, d.Titulo, d.Autor, d.Editorial, d.AnoEdicion, d.FormatoDigital, d.Duracion);
            }
        }
        */

        // EJEMPLAR
        public static Ejemplar EjemplarDatoAEjemplar(EjemplarDato eDato)
        {
            return new Ejemplar(eDato.Clave, eDato.Activo, eDato.IsbnDocumento, eDato.DniPersonalAdq);
        }

        public static EjemplarDato EjemplarAEjemplarDato(Ejemplar e)
        {
            return new EjemplarDato(e.Codigo, e.IsbnDocumento, e.Activo, e.DniPAdq);
        }


        //PRESTAMO
        public static Prestamo PrestamoDatoAPrestamo(PrestamoDato Pdato)
        {
            return new Prestamo(Pdato.Clave, Pdato.FechaPrestamo, Pdato.FechaDevolucion, Pdato.Estado, Pdato.DniUsuario, Pdato.DniPersonal);
        }

        public static PrestamoDato PrestamoAPrestamoDato(Prestamo p)
        {
            return new PrestamoDato(p.Id, p.FechaPrestamo, p.FechaDevolucion, p.Estado, p.DniUsuario, p.DniPersonal);
        }

        //PRESTAMO_EJEMPLAR
        public static PrestamoEjemplarDato PrestamoEjemplarAPrestamoEjemplarDato(int idPrestamo, int codigoEjemplar, DateTime fechaDevolucion)
        {
            return new PrestamoEjemplarDato(idPrestamo, codigoEjemplar, fechaDevolucion);
        }


    }
}
