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

            Personal personalABuscar = Persistencia.Persistencia.BuscarPersonalPorNombreYTipo(nombre, tipoSeleccionado);
            if (personalABuscar == null) 
            {
                MessageBox.Show("No se encontro ningún personal con los datos introducidos", "Personal no encontrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Falta de implementar en el caso de q seleccionar cada tipo de personal llevar al FormMenu de cada personal seleccionado




        }
    }
}
