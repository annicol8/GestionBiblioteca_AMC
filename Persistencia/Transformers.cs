using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;


namespace Persistencia
{
    internal class Transformers
    {
        //USUARIO
        public static Usuario UsuarioDatoAUsuario(UsuarioDato uDato)
        {
            return new Usuario(uDato.Dni, uDato.Nombre, uDato.DadoAlta);
        }

        public static UsuarioDato UsuarioAUsuarioDato(Usuario u)
        {
            return new UsuarioDato(u.Dni, u.getNombre, u.DadoAlta); //si pongo solo u.Nombre da error
        }

        //PERSONAL
        public static Personal PersonalDatoAPersonal(PersonalDato pDato)
        {
            if(pDato.TipoPersonal.Equals(TipoPersonal.personalSala))
            {
                return new PersonalSala(pDato.Dni, pDato.Nombre);
            }
            return new PersonalAdquisiciones(pDato.Dni, pDato.Nombre);
        }

        public static PersonalDato PersonalAPersonalDato(Personal p)
        {
            return new PersonalDato(p.Dni, p.Nombre, p.Tipo);
        }

        //DOCUMENTO
        public static Documento DocumentoDatoADocumento(DocumentoDato dDato)
        {
            if (dDato is LibroPapelDato lpDato) //Libros en papel
            { 
                return new LibroPapel(lpDato.Isbn, lpDato.Titulo, lpDato.Autor, lpDato.Editorial, lpDato.AnoEdicion);
            }
            else if (dDato is AudioLibroDato alDato) // AudioLibro
            {
                return new AudioLibro(alDato.Isbn, alDato.Titulo, alDato.Autor, alDato.Editorial, alDato.AnoEdicion, alDato.FormatoDigital, alDato.Duracion);
            }
        }

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

        // EJEMPLAR
        public static Ejemplar EjemplarDatoAEjemplar(EjemplarDato eDato)
        {
            return new Ejemplar(eDato.Codigo, eDato.Activo, eDato.Isbn, eDato.DniPersonalAdq);
        }

        public static EjemplarDato EjemplarAEjemplarDato(Ejemplar e)
        {
            return new EjemplarDato(e.Codigo, e.IsbnDocumento, e.Activo, e.DniPAdq);
        }


        //PRESTAMO
        public static Prestamo PrestamoDatoAPrestamo(PrestamoDato Pdato)
        {
            return new Prestamo(Pdato.Id, Pdato.FechaPrestamo, Pdato.FechaDevolucion, Pdato.Estado, Pdato.DniUsuario, Pdato.DniPersonal);
        }

        public static PrestamoDato PrestamoAPrestamoDato(Prestamo p)
        {
            return new PrestamoDato(p.Id, p.FechaPrestamo, p.FechaDevolucion, p.Estado, p.DniUsuario, p.DniPersonal);
        }
        

  
    }
}
