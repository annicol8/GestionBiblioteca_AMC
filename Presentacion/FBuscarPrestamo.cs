using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FBuscarPrestamo : FComun
    {
        private ILNPSala lnSala;
        private Prestamo prestamo;
        private List<Ejemplar> ejemplaresNoDevueltos;



        public FBuscarPrestamo()
        {
            InitializeComponent();
        }
        /* PRE: lnSala != null, prestamo != null
   POST: Inicializa el formulario con los datos necesarios para mostrar un préstamo */
        public FBuscarPrestamo(ILNPSala lnSala, Prestamo prestamo) : this()
        {
            this.lnSala = lnSala;
            this.prestamo = prestamo;
        }
        /* PRE: prestamo != null, lnSala inicializado
    POST: Carga y muestra los datos del préstamo */
        private void FBuscarPrestamo_Load(object sender, EventArgs e)
        {
            MostrarDatosPrestamo();
        }
        /* PRE: prestamo != null, lnSala inicializado
   POST: Muestra la información del préstamo y carga los ejemplares asociados en el listBox */
        private void MostrarDatosPrestamo()
        {
            textBoxCodigo.Text = prestamo.Id.ToString();
            textBoxFecha.Text = prestamo.FechaPrestamo.ToShortDateString();
            textBoxUsuario.Text = prestamo.DniUsuario;

            listBoxEjemplares.DisplayMember = "InfoCompleta";

            if (prestamo.Estado == EstadoPrestamo.enProceso)
            {
                labelEstado.Text = "Activo";
            }
            else
            {
                labelEstado.Text = "Finalizado";
            }

            ejemplaresNoDevueltos = lnSala.GetEjemplaresNoDevueltos(prestamo.Id);


            listBoxEjemplares.Items.Clear();
            foreach (Ejemplar ej in lnSala.GetEjemplaresDePrestamo(prestamo.Id))
            {
                listBoxEjemplares.Items.Add(ej);
            }
        }
        /* PRE: ejemplaresNoDevueltos inicializado
   POST: Dibuja cada ejemplar en el listBox con color naranja si no está devuelto
         y verde si ya fue devuelto */
        private void listBoxEjemplares_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            Ejemplar ej = (Ejemplar)listBoxEjemplares.Items[e.Index];

            bool noDevuelto = false;

            foreach (Ejemplar eNoDev in ejemplaresNoDevueltos)
            {
                if (eNoDev.Codigo == ej.Codigo)
                {
                    noDevuelto = true;
                    break;
                }
            }

            Color fondo = noDevuelto
                ? Color.Orange
                : Color.LightGreen;

            e.Graphics.FillRectangle(
                new SolidBrush(fondo),
                e.Bounds
            );

            TextRenderer.DrawText(
                e.Graphics,
                ej.InfoCompleta,
                e.Font,
                e.Bounds,
                Color.Black,
                TextFormatFlags.Left
            );

            e.DrawFocusRectangle();
        }
    }
}
