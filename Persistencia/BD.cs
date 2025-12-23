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
            TablaPersonales.Add(new PersonalDato("12345678A", "Juan", "admin", TipoPersonal.personalSala));
            TablaPersonales.Add(new PersonalDato("87654321B", "María", "admin", TipoPersonal.personalAdquisiciones));
            TablaPersonales.Add(new PersonalDato("11223344C", "Carlos", "admin", TipoPersonal.personalSala));
            TablaPersonales.Add(new PersonalDato("22334455D", "Laura", "admin", TipoPersonal.personalAdquisiciones));
            TablaPersonales.Add(new PersonalDato("33445566E", "Pedro", "admin", TipoPersonal.personalSala));
            TablaPersonales.Add(new PersonalDato("44556677F", "Ana", "admin", TipoPersonal.personalAdquisiciones));
            TablaPersonales.Add(new PersonalDato("55667788G", "Lucía", "admin", TipoPersonal.personalSala));
            TablaPersonales.Add(new PersonalDato("66778899H", "Miguel", "admin", TipoPersonal.personalAdquisiciones));
            TablaPersonales.Add(new PersonalDato("77889900J", "Elena", "admin", TipoPersonal.personalSala));
            TablaPersonales.Add(new PersonalDato("88990011K", "David", "admin", TipoPersonal.personalAdquisiciones));



            // LIBROS EN PAPEL
            TablaLibrosPapel.Add(new LibroPapelDato(
                "978-0-00-000000-2",
                "Quijote",
                "Cervantes",
                "alaDelta",
                2002
            ));

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
                "978-0-13-957331-6",
                "Refactoring",
                "Martin Fowler",
                "Addison-Wesley",
                1999
            ));

            // AUDIOLIBROS
            TablaAudioLibros.Add(new AudioLibroDato(
                "978-1-4001-2345-2",
                "El Quijote",
                "Miguel de Cervantes",
                "Santillana",
                2020, "CD", 114
            ));

            TablaAudioLibros.Add(new AudioLibroDato(
                "978-1-5555-7777-3",
                "1984",
                "George Orwell",
                "Audible",
                2019, "MP3", 180
            ));


        


            // EJEMPLARES
            TablaEjemplares.Add(new EjemplarDato(1, "978-0-13-468599-1", true, "87654321B"));
            TablaEjemplares.Add(new EjemplarDato(2, "978-0-13-468599-1", true, "87654321B"));
            TablaEjemplares.Add(new EjemplarDato(3, "978-0-13-235088-4", true, "87654321B"));
            TablaEjemplares.Add(new EjemplarDato(4, "978-0-13-957331-8", true, "87654321B"));
            TablaEjemplares.Add(new EjemplarDato(5, "978-1-4001-2345-6", true, "87654321B"));
            TablaEjemplares.Add(new EjemplarDato(6, "978-1-5555-7777-8", true, "87654321B"));
            TablaEjemplares.Add(new EjemplarDato(7, "123A", true, "87654321B"));

            // USUARIOS
            TablaUsuarios.Add(new UsuarioDato("11111111C", "Pedro", true));
            TablaUsuarios.Add(new UsuarioDato("11122233V", "Eva", true));
            TablaUsuarios.Add(new UsuarioDato("22233344D", "Carlos", true));

            // ===== PRÉSTAMO 1 (En Proceso) =====
            int idPrestamo1 = GenerarIdPrestamo();

            TablaPrestamos.Add(new PrestamoDato(
                idPrestamo1,
                DateTime.Now.AddDays(-5),           // Hace 5 días
                DateTime.Now.AddDays(10),           // Vence en 10 días
                EstadoPrestamo.enProceso,
                "11111111C",   // DNI Usuario: Pedro
                "12345678A"    // DNI Personal: Juan
            ));

            // Ejemplares del préstamo 1
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo1,
                1,              // Ejemplar de "Clean Code"
                DateTime.MinValue // aún no devuelto
            ));

            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo1,
                2,              // Otro ejemplar de "Clean Code"
                DateTime.MinValue
            ));

            // ===== PRÉSTAMO 2 (Finalizado) =====
            int idPrestamo2 = GenerarIdPrestamo();

            TablaPrestamos.Add(new PrestamoDato(
                idPrestamo2,
                DateTime.Now.AddDays(-20),          // Hace 20 días
                DateTime.Now.AddDays(-5),           // Venció hace 5 días
                EstadoPrestamo.finalizado,
                "11122233V",   // DNI Usuario: Eva
                "12345678A"    // DNI Personal: Juan
            ));

            // Ejemplares del préstamo 2
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo2,
                3,              // Ejemplar de "Clean Architecture"
                DateTime.Now.AddDays(-7) // Devuelto hace 7 días
            ));

            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo2,
                4,              // Ejemplar de "Refactoring"
                DateTime.Now.AddDays(-7) // Devuelto hace 7 días
            ));

            // ===== PRÉSTAMO 3 (En Proceso - con varios libros) =====
            int idPrestamo3 = GenerarIdPrestamo();

            TablaPrestamos.Add(new PrestamoDato(
                idPrestamo3,
                DateTime.Now.AddDays(-2),           // Hace 2 días
                DateTime.Now.AddDays(13),           // Vence en 13 días
                EstadoPrestamo.enProceso,
                "22233344D",   // DNI Usuario: Carlos
                "12345678A"    // DNI Personal: Juan
            ));

            // Ejemplares del préstamo 3
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo3,
                5,              // AudioLibro "El Quijote"
                DateTime.MinValue
            ));

            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo3,
                6,              // AudioLibro "1984"
                DateTime.MinValue
            ));

            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo3,
                7,              // Libro "Quijote" en papel
                DateTime.MinValue
            ));

            // ===== PRÉSTAMO 4 (Vencido - sin devolver) =====
            int idPrestamo4 = GenerarIdPrestamo();

            TablaPrestamos.Add(new PrestamoDato(
                idPrestamo4,
                DateTime.Now.AddDays(-25),          // Hace 25 días
                DateTime.Now.AddDays(-10),          // Venció hace 10 días
                EstadoPrestamo.enProceso,           // AÚN NO DEVUELTO (vencido)
                "11111111C",   // DNI Usuario: Pedro
                "12345678A"    // DNI Personal: Juan
            ));

            // Ejemplares del préstamo 4
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo4,
                4,              // Ejemplar de "Refactoring"
                DateTime.MinValue // NO devuelto
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
                if (tablaPrestamoEjemplar == null) { tablaPrestamoEjemplar = new Tabla<ClavePrestamoEjemplar, PrestamoEjemplarDato>(); }
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
