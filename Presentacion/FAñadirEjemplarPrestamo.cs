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
        private BindingSource bindingSourceEjemplares;


        public Ejemplar EjemplarSeleccionado { get; private set; }

        public FAñadirEjemplarPrestamo() : base()
        {
            InitializeComponent();
            bindingSourceEjemplares = new BindingSource();
        }

        /* PRE: lnSala != null, codigosEjemplaresAñadidos != null (puede estar vacía)
   POST: Crea el formulario con los datos necesarios para gestionar ejemplares */
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

        /* PRE: lnSala inicializado correctamente
POST: Carga y muestra los ejemplares disponibles excluyendo los ya añadidos.
 Si no hay ejemplares, cierra el formulario con DialogResult.Cancel */
        private void CargarEjemplaresDisponibles()
        {
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

            listBox1.DisplayMember = "InfoCompleta";
            listBox1.ValueMember = "Codigo";

        }

        /* PRE: -
   POST: Cierra el formulario con DialogResult.Cancel */
        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /* PRE: listBox1 debe tener elementos cargados
   POST: Si hay un ejemplar seleccionado y está disponible, establece EjemplarSeleccionado
         y cierra con DialogResult.OK. Si no hay selección o no está disponible, 
         muestra mensaje de error y no cierra */
        private void button2_Click(object sender, EventArgs e)
        {
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
