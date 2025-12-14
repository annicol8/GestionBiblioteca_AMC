using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using LogicaNegocio;
using ModeloDominio;
using Persistencia;
using Presentacion;
using static System.Net.Mime.MediaTypeNames;

namespace Principal
{
    public class Programa
    {
        [STAThread]

        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            /*
            Console.WriteLine("Programa principal de la aplicación.");

            

            List<Usuario> listaUsuarios = new List<Usuario>
            {
                new Usuario("18090407X","Clara", true)
            };

            List<Personal> listaPersonal = new List<Personal>();
            List<Documento> listaDocumentos = new List<Documento>();
            List<Ejemplar> listaEjemplares = new List<Ejemplar>();

            LNDocumentos lNDocumentos = new LNDocumentos(listaDocumentos); //Igual algo conjunto?
            LNEjemplares lNEjemplares = new LNEjemplares(listaEjemplares);


            LNPersonal lNPersonal = new LNPersonal(listaPersonal);
            LNUsuarios lNUsuarios = new LNUsuarios(listaUsuarios);

            FLogin login = new FLogin(lNPersonal, lNDocumentos, lNEjemplares, lNUsuarios);

            Application.Run(login);
            */

            FLogin login = new FLogin();

            System.Windows.Forms.Application.Run(login);


        }
    }
}
