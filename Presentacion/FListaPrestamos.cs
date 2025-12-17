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

namespace Presentacion //CAMBIAR LOS MET. PERSISTENCIA.PERSITENCIA Y HACERLO CON LN MIRAR LO DE LOS FORMATOS 
{
    public partial class FListaPrestamos : FComun
    {
        private ILNPSala lnps;
        private BindingSource bindingSourcePrest;
        public FListaPrestamos(ILNPSala lnps)
        {
            InitializeComponent();
            this.lnps = lnps;
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            try
            {
                bindingSourcePrest = new BindingSource();
                bindingSourcePrest.DataSource = lnps.GetTodosPrestamos();

                dataGridView_Prest.DataSource = bindingSourcePrest;

                dataGridView_Prest.CellFormatting += DgvPrestamos_CellFormatting;
                dataGridView_Prest.SelectionChanged += DgvPrestamos_SelectionChanged;

                if (dataGridView_Prest.Rows.Count > 0)
                {
                    MostrarDocumentosPrestamo();
                }

            } catch (Exception ex)
            {
                MostrarError($"Error al cargar los préstamos: {ex.Message}");
            }
        }

        private void DgvPrestamos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // columna de Fecha Devolución
            if (dataGridView_Prest.Columns[e.ColumnIndex].Name == "FechaDevolucion")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView_Prest.Rows[e.RowIndex];
                    Prestamo prestamo = row.DataBoundItem as Prestamo;

                    if (prestamo != null && prestamo.Estado != EstadoPrestamo.finalizado)
                    {
                        e.Value = "No devuelto";
                        e.FormattingApplied = true;
                    }
                }
            }

            // columna de Estado
            if (dataGridView_Prest.Columns[e.ColumnIndex].Name == "colEstado")
            {
                if (e.Value != null)
                {
                    DataGridViewRow row = dataGridView_Prest.Rows[e.RowIndex];
                    Prestamo prestamo = row.DataBoundItem as Prestamo;
                    EstadoPrestamo estado = (EstadoPrestamo)e.Value;
                    if (prestamo.Caducado())
                    {
                        e.Value = "Vencido";
                        e.CellStyle.BackColor = System.Drawing.Color.LightCoral;
                    } else 
                    {
                        switch (estado)
                        {
                            case EstadoPrestamo.enProceso:
                                e.Value = "En proceso";
                                e.CellStyle.BackColor = System.Drawing.Color.LightYellow;
                                break;
                            case EstadoPrestamo.finalizado:
                                e.Value = "Devuelto";
                                e.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                                break;
                        }
                    } 
                    e.FormattingApplied = true;
                }
            }
        }

        private void DgvPrestamos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDocumentosPrestamo();
        }

        private void MostrarDocumentosPrestamo()
        {
            try
            {
                listBox_Doc.Items.Clear();
                if (dataGridView_Prest.CurrentRow != null && dataGridView_Prest.CurrentRow.DataBoundItem != null)
                {
                    Prestamo prestamo = dataGridView_Prest.CurrentRow.DataBoundItem as Prestamo;
                    if (prestamo != null)
                    {
                        var ejemplares = Persistencia.Persistencia.GetEjemplaresDePrestamo(prestamo.Id);
                        if (ejemplares.Count > 0)
                        {
                            int contador = 1;
                            foreach (var ejemplar in ejemplares)
                            {
                                var documento = Persistencia.Persistencia.GetDocumento(ejemplar.IsbnDocumento);
                                if (documento != null)
                                {
                                    listBox_Doc.Items.Add($"{contador}. \"{documento.Titulo}\" (Código: {ejemplar.Codigo})");
                                } else
                                {
                                    listBox_Doc.Items.Add($"{contador}. Ejemplar código: {ejemplar.Codigo}");
                                }
                                contador++;
                            }
                        }
                    } else
                    {
                        listBox_Doc.Items.Add("(Sin ejemplares asociados)");
                    }
                }
            } catch (Exception ex)
            {
                listBox_Doc.Items.Clear();
                listBox_Doc.Items.Add($"Error al cargar documentos: {ex.Message}");
            }
        }

    }
}
