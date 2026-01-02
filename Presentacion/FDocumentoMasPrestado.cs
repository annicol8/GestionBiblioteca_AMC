using System;
using System.Drawing;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FDocumentoMasPrestado : FComun
    {
        private ILNPAdq lnAdq;

        public FDocumentoMasPrestado()
        {
            InitializeComponent();
        }
        //PRE: lnAdq != null
        //POST: El formulario queda inicializado con la referencia a lnAdq asignada
        public FDocumentoMasPrestado(ILNPAdq lnAdq) : this()
        {
            this.lnAdq = lnAdq;
        }
        //PRE: lnAdq != null
        //POST: Se muestra el período analizado y el documento más prestado
        private void FDocumentoMasPrestado_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = DateTime.Now.AddMonths(-1);
                DateTime fechaFin = DateTime.Now;

                lblPeriodo.Text = $"Del {fechaInicio:dd/MM/yyyy} al {fechaFin:dd/MM/yyyy}";
                lblPeriodo.ForeColor = Color.Gray;

                CargarDocumentoMasPrestado();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar la información:\n{ex.Message}", "Error");
                this.Close();
            }
        }
        //PRE: lnAdq != null
        //POST: Se muestra el título del documento más prestado o mensaje si no hay préstamos

        private void CargarDocumentoMasPrestado()
        {
            string isbnMasPrestado = lnAdq.GetDocumentoMasPrestadoUltimoMes();

            if (isbnMasPrestado == null)
            {
                lblTitulo.Text = "No hay préstamos registrados en el último mes";
                lblTitulo.Font = new Font(lblTitulo.Font, FontStyle.Bold);
                lblTitulo.ForeColor = Color.Gray;

                return;
            }

            Documento documento = lnAdq.getDocumento(isbnMasPrestado);

            if (documento == null)
            {
                MostrarError("No se pudo obtener la información del documento", "Error");
                this.Close();
                return;
            }

            lblTitulo.Text = documento.Titulo;
            lblTitulo.Font = new Font(lblTitulo.Font, FontStyle.Bold);




        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
