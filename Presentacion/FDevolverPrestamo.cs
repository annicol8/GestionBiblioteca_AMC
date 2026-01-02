using System;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FDevolverPrestamo : FComun
    {
        private ILNPSala lnSala;
        private Prestamo prestamo;
        public FDevolverPrestamo()
        {
            InitializeComponent();
        }
        /* PRE: lnSala != null, prestamo != null
   POST: Inicializa el formulario con los datos necesarios para devolver ejemplares de un préstamo */
        public FDevolverPrestamo(ILNPSala lnSala, Prestamo prestamo) : this()
        {
            this.lnSala = lnSala;
            this.prestamo = prestamo;
        }
        /* PRE: lnSala y prestamo inicializados
   POST: Carga en el listBox los ejemplares no devueltos del préstamo */
        private void FDevolverPrestamo_Load(object sender, EventArgs e)
        {
            listBoxEjemplares.Items.Clear();

            foreach (Ejemplar ej in lnSala.GetEjemplaresNoDevueltos(prestamo.Id))
            {
                listBoxEjemplares.Items.Add(ej);
            }
        }

        private void CargarEjemplaresPendientes()
        {

        }
        /* PRE: lnSala y prestamo inicializados, listBoxEjemplares con elementos cargados
   POST: Si hay ejemplares seleccionados y el usuario confirma, los marca como devueltos
         y cierra el formulario. Si no hay selección, muestra error */
        private void botonDevolver_Click(object sender, EventArgs e)
        {
            if (listBoxEjemplares.SelectedItems.Count == 0)
            {
                MostrarError("Debes seleccionar al menos un ejemplar");
                return;
            }

            DialogResult dr = MostrarPregunta(
                "¿Confirmar devolución?",
                "Se devolverán los ejemplares seleccionados"
            );

            if (dr != DialogResult.Yes)
                return;

            foreach (Ejemplar ej in listBoxEjemplares.SelectedItems)
            {
                lnSala.DevolverEjemplar(prestamo.Id, ej.Codigo);
            }

            MostrarExito("Ejemplares devueltos correctamente");
            this.Close();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
