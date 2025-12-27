using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;


namespace Presentacion
{
    public partial class FAltaPrestamo : FComun
    {
        private ILNPSala lnSala;
        private List<EjemplarPrestamoDisplay> ejemplaresAñadidos;
        private int yPosition = 10; // Para posicionar dinámicamente los controles

        public FAltaPrestamo() : base()
        {
            InitializeComponent();
            ejemplaresAñadidos = new List<EjemplarPrestamoDisplay>();

        }
        public FAltaPrestamo(ILNPSala lnSala) : this()
        {
            this.lnSala = lnSala;
        }

        private void FAltaPrestamo_Load(object sender, System.EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                List<Usuario> usuariosActivos = lnSala.GetUsuariosActivos();

                if (usuariosActivos.Count == 0)
                {
                    MostrarAdvertencia("No hay usuarios activos en el sistema.");
                    btAceptar.Enabled = false;
                    return;
                }
                cbUsuarios.DataSource = usuariosActivos;
                cbUsuarios.DisplayMember = "Dni"; // Muestra el DNI
                cbUsuarios.ValueMember = "Dni";   // Valor es el DNI
                cbUsuarios.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "cargar los usuarios");
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btAñadirEjemplar_Click(object sender, EventArgs e)
        {
            try
            {
                FAñadirEjemplarPrestamo formulario = new FAñadirEjemplarPrestamo(lnSala, ejemplaresAñadidos);

                if (formulario.ShowDialog(this) == DialogResult.OK)
                {
                    Ejemplar ejemplarSeleccionado = formulario.EjemplarSeleccionado;
                    if (ejemplarSeleccionado != null)
                    {
                        // Obtener documento para mostrar el título
                        Documento doc = lnSala.GetDocumento(ejemplarSeleccionado.IsbnDocumento);
                        string titulo = doc != null ? doc.Titulo : "Desconocido";

                        EjemplarPrestamoDisplay epd = new EjemplarPrestamoDisplay(
                            ejemplarSeleccionado.Codigo,
                            ejemplarSeleccionado.IsbnDocumento,
                            titulo
                        );

                        ejemplaresAñadidos.Add(epd);
                        AgregarEjemplarVisual(epd);
                    }
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "añadir el ejemplar");
            }
        }

        private void AgregarEjemplarVisual(EjemplarPrestamoDisplay epd)
        {
            // Label con texto "ID ejemplar:"
            Label lbl = new Label
            {
                Text = "ID ejemplar:",
                Location = new Point(10, yPosition + 3),
                Width = 80,
                Tag = epd
            };

            // TextBox para mostrar el código
            TextBox tb = new TextBox
            {
                Text = epd.Codigo.ToString(),
                ReadOnly = true,
                Width = 80,
                Location = new Point(100, yPosition),
                Tag = epd
            };

            // RadioButton para indicar "Prestado"
            RadioButton rb = new RadioButton
            {
                Text = "Prestado",
                Checked = true,
                Enabled = false, // No editable en alta
                Location = new Point(190, yPosition),
                Width = 100,
                Tag = epd
            };

            panelEjemplares.Controls.Add(lbl);
            panelEjemplares.Controls.Add(tb);
            panelEjemplares.Controls.Add(rb);

            yPosition += 30; // Espaciado vertical
        }
    }
}
