using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FDevolverPrestamo : FComun
    {
        private ILNPSala lnSala;
        private Prestamo prestamo;
        public FDevolverPrestamo()
        {
            InitializeComponent();
        }

        public FDevolverPrestamo(ILNPSala lnSala, Prestamo prestamo) : this()
        {
            this.lnSala = lnSala;
            this.prestamo = prestamo;
        }

        private void FDevolverPrestamo_Load(object sender, EventArgs e)
        {
            listBoxEjemplares.Items.Clear();

            foreach (Ejemplar ej in lnSala.GetEjemplaresNoDevueltos(prestamo.Id))
            {
                listBoxEjemplares.Items.Add(ej);
            }
        }

        private void CargarEjemplaresPendientes()
        {
            
        }

        private void botonDevolver_Click(object sender, EventArgs e)
        {
            if (listBoxEjemplares.SelectedItems.Count == 0)
            {
                MostrarError("Debes seleccionar al menos un ejemplar");
                return;
            }

            DialogResult dr = MostrarPregunta(
                "¿Confirmar devolución?",
                "Se devolverán los ejemplares seleccionados"
            );

            if (dr != DialogResult.Yes)
                return;

            foreach (Ejemplar ej in listBoxEjemplares.SelectedItems)
            {
                lnSala.DevolverEjemplar(prestamo.Id, ej.Codigo);
            }

            MostrarExito("Ejemplares devueltos correctamente");
            this.Close();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
