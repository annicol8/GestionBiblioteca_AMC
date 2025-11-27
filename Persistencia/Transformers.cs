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
        // EJEMPLAR
        public static Ejemplar EjemplarDatoAEjemplar(EjemplarDato ed) 
        {
            return new Ejemplar(ed.Codigo); 
        }

        public static EjemplarDato EjemplarAEjemplarDato(Ejemplar e)
        {
            return new EjemplarDato(e.Codigo, e.IsbnDocumento, e.Activo);
        }

        //PRESTAMO
        public static Prestamo PrestamoDatoAPrestamo(PrestamoDato pd)
        {
            return new Prestamo();
        }

        public static PrestamoDato PrestamoAPrestamoEjemplar(Prestamo p)
        {
            new PrestamoDato(p.Id, p.FechaPrestamo, p.FechaDevolucion, p.Estado, p.DniPersonal, p.DniUsuario, p.prestamoEjemplares);
        }

        //PERSONAL
        public static Personal PersonalDatoAPersonal(PersonalDato pd)
        {
            return new Personal();
        }

        public static PersonalDato PersonalAPersonalDato(Personal p)
        {
            return new PersonalDato();
        }

        //LIBROS
        public static Documento DocumentoADocumentoDato(Documento d)
        {
            return new Documento();
        } 

        public static DocumentoDato DocumentoDatoADocumento(DocumentoDato dd)
        {
            return new DocumentoDato();
        }


        





        

  
    }
}
