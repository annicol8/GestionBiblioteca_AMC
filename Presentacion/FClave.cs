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
        public string Clave
        {
            get { return textBox_Clave.Text.Trim(); }
        }
        public FClave(string mensaje)
        {
            InitializeComponent();
            lb_Mensaje.Text = mensaje;
            this.Text = mensaje;

            this.AcceptButton = button_Aceptar;
            this.CancelButton = button_Cancelar;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

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

        private void FClave_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            textBox_Clave.Focus();
        }

    }
}
