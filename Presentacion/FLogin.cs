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
        public FLogin()
        {
            InitializeComponent();
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

            Personal personalABuscar = LNLogin.BuscarPersonalPorNombreYTipo(nombre, tipoSeleccionado);

            if (personalABuscar == null)
            {
                MessageBox.Show(
                    "No se encontró ningún personal con los datos introducidos.\n\n" +
                    "Verifique el nombre y el tipo de personal seleccionado.",
                    "Personal no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Limpiar contraseña por seguridad
                textBox_Contraseña.Clear();
                textBox_Nombre.Focus();
                return;
            }

            try
            {
                if(tipoSeleccionado == TipoPersonal.personalSala)
                {
                    //ILNPSala ln = new LNPSala((PersonalSala)personalABuscar);
                    //FPSala formSala = new FPSala(ln);
                    
                    //FPSala formSala = new FPSala(personalABuscar);
                    this.Hide();
                    //formSala.ShowDialog();
                    this.Close();
                } else {
                    //ILNPAdqln = new LNPAdq((PersonalAdq)personalABuscar);
                    //FPAdq formAdq = new FPAdq(ln);
                    FPAdq formAdq = new FPAdq(personalABuscar);
                    this.Hide();
                    formAdq.ShowDialog();
                    this.Close();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al iniciar la aplicación:\n\n{ex.Message}",
                    "Error crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Mostrar el formulario de login de nuevo
                this.Show();
            }
        }

    }
}
