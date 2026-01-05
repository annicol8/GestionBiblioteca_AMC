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

        public FPrestamosPorDocumento()
        {
            InitializeComponent();
        }

        public FPrestamosPorDocumento(ILNPSala lnSala, string isbn) : this()
        {
            this.lnSala = lnSala;
            this.isbn = isbn;
        }

        private void FPrestamosPorDocumento_Load(object sender, EventArgs e)
        {
            CargarPrestamos();
        }

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

            //listBoxPrestamos.DisplayMember = "InfoResumen";

            foreach (Prestamo p in prestamos)
            {
                listBoxPrestamos.Items.Add(p);
            }
        }

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

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
