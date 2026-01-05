using System;
using System.Collections.Generic;
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
            // PERSONALES - DNIs válidos con letras correctas
            TablaPersonales.Add(new PersonalDato("12345678Z", "Juan", "admin", TipoPersonal.personalSala));
            TablaPersonales.Add(new PersonalDato("87654321X", "María", "admin", TipoPersonal.personalAdquisiciones));
            TablaPersonales.Add(new PersonalDato("11223344Q", "Carlos", "admin", TipoPersonal.personalSala));
            TablaPersonales.Add(new PersonalDato("22334455J", "Laura", "admin", TipoPersonal.personalAdquisiciones));
            TablaPersonales.Add(new PersonalDato("33445566M", "Pedro", "admin", TipoPersonal.personalSala));
            TablaPersonales.Add(new PersonalDato("44556677W", "Ana", "admin", TipoPersonal.personalAdquisiciones));
            TablaPersonales.Add(new PersonalDato("55667788C", "Lucía", "admin", TipoPersonal.personalSala));
            TablaPersonales.Add(new PersonalDato("66778899S", "Miguel", "admin", TipoPersonal.personalAdquisiciones));
            TablaPersonales.Add(new PersonalDato("77889900P", "Elena", "admin", TipoPersonal.personalSala));
            TablaPersonales.Add(new PersonalDato("23456789H", "David", "admin", TipoPersonal.personalAdquisiciones));

            // LIBROS EN PAPEL - ISBNs válidos con dígitos de control correctos
            TablaLibrosPapel.Add(new LibroPapelDato(
                "978-84-667-0234-5",  // ISBN válido
                "Don Quijote",
                "Miguel De Cervantes",
                "Aladelta",
                2002
            ));

            TablaLibrosPapel.Add(new LibroPapelDato(
                "978-0-13-235088-4",  // ISBN válido
                "Clean Architecture",
                "Robert C. Martin",
                "Prentice Hall",
                2017
            ));

            TablaLibrosPapel.Add(new LibroPapelDato(
                "978-0-13-468599-1",  // ISBN válido
                "Clean Code",
                "Robert C. Martin",
                "Prentice Hall",
                2008
            ));

            TablaLibrosPapel.Add(new LibroPapelDato(
                "978-0-20-161622-4",  // ISBN válido
                "Refactoring",
                "Martin Fowler",
                "Addison-Wesley",
                1999
            ));

            TablaLibrosPapel.Add(new LibroPapelDato(
                "978-84-376-0494-7",  // ISBN válido
                "Cien Años De Soledad",
                "Gabriel García Márquez",
                "Sudamericana",
                1967
            ));

            // AUDIOLIBROS - ISBNs válidos
            TablaAudioLibros.Add(new AudioLibroDato(
                "978-84-204-8368-8",  // ISBN válido
                "El Quijote",
                "Miguel De Cervantes",
                "Santillana",
                2020, "CD", 680
            ));

            TablaAudioLibros.Add(new AudioLibroDato(
                "978-0-14-312774-3",  // ISBN válido
                "1984",
                "George Orwell",
                "Audible",
                2019, "MP3", 720
            ));

            TablaAudioLibros.Add(new AudioLibroDato(
                "978-0-14-311984-7",  // ISBN válido
                "Rebelión En La Granja",
                "George Orwell",
                "Audible",
                2018, "MP3", 180
            ));

            // EJEMPLARES - Con ISBNs correctos que existen en los documentos
            TablaEjemplares.Add(new EjemplarDato(1, "978-0-13-468599-1", true, "23456789H"));
            TablaEjemplares.Add(new EjemplarDato(2, "978-0-13-468599-1", true, "23456789H"));
            TablaEjemplares.Add(new EjemplarDato(3, "978-0-13-235088-4", true, "23456789H"));
            TablaEjemplares.Add(new EjemplarDato(4, "978-0-20-161622-4", true, "23456789H"));
            TablaEjemplares.Add(new EjemplarDato(5, "978-84-667-0234-5", true, "87654321X"));
            TablaEjemplares.Add(new EjemplarDato(6, "978-84-204-8368-8", true, "87654321X"));
            TablaEjemplares.Add(new EjemplarDato(7, "978-0-14-312774-3", true, "87654321X"));
            TablaEjemplares.Add(new EjemplarDato(8, "978-0-14-311984-7", true, "22334455J"));
            TablaEjemplares.Add(new EjemplarDato(9, "978-84-376-0494-7", true, "22334455J"));
            TablaEjemplares.Add(new EjemplarDato(10, "978-0-13-235088-4", true, "22334455J"));
            TablaEjemplares.Add(new EjemplarDato(11, "978-84-667-0234-5", true, "22334455J")); 
            TablaEjemplares.Add(new EjemplarDato(12, "978-0-14-312774-3", true, "22334455J"));
            TablaEjemplares.Add(new EjemplarDato(13, "978-84-376-0494-7", true, "22334455J"));


            // USUARIOS - DNIs válidos
            TablaUsuarios.Add(new UsuarioDato("45678901R", "Pedro ", true));
            TablaUsuarios.Add(new UsuarioDato("56789012E", "Eva ", true));
            TablaUsuarios.Add(new UsuarioDato("67890123D", "Carlos ", true));
            TablaUsuarios.Add(new UsuarioDato("78901234K", "Sofía ", true));
            TablaUsuarios.Add(new UsuarioDato("89012345T", "Javier ", false)); // Usuario dado de baja

            
            // ===== PRÉSTAMO 1 (En Proceso) =====
            int idPrestamo1 = GenerarIdPrestamo();

            TablaPrestamos.Add(new PrestamoDato(
                idPrestamo1,
                DateTime.Now.AddDays(-5),           // Hace 5 días
                DateTime.Now.AddDays(10),           // Vence en 10 días
                EstadoPrestamo.enProceso,
                "78901234K",   // DNI Usuario: Sofía
                "12345678Z"    // DNI Personal: Juan
            ));

            // Ejemplares del préstamo 1
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo1,
                1,              // Ejemplar de "Clean Code"
                DateTime.MinValue
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
                "56789012E",   // DNI Usuario: Eva
                "12345678Z"    // DNI Personal: Juan
            ));

            // Ejemplares del préstamo 2
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo2,
                3,              // Ejemplar de "Clean Architecture"
                DateTime.Now.AddDays(-7)
            ));

            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo2,
                4,              // Ejemplar de "Refactoring"
                DateTime.Now.AddDays(-7)
            ));

            // ===== PRÉSTAMO 3 (En Proceso - con varios libros) =====
            int idPrestamo3 = GenerarIdPrestamo();

            TablaPrestamos.Add(new PrestamoDato(
                idPrestamo3,
                DateTime.Now.AddDays(-2),           // Hace 2 días
                DateTime.Now.AddDays(13),           // Vence en 13 días
                EstadoPrestamo.enProceso,
                "67890123D",   // DNI Usuario: Carlos López
                "11223344Q"    // DNI Personal: Carlos
            ));

            // Ejemplares del préstamo 3
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo3,
                6,              // AudioLibro "El Quijote"
                DateTime.MinValue
            ));

            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo3,
                7,              // AudioLibro "1984"
                DateTime.MinValue
            ));

            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo3,
                5,              // Libro "Don Quijote" en papel
                DateTime.MinValue
            ));

            // ===== PRÉSTAMO 4 (Vencido - sin devolver) =====
            int idPrestamo4 = GenerarIdPrestamo();

            TablaPrestamos.Add(new PrestamoDato(
                idPrestamo4,
                DateTime.Now.AddDays(-25),          // Hace 25 días
                DateTime.Now.AddDays(-10),          // Venció hace 10 días
                EstadoPrestamo.enProceso,           // AÚN NO DEVUELTO (vencido)
                "45678901R",   // DNI Usuario: Pedro González
                "12345678Z"    // DNI Personal: Juan
            ));

            // Ejemplares del préstamo 4
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo4,
                9,              // Ejemplar de "Cien Años de Soledad"
                DateTime.MinValue
            ));

            // ===== PRÉSTAMO 5 (Finalizado - ejemplo de audiolibro) =====
            int idPrestamo5 = GenerarIdPrestamo();

            TablaPrestamos.Add(new PrestamoDato(
                idPrestamo5,
                DateTime.Now.AddDays(-30),          // Hace 30 días
                DateTime.Now.AddDays(-20),          // Venció hace 20 días
                EstadoPrestamo.finalizado,
                "78901234K",   // DNI Usuario: Sofía Rodríguez
                "87654321X"    // DNI Personal: María
            ));

            // Ejemplares del préstamo 5
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo5,
                8,              // AudioLibro "Rebelión en la granja"
                DateTime.Now.AddDays(-21)
            ));

            // ===== PRÉSTAMO 6 (Vencido - varios ejemplares sin devolver) =====
            int idPrestamo6 = GenerarIdPrestamo();

            TablaPrestamos.Add(new PrestamoDato(
                idPrestamo6,
                DateTime.Now.AddDays(-40),          // Hace 40 días
                DateTime.Now.AddDays(-15),          // Venció hace 15 días
                EstadoPrestamo.enProceso,           // VENCIDO
                "56789012E",   // DNI Usuario: Eva
                "87654321X"    // DNI Personal: María
            ));

            // Ejemplares del préstamo 6
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo6,
                10,             // Ejemplar de "La sombra del viento"
                DateTime.MinValue
            ));

            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo6,
                11,             // Ejemplar de "El nombre de la rosa"
                DateTime.MinValue
            ));


            // ===== PRÉSTAMO 7 (Vencido - uno devuelto y uno pendiente) =====
            int idPrestamo7 = GenerarIdPrestamo();

            TablaPrestamos.Add(new PrestamoDato(
                idPrestamo7,
                DateTime.Now.AddDays(-18),          // Hace 18 días
                DateTime.Now.AddDays(-3),           // Venció hace 3 días
                EstadoPrestamo.enProceso,           // VENCIDO
                "67890123D",   // DNI Usuario: Carlos López
                "12345678Z"    // DNI Personal: Juan
            ));

            // Ejemplar ya devuelto
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo7,
                12,             // Ejemplar de "El Principito"
                DateTime.Now.AddDays(-2)
            ));

            // Ejemplar NO devuelto
            TablaPrestamoEjemplar.Add(new PrestamoEjemplarDato(
                idPrestamo7,
                13,             // Ejemplar de "Rayuela"
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
                if (tablaPrestamoEjemplar == null) { tablaPrestamoEjemplar = new Tabla<ClavePrestamoEjemplar, PrestamoEjemplarDato>(); }
                return tablaPrestamoEjemplar;
            }
        }
        /*
PRE: ninguna
POST: devuelve un ID único aumentado 1
*/
        public static int GenerarIdPrestamo()
        {
            return ++ultimoIdPrestamo;
        }
        /*
PRE: tabla != null && elemento != null
POST: devuelve true si se insertó correctamente, false si ya existía un elemento con esa clave
*/
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
        /*
PRE: tabla != null && elemento != null
POST: devuelve el elemento si existe con esa clave, null en caso contrario
*/
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
        /*
PRE: tabla != null && elemento != null && existe un elemento con esa clave en la tabla
POST: devuelve true si se actualizó correctamente, false si no existía
*/
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
        /*
PRE: tabla != null && elemento != null && existe un elemento con esa clave en la tabla
POST: devuelve true si se eliminó correctamente, false si no existía
*/
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
        /*
PRE: tabla != null
POST: devuelve lista con todos los elementos de la tabla (puede estar vacía)
*/
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
