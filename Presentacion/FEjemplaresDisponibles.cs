using System;
using System.Collections.Generic;
using System.Drawing;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FEjemplaresDisponibles : FComun
    {
        private string isbn;
        private ILNPAdq lnAdq;

        public FEjemplaresDisponibles()
        {
            InitializeComponent();
        }

        //PRE: isbn != null y no vacío, lnAdq != null
        //POST: El formulario queda inicializado con las referencias a isbn y lnAdq asignadas
        public FEjemplaresDisponibles(string isbn, ILNPAdq lnAdq) : this()
        {
            this.isbn = isbn;
            this.lnAdq = lnAdq;
        }

        //PRE: isbn != null y no vacío, lnAdq != null, el documento con ese ISBN debe existir
        //POST: Se cargan los datos del documento y su disponibilidad en el formulario
        //      Si hay un error, se muestra mediante MostrarError y se cierra el formulario
        private void FEjemplaresDisponibles_Load(object sender, System.EventArgs e)
        {
            try
            {
                CargarDatosDocumento();
                CargarDisponibilidad();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar la información de disponibilidad:\n{ex.Message}",
                           "Error");
                this.Close();
            }
        }

        //PRE: isbn != null y no vacío, lnAdq != null, el documento debe existir
        //POST: Se calculan y muestran las estadísticas de disponibilidad
        private void CargarDisponibilidad()
        {
            List<Ejemplar> ejemplares = lnAdq.ejemplaresPorDocumento(isbn);

            int ejemplaresDisponibles = 0;
            int ejemplaresPrestados = 0;

            foreach (Ejemplar ej in ejemplares)
            {
                if (ej.Activo)
                {
                    if (lnAdq.EjemplarDisponibleParaPrestamo(ej.Codigo))
                    {
                        ejemplaresDisponibles++;
                    }
                    else
                    {
                        ejemplaresPrestados++;
                    }
                }
            }

            lblEjemplaresDisp.Text = ejemplaresDisponibles.ToString();
            lblEjemplaresPrestados.Text = ejemplaresPrestados.ToString();

            if (ejemplaresDisponibles > 0)
            {
                MostrarDisponible(ejemplaresDisponibles);
            }
            else
            {
                MostrarNoDisponible();
            }
        }

        //PRE: lnAdq != null, isbn != null y no vacío
        //POST: Se actualiza la interfaz para mostrar estado "NO DISPONIBLE":
        private void MostrarNoDisponible()
        {
            lblEstadoDisponibilidad.Text = "NO DISPONIBLE";
            lblEstadoDisponibilidad.ForeColor = Color.Orange;
            lblEstadoDisponibilidad.Font = new Font(lblEstadoDisponibilidad.Font, FontStyle.Bold);

            DateTime? fechaDisponibilidad = lnAdq.GetFechaProximaDisponibilidad(isbn);

            if (fechaDisponibilidad.HasValue)
            {
                int diasRestantes = (fechaDisponibilidad.Value.Date - DateTime.Now.Date).Days;
                string diasTexto;

                if (diasRestantes < 0)
                {
                    diasTexto = "debería haber sido devuelto";
                }
                else if (diasRestantes == 0)
                {
                    diasTexto = "se espera devolución hoy";
                }
                else if (diasRestantes == 1)
                {
                    diasTexto = "se espera devolución mañana";
                }
                else
                {
                    diasTexto = $"se espera devolución en {diasRestantes} días";
                }

                lblFechaDisponibilidad.Text =
                    $"Todos los ejemplares están prestados.\n\n" +
                    $"Fecha estimada de disponibilidad:\n" +
                    $"{fechaDisponibilidad.Value:dddd, dd/MM/yyyy}\n" +
                    $"({diasTexto})";

                lblFechaDisponibilidad.ForeColor = Color.DarkOrange;
            }
            else
            {
                lblFechaDisponibilidad.Text =
                    "Todos los ejemplares están prestados.\n\n" +
                    "No hay información disponible sobre fechas de devolución.";

                lblFechaDisponibilidad.ForeColor = Color.Red;
            }

            lblFechaDisponibilidad.Visible = true;
        }

        //PRE: ejemplaresDisponibles > 0
        //POST: Se actualiza la interfaz para mostrar estado "DISPONIBLE"
        private void MostrarDisponible(int ejemplaresDisponibles)
        {
            lblEstadoDisponibilidad.Text = "DISPONIBLE";
            lblEstadoDisponibilidad.ForeColor = Color.Green;
            lblEstadoDisponibilidad.Font = new Font(lblEstadoDisponibilidad.Font, FontStyle.Bold);

            lblFechaDisponibilidad.Text = $"Hay ejemplares para prestar.";
            lblFechaDisponibilidad.ForeColor = Color.Green;
            lblFechaDisponibilidad.Visible = true;
        }

        //PRE: isbn != null y no vacío, lnAdq != null, debe existir un documento con ese ISBN
        //POST: Se cargan y muestran los datos del documento
        private void CargarDatosDocumento()
        {
            Documento documento = lnAdq.getDocumento(isbn);

            lblTitulo.Text = documento.Titulo;
            lblIsbn.Text = documento.Isbn;
            lblAutor.Text = documento.Autor;
            this.Text = $"Disponibilidad - {documento.Titulo}";

        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
