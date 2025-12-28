using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FAñadirEjemplarPrestamo : FComun
    {
        private ILNPSala lnSala;
        private List<int> codigosEjemplaresAñadidos;
        //private Ejemplar ejemplarSeleccionado;
        //private List<Ejemplar> ejemplaresDisponibles;
        private BindingSource bindingSourceEjemplares;


        public Ejemplar EjemplarSeleccionado { get; private set; }

        public FAñadirEjemplarPrestamo() : base()
        {
            InitializeComponent();
            bindingSourceEjemplares = new BindingSource();
        }

        public FAñadirEjemplarPrestamo(ILNPSala lnSala, List<int> codigosEjemplaresAñadidos) : this()
        {
            this.lnSala = lnSala;
            this.codigosEjemplaresAñadidos = codigosEjemplaresAñadidos ?? new List<int>();
        }

        private void FAñadirEjemplarPrestamo_Load(object sender, EventArgs e)
        {
            try
            {
                CargarEjemplaresDisponibles();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "cargar ejemplares");
                this.Close();
            }
        }

        private void CargarEjemplaresDisponibles()
        {
            /*
            ejemplaresDisponibles = lnSala.GetEjemplaresActivos();

            //Filtrar los que ya han sido añadidos al préstamo
            List<Ejemplar> ejemplaresParaMostrar = new List<Ejemplar>();
            foreach (Ejemplar ej in ejemplaresDisponibles)
            {
                if (!codigosEjemplaresAñadidos.Contains(ej.Codigo) &&
                    lnSala.EjemplarDisponibleParaPrestamo(ej.Codigo))
                {
                    ejemplaresParaMostrar.Add(ej);
                }
            }

            // Asignar al ListBox
            listBox1.DataSource = ejemplaresParaMostrar;
            listBox1.DisplayMember = "Codigo";  // Muestra el código
            */

            List<Ejemplar> ejemplaresDisponibles = lnSala.GetEjemplaresDisponibles(codigosEjemplaresAñadidos);

            // Filtrar solo los que están disponibles para préstamo
            List<Ejemplar> ejemplaresParaMostrar = ejemplaresDisponibles
                .Where(ej => lnSala.EjemplarDisponibleParaPrestamo(ej.Codigo))
                .ToList();

            if (ejemplaresParaMostrar.Count == 0)
            {
                MostrarInformacion("No hay ejemplares disponibles para añadir al préstamo.");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            bindingSourceEjemplares.DataSource = ejemplaresParaMostrar;
            listBox1.DataSource = bindingSourceEjemplares;

            listBox1.DisplayMember = "InfoCompleta" ; 
            listBox1.ValueMember = "Codigo";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                if (listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un ejemplar", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ejemplarSeleccionado = (Ejemplar)listBox1.SelectedItem;
                this.EjemplarSeleccionado = ejemplarSeleccionado;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

            try
            {
                if (listBox1.SelectedItem == null)
                {
                    MostrarAdvertencia("Debe seleccionar un ejemplar", "Validación");
                    listBox1.Focus(); 
                    return;
                }

                EjemplarSeleccionado = (Ejemplar)bindingSourceEjemplares.Current;

                if (!lnSala.EjemplarDisponibleParaPrestamo(EjemplarSeleccionado.Codigo))
                {
                    MostrarError("El ejemplar seleccionado ya no está disponible.");
                    CargarEjemplaresDisponibles(); 
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "seleccionar ejemplar");
            }
        }
    }
}
