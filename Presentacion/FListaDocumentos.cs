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
    public partial class FListaDocumentos : FComun
    {
        private ILNPAdq lnpa;
        private BindingSource bindingSourceDoc; //Docuemntos
        private BindingSource bindinSourceEjem; //Ejemplares
        
        public FListaDocumentos(ILNPAdq lnpa)
        {
            this.lnpa = lnpa;
            InitializeComponent();
            InicializarFormulario();

            dataGridView_Ejemplares.CellFormatting += dataGridView_Ejemplares_CellFormatting;
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
                MostrarError($"Error al cargar los documentos: {ex.Message}");
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
                MostrarError($"Error al cargar ejemplares: {ex.Message}");
            }
           
        }

        private void dataGridView_Ejemplares_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Solo aplicar formato a la columna DniPAdq
            if (dataGridView_Ejemplares.Columns[e.ColumnIndex].Name == "DniPAdq")
            {
                if (e.Value != null && e.RowIndex >= 0)
                {
                    string dni = e.Value.ToString();

                    // Obtener el personal por DNI
                    Personal personal = lnpa.GetPersonal(dni);

                    if (personal != null)
                    {
                        // Formatear como "DNI, Nombre"
                        e.Value = $"{dni}, {personal.Nombre}";
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        // Si no se encuentra el personal, mostrar solo el DNI
                        e.Value = $"{dni}, (Desconocido)";
                        e.FormattingApplied = true;
                    }
                }
            }
        }

    }

}
