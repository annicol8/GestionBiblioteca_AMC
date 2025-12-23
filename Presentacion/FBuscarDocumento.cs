using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public FBuscarDocumento(Documento d) : this()
        {
            this.documento = d;
        }

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

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FBuscarDocumento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
