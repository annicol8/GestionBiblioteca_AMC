using System;
using System.Windows.Forms;
using ModeloDominio;

namespace Presentacion
{
    public partial class FBuscarDocumento : FComun
    {
        private Documento documento;
        public FBuscarDocumento()
        {
            InitializeComponent();
        }
        /* PRE: d puede ser null
   POST: Inicializa el formulario con el documento a mostrar */
        public FBuscarDocumento(Documento d) : this()
        {
            this.documento = d;
        }
        /* PRE: -
   POST: Muestra la información del documento. Si documento es null, muestra error y cierra.
         Si es AudioLibro muestra duración y formato, si es LibroPapel oculta esos campos */
        private void FBuscarDocumento_Load(object sender, EventArgs e)
        {
            if (documento == null)
            {
                MostrarError("No hay documento para mostrar");
                this.Close();
                return;
            }

            this.Text = "Datos de Documento - " + documento.Titulo;

            lbIsbn.Text = $"ISBN: {documento.Isbn}";
            lbTitulo.Text = $"Título: {documento.Titulo}";
            lbAutor.Text = $"Autor: {documento.Autor}";
            lbEditorial.Text = $"Editorial: {documento.Editorial}";
            lbAno.Text = $"Año de edición: {documento.AnoEdicion}";
            //lbPersonalRegistro.Text = $"Registrado por: {documento.Personal}";

            if (documento is AudioLibro audioLibro)
            {
                rbAudioLibro.Checked = true;
                //lbDuracion.Text = $"Duración: {audioLibro.Duracion}";
                TimeSpan duracion = TimeSpan.FromSeconds(audioLibro.Duracion);
                lbDuracion.Text = $"Duración: {duracion:hh\\:mm\\:ss} ({audioLibro.Duracion} seg)";
                lbFormatoDigital.Text = $"Formato: {audioLibro.FormatoDigital}";
            }
            else
            {
                rbLibro.Checked = true;
                gbAudioLibro.Visible = false;
            }


        }
        /* PRE: -
   POST: Cierra el formulario */
        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* PRE: -
   POST: Si no se ha establecido DialogResult, lo pone a OK al cerrar */
        private void FBuscarDocumento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
