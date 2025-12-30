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
    public partial class FAltaDocumento : FComun
    {
        private ILNPAdq lnAdq;
        private string isbn;

        //PRE:
        //POST: Se inicializa el formulario de alta de documentos.
        public FAltaDocumento()
        {
            InitializeComponent();
        }

        //PRE: lnAdq no debe ser null e isbn debe contener un ISBN válido.
        //POST: Se inicializa el formulario con la lógica de negocio y el ISBN del documento.
        public FAltaDocumento(ILNPAdq lnAdq, string isbn) : this()
        {
            this.lnAdq = lnAdq;
            this.isbn = isbn;
        }

        //PRE: El formulario ha sido creado y el ISBN contiene un valor.
        //POST: El ISBN se muestra en el textbox en modo solo lectura, se da foco al título
        //      y se ocultan los campos específicos de audiolibro.
        private void FAltaDocumento_Load(object sender, EventArgs e)
        {
            tbIsbn.Text = isbn;
            tbIsbn.ReadOnly = true;
            tbTitulo.Focus();

            OcultarCamposAudioLibro();
        }

        //PRE: El radio button de libro cambia de estado.
        //POST: Si se selecciona libro en papel, se ocultan los campos de audiolibro.
        private void rbLibro_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLibro.Checked)
            {
                OcultarCamposAudioLibro();
            }
        }

        //PRE: El radio button de audiolibro cambia de estado.
        //POST: Si se selecciona audiolibro, se muestran los campos específicos.
        private void rbAudioLibro_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAudioLibro.Checked)
            {
                MostrarCamposAudioLibro();
            }
        }

        //PRE: El formulario está inicializado.
        //POST: Los campos específicos del audiolibro quedan visibles.
        private void MostrarCamposAudioLibro()
        {
            lbFormatoDigital.Visible = true;
            tbFormatoDigital.Visible = true;
            lbDuracion.Visible = true;
            tbDuracion.Visible = true;
            gbAudioLibro.Visible = true;
        }

        //PRE: El formulario está inicializado.
        //POST: Los campos específicos del audiolibro quedan ocultos.
        private void OcultarCamposAudioLibro()
        {
            lbFormatoDigital.Visible = false;
            tbFormatoDigital.Visible = false;
            lbDuracion.Visible = false;
            tbDuracion.Visible = false;
            gbAudioLibro.Visible = false;
        }

        //PRE: El usuario ha introducido los datos del documento y pulsa el botón Dar Alta.
        //POST: Si los datos son válidos, se da de alta el documento correspondiente
        //      (libro o audiolibro), se muestra un mensaje de éxito y se cierra el formulario.
        //      En caso de error, se muestra el mensaje correspondiente.
        private void btDarAlta_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }
            try
            {
                if (rbLibro.Checked)
                {
                    DarAltaLibroPapel();
                }
                else if (rbAudioLibro.Checked)
                {
                    DarAltaAudioLibro();
                }

                MostrarExito("Documento dado de alta correctamente");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentNullException ex)
            {
                MostrarError(ex.Message);

            }
            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);

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

        //PRE: El usuario ha introducido datos en el formulario.
        //POST: Devuelve true si todos los datos son válidos.
        //      En caso contrario, muestra un mensaje de error y devuelve false.
        private bool ValidarDatos()
        {
            // Validar título
            if (string.IsNullOrWhiteSpace(tbTitulo.Text))
            {
                MostrarError("Debes introducir un título");
                tbTitulo.Focus();
                return false;
            }

            // Validar autor
            if (string.IsNullOrWhiteSpace(tbAutor.Text))
            {
                MostrarError("Debes introducir un autor");
                tbAutor.Focus();
                return false;
            }

            // Validar editorial
            if (string.IsNullOrWhiteSpace(tbEditorial.Text))
            {
                MostrarError("Debes introducir una editorial");
                tbEditorial.Focus();
                return false;
            }

            // Validar año de edición
            if (string.IsNullOrWhiteSpace(tbAnoEdicion.Text))
            {
                MostrarError("Debes introducir el año de edición");
                tbAnoEdicion.Focus();
                return false;
            }

            if (!int.TryParse(tbAnoEdicion.Text, out int anio))
            {
                MostrarError("El año de edición debe ser un número válido");
                tbAnoEdicion.Focus();
                return false;
            }

            // Validar que el año sea razonable
            if (anio < 1000 || anio > DateTime.Now.Year + 1)
            {
                MostrarError($"El año de edición debe estar entre 1000 y {DateTime.Now.Year + 1}");
                tbAnoEdicion.Focus();
                return false;
            }

            // Validar tipo de documento seleccionado
            if (!rbLibro.Checked && !rbAudioLibro.Checked)
            {
                MostrarError("Debes seleccionar un tipo de documento");
                return false;
            }

            // Si es audiolibro, validar campos específicos
            if (rbAudioLibro.Checked)
            {
                if (string.IsNullOrWhiteSpace(tbFormatoDigital.Text))
                {
                    MostrarError("Debes introducir el formato digital del audiolibro");
                    tbFormatoDigital.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(tbDuracion.Text))
                {
                    MostrarError("Debes introducir la duración del audiolibro");
                    tbDuracion.Focus();
                    return false;
                }

                if (!int.TryParse(tbDuracion.Text, out int duracion))
                {
                    MostrarError("La duración debe ser un número válido (segundos)");
                    tbDuracion.Focus();
                    return false;
                }

                if (duracion <= 0)
                {
                    MostrarError("La duración debe ser mayor que cero");
                    tbDuracion.Focus();
                    return false;
                }
            }

            return true;
        }

        //PRE: Los datos del libro en papel han sido validados previamente.
        //POST: Se crea un objeto LibroPapel y se da de alta en el sistema.
        private void DarAltaLibroPapel()
        {
            string titulo = tbTitulo.Text.Trim();
            string autor = tbAutor.Text.Trim();
            string editorial = tbEditorial.Text.Trim();
            int anio = int.Parse(tbAnoEdicion.Text);

            LibroPapel libro = new LibroPapel(isbn, titulo, autor, editorial, anio);

            lnAdq.AltaLibroPapel(libro);
        }

        //PRE: Los datos del audiolibro han sido validados previamente.
        //POST: Se crea un objeto AudioLibro y se da de alta en el sistema.
        private void DarAltaAudioLibro()
        {
            string titulo = tbTitulo.Text.Trim();
            string autor = tbAutor.Text.Trim();
            string editorial = tbEditorial.Text.Trim();
            int anio = int.Parse(tbAnoEdicion.Text);

            string formatoDigital = tbFormatoDigital.Text.Trim();
            int duracion = int.Parse(tbDuracion.Text);

            AudioLibro audioLibro = new AudioLibro(isbn, titulo, autor, editorial, anio, formatoDigital, duracion);

            lnAdq.AltaAudioLibro(audioLibro);
        }

        //PRE: El formulario está abierto y el usuario pulsa Cancelar.
        //POST: Se cierra el formulario devolviendo DialogResult.Cancel.
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //PRE: El formulario se está cerrando.
        //POST: Si no se ha establecido un DialogResult, se asigna Cancel.
        private void FAltaDocumento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

    }
}