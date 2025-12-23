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

        public FBajaDocumento(ILNPAdq lnAdq, Documento documento) : this()
        {
            this.lnAdq = lnAdq;
            this.documento = documento;
        }
        
        private void FBajaDocumento_Load(object sender, EventArgs e)
        {
            if (documento == null)
            {
                MostrarError("No hay documento para dar de baja");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            tbIsbn.Text = documento.Isbn;
            tbTitulo.Text = documento.Titulo;
            tbAutor.Text = documento.Autor;
            tbEditorial.Text = documento.Editorial;
            tbAnoEdicion.Text = documento.AnoEdicion.ToString();

            // Mostrar tipo de documento
            if (documento is LibroPapel)
            {
                lblTipoDocumento.Text = "Tipo: Libro en papel";
                lblDuracion.Visible = false;
                lblFormatoDigital.Visible = false;

            }
            else if (documento is AudioLibro)
            {
                lblTipoDocumento.Text = "Tipo: Audiolibro";
                AudioLibro audio = (AudioLibro) documento;

                
                    lblFormatoDigital.Visible = true;
                    lblDuracion.Visible = true;
                    lblFormatoDigital.Text = $"Formato: {audio.FormatoDigital}";
                    //lblDuracion.Text = $"Duración: {audio.Duracion} seg";
                    TimeSpan duracion = TimeSpan.FromSeconds(audio.Duracion);
                    lblDuracion.Text = $"Duración: {duracion:hh\\:mm\\:ss} ({audio.Duracion} seg)";
                    // Resultado: "Duración: 01:05:30 (3930 seg)"
                
            }

            tbIsbn.ReadOnly = true;
            tbTitulo.ReadOnly = true;
            tbAutor.ReadOnly = true;
            tbEditorial.ReadOnly = true;
            tbAnoEdicion.ReadOnly = true;

            this.Text = $"Baja de Documento - {documento.Titulo}";

        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MostrarPregunta(
                "¿Está seguro que desea eliminar el documento?\nLos ejemplares asociados quedarán inactivos.\nEsta operación no se puede deshacer.",
                "Confirmación de eliminación"
            );

            if (dr == DialogResult.Yes)
            {
                try
                {
                    bool resultado = lnAdq.BajaDocumento(documento.Isbn);

                    if (resultado)
                    {
                        MostrarExito("Documento eliminado correctamente. Los ejemplares se han marcado como inactivos.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MostrarError("No se pudo eliminar el documento");
                    }
                }
                catch (InvalidOperationException ex)
                {
                    MostrarError(ex.Message, "Operación no permitida");
                }
                catch (ArgumentException ex)
                {
                    MostrarError(ex.Message, "Error de validación");
                }
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
