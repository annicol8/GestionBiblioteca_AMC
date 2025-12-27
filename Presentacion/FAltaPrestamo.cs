using System;
using System.Collections.Generic;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FAltaPrestamo : FComun
    {
        private ILNPSala lnSala;
        private List<EjemplarPrestamoDisplay> ejemplaresAñadidos;
        public FAltaPrestamo() : base()
        {
            InitializeComponent();
            ejemplaresAñadidos = new List<EjemplarPrestamoDisplay>();

        }
        public FAltaPrestamo(ILNPSala lnSala) : this()
        {
            this.lnSala = lnSala;
        }

        private void FAltaPrestamo_Load(object sender, System.EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                List<Usuario> usuariosActivos = lnSala.GetUsuariosActivos();

                if (usuariosActivos.Count == 0)
                {
                    MostrarAdvertencia("No hay usuarios activos en el sistema.");
                    btAceptar.Enabled = false;
                    return;
                }
                cbUsuarios.DataSource = usuariosActivos;
                cbUsuarios.DisplayMember = "Dni"; // Muestra el DNI
                cbUsuarios.ValueMember = "Dni";   // Valor es el DNI
                cbUsuarios.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "cargar los usuarios");
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btAñadirEjemplar_Click(object sender, EventArgs e)
        {
            try
            {
                FAñadirEjemplarPrestamo formulario = new FAñadirEjemplarPrestamo(lnSala, ejemplaresAñadidos);
            }
        }
    }
}
