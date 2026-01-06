using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
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
                var prestamos = lnps.GetTodosPrestamos();

                if (prestamos == null || prestamos.Count == 0)
                {
                    MostrarInformacion("No hay préstamos registrados en el sistema.");
                    bindingSourcePrest.DataSource = new List<Prestamo>();
                }
                else
                {
                    bindingSourcePrest.DataSource = prestamos;
                }

                dataGridView_Prest.DataSource = bindingSourcePrest;
                //ConfigurarColumnas();

                dataGridView_Prest.CellFormatting += DgvPrestamos_CellFormatting;
                dataGridView_Prest.SelectionChanged += DgvPrestamos_SelectionChanged;

                if (dataGridView_Prest.Rows.Count > 0)
                {
                    MostrarDocumentosPrestamo();
                }
                else
                {
                    listBox_Doc.Items.Add("(No hay préstamos para mostrar)");
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "cargar los préstamos");
            }
        }

        private void DgvPrestamos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView_Prest.Rows.Count)
                return;

            DataGridViewRow row = dataGridView_Prest.Rows[e.RowIndex];
            Prestamo prestamo = row.DataBoundItem as Prestamo;

            if (prestamo == null)
                return;

            // columna de Fecha Devolución
            if (dataGridView_Prest.Columns[e.ColumnIndex].Name == "FechaDevolucion")
            {
                if (prestamo != null && prestamo.Estado != EstadoPrestamo.finalizado)
                {
                    e.Value = "No devuelto";
                    e.FormattingApplied = true;
                }
            }

            // columna de Estado
            if (dataGridView_Prest.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (prestamo.Caducado())
                {
                    e.Value = "Vencido";
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.DarkRed;
                }
                else
                {
                    switch (prestamo.Estado)
                    {
                        case EstadoPrestamo.enProceso:
                            e.Value = "En proceso";
                            e.CellStyle.BackColor = Color.LightYellow;
                            break;
                        case EstadoPrestamo.finalizado:
                            e.Value = "Devuelto";
                            e.CellStyle.BackColor = Color.LightGreen;
                            break;
                    }
                }
                e.FormattingApplied = true;
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

                if (dataGridView_Prest.CurrentRow == null ||
                    dataGridView_Prest.CurrentRow.DataBoundItem == null)
                {
                    listBox_Doc.Items.Add("(Selecciona un préstamo)");
                    return;
                }

                Prestamo prestamo = dataGridView_Prest.CurrentRow.DataBoundItem as Prestamo;

                if (prestamo == null)
                {
                    listBox_Doc.Items.Add("(Error al obtener el préstamo)");
                    return;
                }


                var ejemplares = lnps.GetEjemplaresDePrestamo(prestamo.Id);


                if (ejemplares == null || ejemplares.Count == 0)
                {
                    listBox_Doc.Items.Add("(Sin ejemplares asociados)");
                    return;
                }

                int contador = 1;
                foreach (var ejemplar in ejemplares)
                {
                    if (ejemplar == null)
                    {
                        continue;
                    }

                    var documento = lnps.GetDocumento(ejemplar.IsbnDocumento);

                    if (documento != null)
                    {
                        listBox_Doc.Items.Add($"{contador}. \"{documento.Titulo}\" (Código: {ejemplar.Codigo})");
                    }
                    else
                    {
                        listBox_Doc.Items.Add($"{contador}. Ejemplar código: {ejemplar.Codigo} (Sin documento)");
                    }
                    contador++;
                }
            }
            catch (Exception ex)
            {
                listBox_Doc.Items.Clear();
                listBox_Doc.Items.Add($"Error: {ex.Message}");
                ManejarExcepcion(ex, "cargar los documentos del préstamo");
            }

        }

    }
}