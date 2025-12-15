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
    public partial class FListaDocumentos : Form
    {
        private ILNPAdq lnpa;
        private BindingSource bindingSourceDoc; //Docuemntos
        private BindingSource bindinSourceEjem; //Ejemplares
        
        public FListaDocumentos(ILNPAdq lnpa)
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
                dataGridView_Doc.DataSource = bindingSourceDoc;

            } catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los documentos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Doc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_Doc.CurrentRow != null && dataGridView_Doc.CurrentRow.DataBoundItem != null)
                {
                    Documento docSeleccionado = dataGridView_Doc.CurrentRow.DataBoundItem as Documento;
                    if (docSeleccionado != null)
                    {
                        bindinSourceEjem = new BindingSource();
                        bindinSourceEjem.DataSource = lnpa.ejemplaresPorDocumento(docSeleccionado.Isbn);

                        dataGridView_Ejemplares.DataSource = bindinSourceEjem;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ejemplares: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }

     /*
      * 
      * */
}
