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
    public partial class FBajaDocumento : FComun
    {
        private ILNPAdq lnAdq;
        private Documento documento;

        public FBajaDocumento()
        {
            InitializeComponent();
        }

        public FBajaDocumento(ILNPAdq lnAdq, object documento) : this()
        {
            this.lnAdq = lnAdq;
            this.documento = documento;
        }

        private void FBajaDocumento_Load(object sender, EventArgs e)
        {
            tbIsbn.Text = documento.Isbn;
            tbTitulo.Text = documento.Titulo;
            tbAutor.Text = documento.Autor;
            tbEditorial.Text = documento.Editorial;
            tbAnoEdicion.Text = documento.AnoEdicion.ToString();

            // Mostrar tipo de documento
            if (documento is LibroPapel)
            {
                lblTipoDocumento.Text = "Tipo: Libro en papel";
            }
            else if (documento is AudioLibro)
            {
                lblTipoDocumento.Text = "Tipo: Audiolibro";
                AudioLibro audio = (AudioLibro) documento;

                if (lblFormatoDigital != null && lblDuracion != null)
                {
                    lblFormatoDigital.Visible = true;
                    lblDuracion.Visible = true;
                    lblFormatoDigital.Text = $"Formato: {audio.FormatoDigital}";
                    lblDuracion.Text = $"Duración: {audio.Duracion} seg";
                }
            }

            tbIsbn.ReadOnly = true;
            tbTitulo.ReadOnly = true;
            tbAutor.ReadOnly = true;
            tbEditorial.ReadOnly = true;
            tbAnoEdicion.ReadOnly = true;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MostrarPregunta(
                "¿Está seguro que desea dar de baja el documento?\nSe darán de baja también todos sus ejemplares asociados.",
                "Confirmación de baja"
            );

            if (dr == DialogResult.Yes)
            {
                try
                {
                    lnAdq.BajaDocumento(documento.Isbn);
                    MostrarExito("Documento eliminado correctamente. Los ejemplares se han marcado como inactivos.");
                    this.Close();
                }
                catch (InvalidOperationException ex)
                {
                    MostrarError(ex.Message);
                }
                catch (Exception ex)
                {
                    MostrarError($"Error al eliminar el documento: {ex.Message}");
                }
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
