using System;
using System.Drawing;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FBuscarEjemplar : FComun
    {
        private ILNPAdq lnpa;
        private Ejemplar ejemplarEncontrado;

        public Ejemplar EjemplarEncontrado
        {
            get { return ejemplarEncontrado; }
        }

        public FBuscarEjemplar()
        {
            InitializeComponent();
        }
        /* PRE: lnpa != null
   POST: Inicializa el formulario con la lógica de negocio necesaria para buscar ejemplares */
        public FBuscarEjemplar(ILNPAdq lnpa)
        {
            this.lnpa = lnpa;
            InitializeComponent();
        }
        /* PRE: lnpa inicializado
   POST: Inicia el proceso de búsqueda de ejemplar */
        private void FBuscarEjemplar_Load(object sender, EventArgs e)
        {
            BuscarEjemplar();
        }
        /* PRE: lnpa inicializado
   POST: Solicita un código al usuario y busca el ejemplar correspondiente.
         Si lo encuentra, muestra sus datos. Si no, pregunta si desea buscar otro.
         Si hay error o cancelación, cierra con DialogResult.Cancel */
        private void BuscarEjemplar()
        {
            try
            {
                int codigo = pedirClave<int>("Código ");
                if (codigo <= 0)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                ejemplarEncontrado = lnpa.GetEjemplar(codigo);

                if (ejemplarEncontrado == null)
                {
                    MostrarAdvertencia(
                        $"No se encontró ningún ejemplar con el código {codigo}.",
                        "Ejemplar no encontrado");

                    // Preguntar si desea buscar otro
                    if (SolicitarConfirmacion("¿Desea buscar otro ejemplar?", "Buscar otro"))
                    {
                        BuscarEjemplar();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                    return;

                }
                MostrarDatosEjemplar(ejemplarEncontrado);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "buscar el ejemplar");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        /* PRE: ejemplar != null, lnpa inicializado
   POST: Muestra toda la información del ejemplar en los controles del formulario.
         Si está inactivo, cambia el color de fondo y muestra advertencia */
        private void MostrarDatosEjemplar(Ejemplar ejemplar)
        {
            tb_Codigo.Text = ejemplar.Codigo.ToString();
            tb_Isbn.Text = ejemplar.IsbnDocumento ?? "N/A";

            if (!string.IsNullOrEmpty(ejemplar.DniPAdq))
            {
                Personal personal = lnpa.GetPersonal(ejemplar.DniPAdq);
                if (personal != null)
                {
                    tb_DniPersonal.Text = $"{ejemplar.DniPAdq}, {personal.Nombre}";
                }
                else
                {
                    tb_DniPersonal.Text = $"{ejemplar.DniPAdq}, (Desconocido)";
                }
            }
            else
            {
                tb_DniPersonal.Text = "N/A";
            }

            // Marcar o desmarcar el checkbox según el estado activo
            check_Activo.Checked = ejemplar.Activo;

            //Cambio de color del checkbox si no está activo
            if (!ejemplar.Activo)
            {
                this.BackColor = Color.LightCoral;
                MostrarAdvertencia(
                    "Este ejemplar está marcado como INACTIVO (dado de baja).",
                    "Ejemplar Inactivo");
            }
            else
            {
                this.BackColor = SystemColors.Control;
            }
            MostrarInfoDocumento(ejemplar.IsbnDocumento);
        }
        /* PRE: lnpa inicializado
   POST: Busca y muestra el título del documento asociado al ISBN.
         Si hay error, lo ignora silenciosamente */
        private void MostrarInfoDocumento(string isbn)
        {
            try
            {
                if (string.IsNullOrEmpty(isbn))
                    return;

                Documento documento = lnpa.getDocumento(isbn);

                if (documento != null && lb_Titulo != null)
                {
                    lb_Titulo.Text = $"Título documento: {documento.Titulo}";
                }
            }
            catch { }
        }


    }

}
