using System;
using System.Collections;
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

        //PRE: lnpa != null
        //POST: El formulario queda inicializado y enlazado a la fuente de documentos
        public FDocumentosUnoAUno(ILNPAdq lnpa)
        {
            this.lnpa = lnpa;
            InitializeComponent();
            InicializarFormulario();
        }

        //PRE: lnpa ha sido inicializado correctamente
        //POST: bindingSourceDoc queda asociado a los documentos
        //      Los controles del formulario quedan enlazados a los campos del documento Se muestra el documento actual
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

        //PRE: bindingSourceDoc != null
        //POST: Se actualiza la visualización del documento actual
        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            MostrarDocumentoActual();
        }

        //PRE: bindingSourceDoc != null
        //POST: Si el documento actual es AudioLibro, se muestran sus campos específicos
        //      Si no es AudioLibro, se ocultan los campos específicos
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

        //PRE: al != null
        //POST: Los campos específicos de AudioLibro quedan visibles
        //      Los valores de formato, duración y tipo se muestran correctamente
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

        //PRE: 
        //POST: Los campos específicos de AudioLibro quedan ocultos. Los valores de formato y duración se limpian
        //      El tipo de documento se establece como "Libro Papel"
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
