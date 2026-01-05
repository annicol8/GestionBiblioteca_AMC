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
    public partial class FPrestamosPorDocumento : FComun
    {

        private ILNPSala lnSala;
        private string isbn;
        private List<Prestamo> prestamos;

        //PRE: 
        //POST: Se inicializan los componentes visuales del formulario.
        public FPrestamosPorDocumento()
        {
            InitializeComponent();
        }

        //PRE:lnSala no debe ser null.isbn debe ser un identificador válido de documento.
        //POST: Se almacenan las dependencias necesarias para cargar los préstamos.
        public FPrestamosPorDocumento(ILNPSala lnSala, string isbn) : this()
        {
            this.lnSala = lnSala;
            this.isbn = isbn;
        }

        //PRE: El formulario ha sido correctamente construido.
        //POST: Se cargan y muestran los préstamos asociados al documento
        private void FPrestamosPorDocumento_Load(object sender, EventArgs e)
        {
            CargarPrestamos();
        }

        //PRE: lnSala debe estar inicializado.isbn debe corresponder a un documento existente.
        //POST:Se cargan los préstamos asociados al documento. Se muestran en el ListBox.
        // - Si no existen préstamos, se muestra un error y se cierra el formulario.
        private void CargarPrestamos()
        {
            prestamos = lnSala.GetPrestamosPorDocumento(isbn);

            listBoxPrestamos.Items.Clear();

            if (prestamos == null || prestamos.Count == 0)
            {
                MostrarError("No hay préstamos asociados a ese documento");
                this.Close();
                return;
            }

            foreach (Prestamo p in prestamos)
            {
                listBoxPrestamos.Items.Add(p);
            }
        }

        //PRE: El ListBox debe contener préstamos cargados.
        //POST: Si hay un préstamo seleccionado, se abre el formulario de detalle.
        // - Si no hay selección, se muestra un mensaje de error
        private void buttonVer_Click(object sender, EventArgs e)
        {
            if (listBoxPrestamos.SelectedItem == null)
            {
                MostrarError("Debes seleccionar un préstamo");
                return;
            }

            Prestamo prestamoSeleccionado =
                (Prestamo)listBoxPrestamos.SelectedItem;

            FBuscarPrestamo formulario =
                new FBuscarPrestamo(lnSala, prestamoSeleccionado);

            formulario.ShowDialog(this);
        }

        //PRE: 
        //POST: Se cierra el formulario actual.
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //PRE:El ListBox contiene objetos de tipo Prestamo.
        //POST:Se muestra un texto descriptivo para cada préstamo en la lista.
        private void listBoxPrestamos_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Prestamo p)
            {
                e.Value =
                    $"Préstamo {p.Id} - {p.FechaPrestamo.ToShortDateString()} - {p.DniUsuario}";
            }
        }
    }
}
