using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FAñadirEjemplarPrestamo : Form
    {
        private ILNPSala lnSala;
        private List<EjemplarPrestamoDisplay> ejemplaresAñadidos;
        private Ejemplar ejemplarSeleccionado;

        public Ejemplar EjemplarSeleccionado { get; private set; }

        public FAñadirEjemplarPrestamo() : base()
        {
            InitializeComponent();
        }

        public FAñadirEjemplarPrestamo(ILNPSala lnSala, List<EjemplarPrestamoDisplay> ejemplaresAñadidos) : this()
        {
            this.lnSala = lnSala;
            this.ejemplaresAñadidos = ejemplaresAñadidos;
        }

        private void FAñadirEjemplarPrestamo_Load(object sender, System.EventArgs e)
        {
            CargarEjemplaresDisponibles();
        }

        private void CargarEjemplaresDisponibles()
        {
            throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
