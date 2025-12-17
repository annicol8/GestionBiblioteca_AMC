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
    public partial class FBajaEjemplar : FComun
    {
        private ILNPAdq lnAdq;
        private Ejemplar ejemplar;
        public FBajaEjemplar()
        {
            InitializeComponent();
        }

        public FBajaEjemplar(ILNPAdq lnAdq, Ejemplar ejemplar): this()
        {
            this.lnAdq = lnAdq;
            this.ejemplar = ejemplar;
        }

        private void FBajaEjemplar_Load(object sender, EventArgs e)
        {
            tbCodigo.Text = ejemplar.Codigo.ToString();
            tbIsbn.Text = ejemplar.IsbnDocumento;
            tbTitulo.Text = lnAdq.getDocumento(tbIsbn.Text).Titulo;
            tbEstado.Text = ejemplar.Activo ? "Activo" : "Inactivo";

            tbCodigo.ReadOnly = true;
            tbIsbn.ReadOnly = true;
            tbTitulo.ReadOnly = true;
            tbEstado.ReadOnly = true;

            this.Text = $"Baja de Ejemplar - Código: {ejemplar.Codigo}";
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (!ejemplar.Activo)
            {
                MostrarInformacion("El ejemplar ya está dado de baja.");
                return;
            }

            DialogResult dr = MostrarPregunta(
                "¿Está seguro que desea dar de baja este ejemplar?\nEsta operación no se puede deshacer.",
                "Confirmación de baja"
            );

            if (dr == DialogResult.Yes)
            {
                try
                {
                    lnAdq.BajaEjemplar(ejemplar.Codigo);
                    MostrarExito("Ejemplar dado de baja correctamente.");
                    this.Close();
                }
                catch (InvalidOperationException ex)
                {
                    MostrarError(ex.Message);
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                }
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
