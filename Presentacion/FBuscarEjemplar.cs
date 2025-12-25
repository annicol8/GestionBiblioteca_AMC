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

        public FBuscarEjemplar(ILNPAdq lnpa) 
        {
            this.lnpa = lnpa;
            InitializeComponent();
        }

        private void FBuscarEjemplar_Load(object sender, EventArgs e)
        {
            BuscarEjemplar();
        }

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
