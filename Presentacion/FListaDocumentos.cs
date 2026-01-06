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

        //PRE: lnpa != null
        //POST: El formulario queda inicializado
        //      El DataGridView de documentos queda preparado para mostrar datos. Se asocia el evento CellFormatting al grid de ejemplares
        public FListaDocumentos(ILNPAdq lnpa)
        {
            this.lnpa = lnpa;
            InitializeComponent();
            InicializarFormulario();

            dataGridView_Ejemplares.CellFormatting += dataGridView_Ejemplares_CellFormatting;
        }

        //PRE: lnpa ha sido inicializado correctamente
        //POST: bindingSourceDoc queda asociado a la colección de documentos
        //      dataGridView_Doc muestra la lista de documentos
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

        //PRE: bindingSourceDoc ha sido inicializado
        //POST: Si hay un documento seleccionado, se cargan sus ejemplares
        //      dataGridView_Ejemplares muestra los ejemplares del documento seleccionado
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

        //PRE: lnpa ha sido inicializado correctamente. El evento corresponde a una celda válida del DataGridView de ejemplares
        //POST: Si la columna es DniPAdq, el valor se formatea como "DNI, Nombre"
        //      Si el personal no existe, se muestra "DNI, (Desconocido)"
        private void dataGridView_Ejemplares_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView_Ejemplares.Columns[e.ColumnIndex].Name == "DniPAdq")
            {
                if (e.Value != null && e.RowIndex >= 0)
                {
                    string dni = e.Value.ToString();

                    Personal personal = lnpa.GetPersonal(dni);

                    if (personal != null)
                    {
                        e.Value = $"{dni}, {personal.Nombre}";
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        e.Value = $"{dni}, (Desconocido)";
                        e.FormattingApplied = true;
                    }
                }
            }
        }

    }

}
