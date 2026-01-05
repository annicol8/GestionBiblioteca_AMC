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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Presentacion
{
    public partial class FPrestamosFueraDdePlazo : FComun
    {
        private ILNPSala lnSala;
        private BindingSource bindingSourcePrestamos;

        //PRE: 
        //POST: Se inicializan los componentes visuales del formulario.
        public FPrestamosFueraDdePlazo()
        {
            InitializeComponent();
        }

        //PRE: lnSala no debe ser null.
        //POST: El formulario queda inicializado y cargado con los préstamos fuera de plazo.
        public FPrestamosFueraDdePlazo(ILNPSala lnSala) : this()
        {
            this.lnSala = lnSala;
            InicializarFormulario();
        }

        //PRE: lnSala debe estar correctamente inicializado.
        //POST: Se cargan los préstamos fuera de plazo en el DataGridView.
        // - Se configuran los eventos del DataGridView.
        // - Se muestran los ejemplares no devueltos del préstamo seleccionado.
        private void InicializarFormulario()
        {
            try
            {
                bindingSourcePrestamos = new BindingSource();

                List<Prestamo> prestamos = lnSala.GetPrestamosFueraDePlazo();

                if (prestamos == null || prestamos.Count == 0)
                {
                    MostrarInformacion("No hay préstamos fuera de plazo.");
                    bindingSourcePrestamos.DataSource = new List<Prestamo>();
                }
                else
                {
                    bindingSourcePrestamos.DataSource = prestamos;
                }

                dataGridViewPrestamos.DataSource = bindingSourcePrestamos;

                dataGridViewPrestamos.SelectionChanged += DataGridView_Prestamos_SelectionChanged;
                dataGridViewPrestamos.CellFormatting += DataGridView_Prestamos_CellFormatting;

                MostrarEjemplaresNoDevueltos();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "cargar los préstamos fuera de plazo");
            }
        }


        //PRE: El DataGridView debe estar inicializado.
        //POST: Se actualiza la lista de ejemplares no devueltos según el préstamo seleccionado.
        private void DataGridView_Prestamos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarEjemplaresNoDevueltos();
        }

        //PRE:lnSala debe estar inicializado.El DataGridView puede o no tener una fila seleccionada.
        //POST:Se muestran en el ListBox los ejemplares no devueltos del préstamo seleccionado.
        // - Si no hay selección o ejemplares, se muestra un mensaje informativo.
        private void MostrarEjemplaresNoDevueltos()
        {
            try
            {
                listBoxEjemplares.Items.Clear();

                if (dataGridViewPrestamos.CurrentRow == null ||
                    dataGridViewPrestamos.CurrentRow.DataBoundItem == null)
                {
                    listBoxEjemplares.Items.Add("(Selecciona un préstamo)");
                    return;
                }

                Prestamo prestamo =
                    dataGridViewPrestamos.CurrentRow.DataBoundItem as Prestamo;

                if (prestamo == null)
                {
                    listBoxEjemplares.Items.Add("(Error al obtener el préstamo)");
                    return;
                }

                List<Ejemplar> ejemplares =
                    lnSala.GetEjemplaresNoDevueltos(prestamo.Id);

                if (ejemplares == null || ejemplares.Count == 0)
                {
                    listBoxEjemplares.Items.Add("(No hay ejemplares pendientes)");
                    return;
                }

                foreach (Ejemplar ej in ejemplares)
                {
                    Documento doc = lnSala.GetDocumento(ej.IsbnDocumento);

                    if (doc != null)
                    {
                        listBoxEjemplares.Items.Add(
                            $"Ejemplar {ej.Codigo} - \"{doc.Titulo}\""
                        );
                    }
                    else
                    {
                        listBoxEjemplares.Items.Add(
                            $"Ejemplar {ej.Codigo} - (Documento no encontrado)"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                listBoxEjemplares.Items.Clear();
                listBoxEjemplares.Items.Add("Error al cargar ejemplares");
                ManejarExcepcion(ex, "cargar los ejemplares no devueltos");
            }
        }

        //PRE:El DataGridView debe tener filas asociadas a objetos Prestamo. El evento se dispara para una celda válida.
        //POST:La columna "Estado" se muestra como "Vencido".
        // - La celda se colorea para indicar visualmente el vencimiento.
        private void DataGridView_Prestamos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataGridViewPrestamos.Rows[e.RowIndex];
            Prestamo prestamo = row.DataBoundItem as Prestamo;

            if (prestamo == null)
                return;

            if (dataGridViewPrestamos.Columns[e.ColumnIndex].Name == "Estado")
            {
                e.Value = "Vencido";
                e.CellStyle.BackColor = Color.LightCoral;
                e.CellStyle.ForeColor = Color.DarkRed;
                e.FormattingApplied = true;
            }
        }
    }
}
