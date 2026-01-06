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
        //PRE:
        //POST: Se inicializa el formulario común.
        public FComun()
        {
            InitializeComponent();
        }

        //Métodos para mostrar mensajes al usuario.

        //PRE: El mensaje no debe ser null.
        //POST: Se muestra un mensaje informativo al usuario.
        protected void MostrarInformacion(string mensaje, string titulo = "Información")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //PRE: El mensaje no debe ser null.
        //POST: Se muestra un mensaje de advertencia al usuario.
        protected void MostrarAdvertencia(string mensaje, string titulo = "Advertencia")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //PRE: El mensaje no debe ser null.
        //POST: Se muestra un mensaje de error al usuario.
        protected void MostrarError(string mensaje, string titulo = "Error")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //PRE: El mensaje y el título no deben ser null.
        //POST: Se muestra una pregunta al usuario y se devuelve su respuesta.
        protected DialogResult MostrarPregunta(string mensaje, string titulo)
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        //PRE: El mensaje no debe ser null.
        //POST: Devuelve true si el usuario confirma la acción; false en caso contrario.
        protected bool SolicitarConfirmacion(string mensaje, string titulo = "Confirmación")
        {
            DialogResult result = MessageBox.Show(
                mensaje,
                titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        //PRE: El mensaje no debe ser null.
        //POST: Se muestra un mensaje de éxito al usuario.
        protected void MostrarExito(string mensaje, string titulo = "Operación Exitosa")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        #region LIMPIARCAMPOS

        //PRE: El formulario contiene controles inicializados.
        //POST: Se limpian todos los campos del formulario.
        protected void LimpiarCampos()
        {
            foreach (Control control in this.Controls)
            {
                LimpiarControlRecursivo(control);
            }
        }

        //PRE: El control no debe ser null.
        //POST: Se limpian los valores del control y de todos sus controles hijos.
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

            foreach (Control hijo in control.Controls)
            {
                LimpiarControlRecursivo(hijo);
            }
        }

        #endregion


        #region VALIDACIONES
        
        //PRE: El TextBox debe estar inicializado.
        //POST: Devuelve true si el campo no está vacío; en caso contrario muestra advertencia.
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


        //PRE: El nombre no debe ser null.
        //POST: Devuelve true si el nombre cumple el formato válido.
        protected bool ValidarNombre(string nombre, string nombreCampo = "Nombre")
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarAdvertencia($"El campo '{nombreCampo}' no puede estar vacío.");
                return false;
            }

            nombre = nombre.Trim();

            if (nombre.Length < 2)
            {
                MostrarAdvertencia($"El campo '{nombreCampo}' debe tener al menos 2 caracteres.");
                return false;
            }

            if (nombre.Length > 20)
            {
                MostrarAdvertencia($"El campo '{nombreCampo}' no puede superar los 20 caracteres.");
                return false;
            }

            foreach (char c in nombre)
            {
                if (!char.IsLetter(c) && c != ' ' && c != '-' && c != '\'' && c != 'ñ' && c != 'Ñ')
                {
                    MostrarAdvertencia(
                        $"El campo '{nombreCampo}' solo puede contener letras, espacios, guiones y apóstrofes.\n\n" +
                        "No se permiten números ni caracteres especiales.",
                        "Formato inválido");
                    return false;
                }
            }

            if (nombre.Contains("  "))
            {
                MostrarAdvertencia(
                    $"El campo '{nombreCampo}' no puede contener espacios consecutivos.",
                    "Formato inválido");
                return false;
            }

            if (nombre.StartsWith(" ") || nombre.EndsWith(" ") ||
                nombre.StartsWith("-") || nombre.EndsWith("-") ||
                nombre.StartsWith("'") || nombre.EndsWith("'"))
            {
                MostrarAdvertencia(
                    $"El campo '{nombreCampo}' tiene un formato incorrecto.",
                    "Formato inválido");
                return false;
            }

            return true;
        }

        //PRE: El nombre puede ser null o vacío.
        //POST: Devuelve el nombre normalizado (primera letra en mayúscula).
        protected string NormalizarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return nombre;

            nombre = nombre.Trim();

            nombre = nombre.ToLower();

            System.Globalization.TextInfo textInfo =
                System.Globalization.CultureInfo.CurrentCulture.TextInfo;

            return textInfo.ToTitleCase(nombre);
        }

        //PRE: El DNI no debe ser null.
        //POST: Devuelve true si el DNI es válido según el algoritmo oficial.
        protected bool ValidarDNI(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return false;

            dni = dni.Trim().ToUpper();

            // Formato: 8 dígitos + 1 letra
            if (dni.Length != 9)
                return false;

            //  primeros 8 caracteres son dígitos
            string numeros = dni.Substring(0, 8);
            if (!int.TryParse(numeros, out int dniNumero))
                return false;

            //  último carácter es una letra
            char letra = dni[8];
            if (!char.IsLetter(letra))
                return false;

            // Validar que la letra sea correcta
            string letrasValidas = "TRWAGMYFPDXBNJZSQVHLCKE";
            char letraCalculada = letrasValidas[dniNumero % 23];

            return letraCalculada == letra;
        }

        // Acepta cualquier cadena que, quitando guiones y espacios, sea un número de 13 dígitos y tenga un dígito de control ISBN-13 correcto. Ej: 978-0-306-40615-7

        //PRE: El ISBN no debe ser null.
        //POST: Devuelve true si el ISBN-13 es válido.
        protected bool ValidarISBN(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return false;

            isbn = isbn.Replace("-", "").Replace(" ", "");

            // Debe tener 13 dígitos
            if (isbn.Length != 13)
                return false;

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

        //PRE: El TextBox debe estar inicializado.
        //POST: Devuelve true si el valor es un entero positivo válido.
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


        //PRE: El ComboBox debe estar inicializado.
        //POST: Devuelve true si hay un elemento seleccionado.
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
        #endregion


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

        #endregion

        //PRE: La excepción no debe ser null.
        //POST: Se muestra un mensaje de error asociado a la operación.
        protected void ManejarExcepcion(Exception ex, string operacion)
        {
            string mensaje = $"Error al {operacion}: {ex.Message} ";


            MostrarError(mensaje);

            // Aquí podrías agregar logging si lo implementas
            // Logger.Error(ex, operacion);
        }

        //PRE: El mensaje no debe ser null.
        //POST: Devuelve la clave introducida convertida al tipo T.
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

        // PRE: El TextBox debe estar inicializado
        // POST: Devuelve true si la contraseña cumple los requisitos mínimos
        protected bool ValidarContraseña(TextBox textBox, string nombreCampo = "Contraseña")
        {
            if (textBox == null)
                throw new ArgumentNullException(nameof(textBox));

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MostrarAdvertencia($"El campo '{nombreCampo}' no puede estar vacío.");
                textBox.Focus();
                return false;
            }

            string contraseña = textBox.Text.Trim();

            if (contraseña.Length < 5)
            {
                MostrarAdvertencia($"El campo '{nombreCampo}' debe tener al menos 5 caracteres.");
                textBox.Focus();
                return false;
            }

            if (contraseña.Contains(" "))
            {
                MostrarAdvertencia($"El campo '{nombreCampo}' no puede contener espacios.");
                textBox.Focus();
                return false;
            }

            return true;
        }


    }
}
