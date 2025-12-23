using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FLogin : Form
    {
        private ILNPersonal lnp;

        public FLogin()
        {
            InitializeComponent();
        }
        public FLogin(ILNPersonal lnp)
        {
            InitializeComponent();
            this.lnp = lnp;

            toolTip1.SetToolTip(textBox_Nombre, "Introduce tu nombre");
            toolTip1.SetToolTip(textBox_Contraseña, "Introduce la contraseña");
            toolTip1.SetToolTip(radioButton_PSala, "Acceso para personal de sala");
            toolTip1.SetToolTip(radioButton_PAdq, "Acceso para personal de adquisiciones");
            toolTip1.SetToolTip(bt_Entrar, "Acceso a la aplicacion");

        }

        private void bt_Entrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Nombre.Text))
            {
                MessageBox.Show("Por favor, introduzca el nombre", "Campo obligatorio",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Nombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_Contraseña.Text))
            {
                MessageBox.Show("Por favor, introduzca la contraseña", "Campo obligatorio",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Contraseña.Focus();
                return;
            }

            if(!radioButton_PSala.Checked && !radioButton_PAdq.Checked)
            {
                MessageBox.Show("Por favor, seleccione el tipo de personal", "Tipo de personal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = textBox_Nombre.Text.Trim();
            string password = textBox_Contraseña.Text.Trim();
            
            TipoPersonal tipoSeleccionado;
            if (radioButton_PSala.Checked) { tipoSeleccionado = TipoPersonal.personalSala;  }
            else { tipoSeleccionado = TipoPersonal.personalAdquisiciones; }

            Personal personalABuscar = LNPersonal.Login(nombre, password, tipoSeleccionado);

            if (personalABuscar == null)
            {
                MessageBox.Show(
                    "Credenciales incorrectas.\n\n" +
                    "Verifique el nombre, contraseña y tipo seleccionado.",
                    "Personal no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Limpiar contraseña por seguridad
                textBox_Contraseña.Clear();
                textBox_Nombre.Focus();
                return;
            }

            this.Hide();

            if(personalABuscar is PersonalSala ps)
            {
                ILNPSala lnSala = new LNPSala(ps);
                FPSala formSala = new FPSala(lnSala);
                formSala.ShowDialog();
                    
            } else if(personalABuscar is PersonalAdquisiciones pa)
            {

                ILNPAdq lnAdq = new LNPAdq(pa);
                FPAdq formAdq = new FPAdq(lnAdq);
                formAdq.ShowDialog();
            } else
            {
                MessageBox.Show("Personal no reconocido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }


    }
}
