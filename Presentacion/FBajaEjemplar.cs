using System;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FBajaEjemplar : FComun
    {
        private ILNPAdq lnAdq;
        private Ejemplar ejemplar;
        public FBajaEjemplar()
        {
            InitializeComponent();
        }
        /* PRE: lnAdq != null, ejemplar != null
   POST: Inicializa el formulario con los datos necesarios para dar de baja un ejemplar */

        public FBajaEjemplar(ILNPAdq lnAdq, Ejemplar ejemplar) : this()
        {
            this.lnAdq = lnAdq;
            this.ejemplar = ejemplar;
        }
        /* PRE: ejemplar != null, lnAdq inicializado
   POST: Carga y muestra la información del ejemplar en modo solo lectura.
         Si el ejemplar ya está inactivo, muestra advertencia y cierra con DialogResult.Cancel */

        private void FBajaEjemplar_Load(object sender, EventArgs e)
        {
            try
            {
                if (!ejemplar.Activo)
                {
                    MostrarAdvertencia(
                        "Este ejemplar ya está dado de baja.\n" +
                        "No se puede continuar con la operación.",
                        "Ejemplar inactivo");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
                tbCodigo.Text = ejemplar.Codigo.ToString();
                tbIsbn.Text = ejemplar.IsbnDocumento ?? "N/A";

                Documento documento = lnAdq.getDocumento(ejemplar.IsbnDocumento);
                tbTitulo.Text = documento != null ? documento.Titulo : "Documento no encontrado";

                tbEstado.Text = ejemplar.Activo ? "Activo" : "Inactivo";

                tbCodigo.ReadOnly = true;
                tbIsbn.ReadOnly = true;
                tbTitulo.ReadOnly = true;
                tbEstado.ReadOnly = true;

                this.Text = $"Baja de Ejemplar - Código: {ejemplar.Codigo}";
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "cargar los datos del ejemplar");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        /* PRE: ejemplar.Activo == true, lnAdq inicializado
   POST: Si el usuario confirma, marca el ejemplar como inactivo.
         Cierra con DialogResult.OK si tiene éxito, muestra error en caso contrario */

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (!ejemplar.Activo)
            {
                MostrarInformacion("El ejemplar ya está dado de baja.");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            DialogResult dr = MostrarPregunta(
                "¿Está seguro que desea dar de baja este ejemplar?\nEsta operación no se puede deshacer.",
                "Confirmación de baja"
            );

            if (dr == DialogResult.Yes)
            {
                try
                {
                    bool resultado = lnAdq.BajaEjemplar(ejemplar.Codigo);

                    if (resultado)
                    {
                        MostrarExito($"Ejemplar {ejemplar.Codigo} dado de baja correctamente.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MostrarError("No se pudo dar de baja el ejemplar.");
                    }
                }
                catch (InvalidOperationException ex)
                {
                    MostrarError(ex.Message);
                }
                catch (Exception ex)
                {
                    MostrarError(ex.Message);
                }
            }
        }
        /* PRE: -
   POST: Cierra el formulario con DialogResult.Cancel */
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
