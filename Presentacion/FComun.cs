using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FComun : Form
    {
        public FComun()
        {
            InitializeComponent();
        }

        // Métodos para mostrar mensajes al usuario. Falta añadir los iconoes

        protected void MostrarInformacion(string mensaje, string titulo = "Información")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void MostrarAdvertencia(string mensaje, string titulo = "Advertencia")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        protected void MostrarError(string mensaje, string titulo = "Error")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        protected DialogResult MostrarPregunta(string mensaje, string titulo)
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        protected bool SolicitarConfirmacion(string mensaje, string titulo = "Confirmación")
        {
            DialogResult result = MessageBox.Show(
                mensaje,
                titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        protected void MostrarExito(string mensaje, string titulo = "Operación Exitosa")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        // Para limpiar los campos de texto en un formulario

        protected void LimpiarCampos()
        {
            foreach (Control control in this.Controls)
            {
                LimpiarControlRecursivo(control);
            }
        }

        private void LimpiarControlRecursivo(Control control)
        {
            if (control is TextBox textBox)
            {
                textBox.Clear();
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.SelectedIndex = -1;
            }
            else if (control is CheckBox checkBox)
            {
                checkBox.Checked = false;
            }
            else if (control is RadioButton radioButton)
            {
                radioButton.Checked = false;
            }
            else if (control is ListBox listBox)
            {
                listBox.Items.Clear();
            }
            else if (control is NumericUpDown numericUpDown)
            {
                numericUpDown.Value = numericUpDown.Minimum;
            }
            else if (control is DateTimePicker dateTimePicker)
            {
                dateTimePicker.Value = DateTime.Now;
            }

            // Recursividad para controles contenedores (Panel, GroupBox, etc.)
            foreach (Control hijo in control.Controls)
            {
                LimpiarControlRecursivo(hijo);
            }
        }




        // Métodos para validaciones


        protected bool ValidarCampoNoVacio(TextBox textBox, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MostrarAdvertencia($"El campo '{nombreCampo}' no puede estar vacío.");
                textBox.Focus();
                return false;
            }
            return true;
        }


        protected bool ValidarCamposNoVacios(params (TextBox textBox, string nombre)[] campos)
        {
            foreach (var campo in campos)
            {
                if (!ValidarCampoNoVacio(campo.textBox, campo.nombre))
                    return false;
            }
            return true;
        }

        protected bool ValidarDNI(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return false;

            dni = dni.Trim().ToUpper();

            // Formato: 8 dígitos + 1 letra
            if (dni.Length != 9)
                return false;

            // Comprobar que los primeros 8 caracteres son dígitos
            string numeros = dni.Substring(0, 8);
            if (!int.TryParse(numeros, out int dniNumero))
                return false;

            // Validar que el último carácter es una letra
            char letra = dni[8];
            if (!char.IsLetter(letra))
                return false;

            // Validar que la letra sea correcta
            string letrasValidas = "TRWAGMYFPDXBNJZSQVHLCKE";
            char letraCalculada = letrasValidas[dniNumero % 23];

            return letraCalculada == letra;
        }

        protected bool ValidarISBN(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return false;

            // Eliminar guiones
            isbn = isbn.Replace("-", "").Replace(" ", "");

            // Debe tener 13 dígitos
            if (isbn.Length != 13)
                return false;

            // Todos deben ser dígitos
            if (!long.TryParse(isbn, out _))
                return false;

            // Validar dígito de control
            int suma = 0;
            for (int i = 0; i < 12; i++)
            {
                int digito = int.Parse(isbn[i].ToString());
                suma += (i % 2 == 0) ? digito : digito * 3;
            }

            int digitoControl = (10 - (suma % 10)) % 10;
            int ultimoDigito = int.Parse(isbn[12].ToString());

            return digitoControl == ultimoDigito;
        }


        protected bool ValidarNumeroEnteroPositivo(TextBox textBox, string nombreCampo, out int valor)
        {
            valor = 0;

            if (!ValidarCampoNoVacio(textBox, nombreCampo))
                return false;

            if (!int.TryParse(textBox.Text, out valor))
            {
                MostrarAdvertencia($"El campo '{nombreCampo}' debe ser un número válido.");
                textBox.Focus();
                return false;
            }

            if (valor <= 0)
            {
                MostrarAdvertencia($"El campo '{nombreCampo}' debe ser un número positivo.");
                textBox.Focus();
                return false;
            }

            return true;
        }


        protected bool ValidarAnio(TextBox textBox, string nombreCampo, out int anio)
        {
            anio = 0;

            if (!ValidarNumeroEnteroPositivo(textBox, nombreCampo, out anio))
                return false;

            int anioActual = DateTime.Now.Year;
            if (anio < 1900 || anio > anioActual + 1)
            {
                MostrarAdvertencia($"El año debe estar entre 1900 y {anioActual + 1}.");
                textBox.Focus();
                return false;
            }

            return true;
        }

        protected bool ValidarSeleccionComboBox(ComboBox comboBox, string nombreCampo)
        {
            if (comboBox.SelectedIndex == -1)
            {
                MostrarAdvertencia($"Debe seleccionar un valor para '{nombreCampo}'.");
                comboBox.Focus();
                return false;
            }
            return true;
        }



        #region Utilidades de Interfaz

        /// <summary>
        /// Habilita o deshabilita un conjunto de controles
        /// </summary>
        protected void EstablecerEstadoControles(bool habilitado, params Control[] controles)
        {
            foreach (var control in controles)
            {
                control.Enabled = habilitado;
            }
        }

        /// <summary>
        /// Muestra u oculta un conjunto de controles
        /// </summary>
        protected void EstablecerVisibilidadControles(bool visible, params Control[] controles)
        {
            foreach (var control in controles)
            {
                control.Visible = visible;
            }
        }

        /// <summary>
        /// Aplica estilo visual a un botón (opcional)
        /// </summary>
        protected void EstilizarBoton(Button boton, Color colorFondo, Color colorTexto)
        {
            boton.BackColor = colorFondo;
            boton.ForeColor = colorTexto;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
        }

        #endregion


        protected void ManejarExcepcion(Exception ex, string operacion)
        {
            string mensaje = $"Error al {operacion}: {ex.Message} ";


            MostrarError(mensaje);

            // Aquí podrías agregar logging si lo implementas
            // Logger.Error(ex, operacion);
        }

        protected T pedirClave<T>(string mensaje)
        {
            while (true)
            {
                FClave fClave = new FClave(mensaje);

                if (fClave.ShowDialog(this) != DialogResult.OK)
                    return default;

                string texto = fClave.Clave;

                try
                {
                    return (T)Convert.ChangeType(texto, typeof(T));
                }
                catch
                {
                    MessageBox.Show(
                        $"El valor introducido no es un {typeof(T).Name} válido",
                        "Valor incorrecto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        


    }
}
