using System;
using ModeloDominio;


namespace Persistencia
{
    internal static class Transformers
    {
        //USUARIO
        /*
PRE: uDato != null
POST: devuelve un objeto Usuario creado a partir de los datos de uDato
*/
        public static Usuario UsuarioDatoAUsuario(UsuarioDato uDato)
        {
            return new Usuario(uDato.Clave, uDato.Nombre, uDato.DadoAlta);
        }

        /*
PRE: u != null
POST: devuelve un objeto UsuarioDato creado a partir de los datos de u
*/
        public static UsuarioDato UsuarioAUsuarioDato(Usuario u)
        {
            return new UsuarioDato(u.Dni, u.Nombre, u.DadoAlta);
        }

        //PERSONAL
        /*
PRE: pDato != null
POST: devuelve un PersonalSala si el tipo es personalSala, 
      PersonalAdquisiciones si el tipo es personalAdquisiciones
*/
        public static Personal PersonalDatoAPersonal(PersonalDato pDato)
        {
            if (pDato.TipoPersonal.Equals(TipoPersonal.personalSala))
            {
                return new PersonalSala(pDato.Clave, pDato.Nombre, pDato.Contraseña);
            }
            return new PersonalAdquisiciones(pDato.Clave, pDato.Nombre, pDato.Contraseña);
        }

        /*
PRE: p != null
POST: devuelve un objeto PersonalDato creado a partir de los datos de p
*/
        public static PersonalDato PersonalAPersonalDato(Personal p)
        {
            return new PersonalDato(p.Dni, p.Nombre, p.Contraseña, p.Tipo);
        }

        //LIBRO PAPEL

        /*
        PRE: lpDato != null
        POST: devuelve un objeto LibroPapel creado a partir de los datos de lpDato
        */
        public static LibroPapel LibroPapelDatoALibroPapel(LibroPapelDato lpDato)
        {
            return new LibroPapel(lpDato.Clave, lpDato.Titulo, lpDato.Autor, lpDato.Editorial, lpDato.AnoEdicion);
        }
        /*
PRE: lp != null
POST: devuelve un objeto LibroPapelDato creado a partir de los datos de lp
*/
        public static LibroPapelDato LibroPapelALibroPapelDato(LibroPapel lp)
        {
            return new LibroPapelDato(lp.Isbn, lp.Titulo, lp.Autor, lp.Editorial, lp.AnoEdicion);
        }

        //AUDIOLIBRO
        /*
PRE: alDato != null
POST: devuelve un objeto AudioLibro creado a partir de los datos de alDato
*/
        public static AudioLibro AudioLibroDatoAAudioLibro(AudioLibroDato alDato)
        {
            return new AudioLibro(alDato.Clave, alDato.Titulo, alDato.Autor, alDato.Editorial, alDato.AnoEdicion, alDato.FormatoDigital, alDato.Duracion);
        }
        /*
PRE: ad != null
POST: devuelve un objeto AudioLibroDato creado a partir de los datos de ad
*/
        public static AudioLibroDato AudioLibroAAudioLibroDato(AudioLibro ad)
        {
            return new AudioLibroDato(ad.Isbn, ad.Titulo, ad.Autor, ad.Editorial, ad.AnoEdicion, ad.FormatoDigital, ad.Duracion);
        }

        // EJEMPLAR
        /*
PRE: eDato != null
POST: devuelve un objeto Ejemplar creado a partir de los datos de eDato
*/
        public static Ejemplar EjemplarDatoAEjemplar(EjemplarDato eDato)
        {
            return new Ejemplar(eDato.Clave, eDato.Activo, eDato.IsbnDocumento, eDato.DniPersonalAdq);
        }

        /*
PRE: e != null
POST: devuelve un objeto EjemplarDato creado a partir de los datos de e
*/
        public static EjemplarDato EjemplarAEjemplarDato(Ejemplar e)
        {
            return new EjemplarDato(e.Codigo, e.IsbnDocumento, e.Activo, e.DniPAdq);
        }


        //PRESTAMO
        /*
PRE: pDato != null
POST: devuelve un objeto Prestamo creado a partir de los datos de pDato
*/
        public static Prestamo PrestamoDatoAPrestamo(PrestamoDato pDato)
        {
            return new Prestamo(pDato.Clave, pDato.FechaPrestamo, pDato.FechaDevolucion, pDato.Estado, pDato.DniUsuario, pDato.DniPersonal);
        }
        /*
PRE: p != null
POST: devuelve un objeto PrestamoDato creado a partir de los datos de p
*/
        public static PrestamoDato PrestamoAPrestamoDato(Prestamo p)
        {
            return new PrestamoDato(p.Id, p.FechaPrestamo, p.FechaDevolucion, p.Estado, p.DniUsuario, p.DniPersonal);
        }

        //PRESTAMO_EJEMPLAR
        /*
PRE: idPrestamo > 0 && codigoEjemplar > 0
POST: devuelve un objeto PrestamoEjemplarDato con los parámetros proporcionados
*/
        public static PrestamoEjemplarDato PrestamoEjemplarAPrestamoEjemplarDato(int idPrestamo, int codigoEjemplar, DateTime fechaDevolucion)
        {
            return new PrestamoEjemplarDato(idPrestamo, codigoEjemplar, fechaDevolucion);
        }


    }
}
