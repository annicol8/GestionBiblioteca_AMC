using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //private static Tabla<> tablaPrestamoEjemplar;

        private static Tabla<string, UsuarioDato> tablaUsuarios;

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


    }
}
