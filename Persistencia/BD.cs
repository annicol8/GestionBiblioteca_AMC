using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
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


        public static void CargarDatosPrueba()
        {
            TablaPersonales.Add(new PersonalDato("12345678A", "Juan", TipoPersonal.personalSala));
            TablaPersonales.Add(new PersonalDato("87654321B", "María", TipoPersonal.personalAdquisiciones));

            TablaLibrosPapel.Add(new LibroPapelDato("123A", "Quijote", "Cervantes", "alaDelta", 2002));


            TablaLibrosPapel.Add(new LibroPapelDato(
                "978-0-13-468599-1",
                "Clean Code",
                "Robert C. Martin",
                "Prentice Hall",
                2008
            ));

            TablaLibrosPapel.Add(new LibroPapelDato(
                "978-0-13-235088-4",
                "Clean Architecture",
                "Robert C. Martin",
                "Prentice Hall",
                2017
            ));

            TablaLibrosPapel.Add(new LibroPapelDato(
                "978-0-13-957331-8",
                "Refactoring",
                "Martin Fowler",
                "Addison-Wesley",
                1999
            ));

            // AUDIOLIBROS
            TablaAudioLibros.Add(new AudioLibroDato(
                "978-1-4001-2345-6",
                "El Quijote",
                "Miguel de Cervantes",
                "Santillana",
                2020, "CD", 114
            ));


            // EJEMPLARES (usando el DNI del personal de adquisiciones que acabamos de crear)
            TablaEjemplares.Add(new EjemplarDato(1, "978-0-13-468599-1", true, "87654321B"));
            TablaEjemplares.Add(new EjemplarDato(2, "978-0-13-468599-1", true, "87654321B"));
            TablaEjemplares.Add(new EjemplarDato(3, "978-0-13-235088-4", true, "87654321B"));

            // USUARIOS
            TablaUsuarios.Add(new UsuarioDato(
                "11111111C",
                "Pedro Gómez",
                true
            ));

            // PRESTAMO
            int idPrestamo = GenerarIdPrestamo();

            TablaPrestamos.Add(new PrestamoDato(
                idPrestamo,
                DateTime.Now,
                DateTime.Now.AddDays(15),
                EstadoPrestamo.enProceso,
                "11111111C",   // DNI Usuario
                "12345678A"    // DNI Personal (personal de sala)
            ));

            // PRESTAMO - EJEMPLARES
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo,
                1,
                DateTime.MinValue // aún no devuelto
            ));

            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo,
                2,
                DateTime.MinValue
            ));

        }


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

        public static Tabla<ClavePrestamoEjemplar, PrestamoEjemplarDato> TablaPrestamoEjemplar
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

        //CRUD GENERICO PARA TODOS
        public static bool INSERT<TKey, TValue>(Tabla<TKey, TValue> tabla, TValue elemento)
            where TValue : Entity<TKey>
        {
            if (tabla.Contains(elemento.Clave))
            {
                return false;
            }
            tabla.Add(elemento);
            return true;
        }

        public static TValue READ<TKey, TValue>(Tabla<TKey, TValue> tabla, TValue elemento)
            where TValue : Entity<TKey>
        {
            if (tabla.Contains(elemento.Clave))
            {
                foreach (TValue item in tabla)
                {
                    if (item.Clave.Equals(elemento.Clave))
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public static bool UPDATE<TKey, TValue>(Tabla<TKey, TValue> tabla, TValue elemento)
            where TValue : Entity<TKey>
        {
            if (tabla.Contains(elemento.Clave))
            {
                DELETE(tabla, elemento);
                INSERT(tabla, elemento);
                return true;
            }
            return false;
        }

        public static bool DELETE<TKey, TValue>(Tabla<TKey, TValue> tabla, TValue elemento)
            where TValue : Entity<TKey>
        {
            if (tabla.Contains(elemento.Clave))
            {
                tabla.Remove(elemento.Clave);
                return true;
            }
            return false;
        }

        public static List<TValue> READ_ALL<TKey, TValue>(Tabla<TKey, TValue> tabla)
            where TValue : Entity<TKey>
        {
            List<TValue> lista = new List<TValue>();
            foreach (TValue item in tabla)
            {
                lista.Add(item);
            }
            return lista;
        }


    }
}
