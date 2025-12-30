using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Presentacion
{
    public partial class FClave : Form
    {
        //PRE: El formulario ha sido inicializado y el TextBox de clave existe.
        //POST: Devuelve el texto introducido en el TextBox, sin espacios en blanco al inicio y al final.
        public string Clave
        {
            get { return textBox_Clave.Text.Trim(); }
        }

        //PRE: El mensaje recibido no es nulo y describe el valor que se solicita al usuario.
        //POST: El formulario queda inicializado mostrando el mensaje indicado y configurados los botones Aceptar y Cancelar.
        public FClave(string mensaje)
        {
            InitializeComponent();
            lb_Mensaje.Text = mensaje + ": ";
            this.Text = "Introducir " + mensaje;

            this.AcceptButton = button_Aceptar;
            this.CancelButton = button_Cancelar;
        }

        //PRE: El formulario está abierto y el usuario pulsa el botón Cancelar.
        //POST: Se cierra el formulario indicando que la operación ha sido cancelada.
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //PRE: El formulario está abierto y el usuario pulsa el botón Aceptar.
        //POST: Si el campo no está vacío, se cierra el formulario devolviendo OK; en caso contrario, se muestra un aviso.
        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Clave.Text))
            {
                MessageBox.Show("Debe introducir un valor",  "Campo obligatorio",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Clave.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //PRE: El formulario va a mostrarse por primera vez.
        //POST: El formulario se muestra centrado respecto al formulario padre y el foco queda en el TextBox de clave.
        private void FClave_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            textBox_Clave.Focus();
        }

    }
}
