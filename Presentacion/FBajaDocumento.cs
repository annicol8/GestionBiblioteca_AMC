using System;
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

        /* PRE: lnAdq != null, documento != null
   POST: Inicializa el formulario con los datos necesarios para dar de baja un documento */

        public FBajaDocumento(ILNPAdq lnAdq, Documento documento) : this()
        {
            this.lnAdq = lnAdq;
            this.documento = documento;
        }

        /* PRE: documento != null
   POST: Carga y muestra la información del documento en modo solo lectura.
         Si documento es null, cierra el formulario con DialogResult.Cancel */
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

            if (documento is LibroPapel)
            {
                lblTipoDocumento.Text = "Tipo: Libro en papel";
                lblDuracion.Visible = false;
                lblFormatoDigital.Visible = false;

            }
            else if (documento is AudioLibro)
            {
                lblTipoDocumento.Text = "Tipo: Audiolibro";
                AudioLibro audio = (AudioLibro)documento;


                lblFormatoDigital.Visible = true;
                lblDuracion.Visible = true;
                lblFormatoDigital.Text = $"Formato: {audio.FormatoDigital}";
                TimeSpan duracion = TimeSpan.FromSeconds(audio.Duracion);
                lblDuracion.Text = $"Duración: {duracion:hh\\:mm\\:ss} ({audio.Duracion} seg)";

            }

            tbIsbn.ReadOnly = true;
            tbTitulo.ReadOnly = true;
            tbAutor.ReadOnly = true;
            tbEditorial.ReadOnly = true;
            tbAnoEdicion.ReadOnly = true;

            this.Text = $"Baja de Documento - {documento.Titulo}";

        }
        /* PRE: lnAdq y documento correctamente inicializados
   POST: Si el usuario confirma, elimina el documento y sus ejemplares asociados quedan inactivos.
         Cierra con DialogResult.OK si tiene éxito, muestra error en caso contrario */

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
                catch (Exception ex)
                {
                    MostrarError($"Error inesperado: {ex.Message}", "Error");
                }
            }
        }
        /* PRE: -
   POST: Cierra el formulario con DialogResult.Cancel */
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /* PRE: -
   POST: Si no se ha establecido DialogResult, lo pone a Cancel al cerrar */
        private void FBajaDocumento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
