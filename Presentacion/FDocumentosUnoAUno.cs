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
    public partial class FDocumentosUnoAUno : FComun
    {
        private ILNPAdq lnpa;
        private BindingSource bindingSourceDoc;
        public FDocumentosUnoAUno(ILNPAdq lnpa)
        {
            InitializeComponent();
            this.lnpa = lnpa;
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            try
            {
                bindingSourceDoc = new BindingSource();
                bindingSourceDoc.DataSource = lnpa.getDocumentos();

                bindingNavigator1.BindingSource = bindingSourceDoc;

                //Campos comunes a ambos tipos de documentos
                textBox_Isbn.DataBindings.Add("Text", bindingSourceDoc, "Isbn");
                textBox_Titulo.DataBindings.Add("Text", bindingSourceDoc, "Titulo");
                textBox_Autor.DataBindings.Add("Text", bindingSourceDoc, "Autor");
                textBox_Editorial.DataBindings.Add("Text", bindingSourceDoc, "Editorial");
                textBox_Ano.DataBindings.Add("Text", bindingSourceDoc, "AnoEdicion");

                bindingSourceDoc.CurrentChanged += BindingSource_CurrentChanged;

                MostrarDocumentoActual();

            }
            catch (Exception ex)
            {
                MostrarError($"Error al inicializar el formulario: {ex.Message}");
            }
        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            MostrarDocumentoActual();
        }
            
        private void MostrarDocumentoActual()
        {
            if (bindingSourceDoc.Current != null)
            {
                Documento doc = bindingSourceDoc.Current as Documento;
                
                if (doc is AudioLibro al)
                {
                    MostrarCamposAudioLibro(al);
                } else
                {
                    OcultarCamposAudioLibro();
                }

            }
        }

        private void MostrarCamposAudioLibro(AudioLibro al)
        {
            // Mostrar controles
            lb_Formato.Visible = true;
            textBox_Formato.Visible = true;
            lb_Duracion.Visible = true;
            textBox_Duracion.Visible = true;

            // Asignar valores
            textBox_Formato.Text = al.FormatoDigital ?? "N/A";
            textBox_Duracion.Text = al.Duracion.ToString() + " min";

            textBox_Tipo.Text = "Audio Libro";
        }

        private void OcultarCamposAudioLibro()
        {
            // Ocultar controles
            lb_Formato.Visible = false;
            textBox_Formato.Visible = false;
            lb_Duracion.Visible = false;
            textBox_Duracion.Visible = false;

            // Limpiar valores
            textBox_Formato.Text = "";
            textBox_Duracion.Text = "";

            textBox_Tipo.Text = "Libro Papel";
        }
    }

}
