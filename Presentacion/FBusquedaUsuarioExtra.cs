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
    public partial class FBusquedaUsuarioExtra : FComun
    {
        private ILNPersonal lnp;
        private BindingSource bindingSourceUsuarios;

        public FBusquedaUsuarioExtra(ILNPersonal lnp)
        {
            this.lnp = lnp;
            InitializeComponent();
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            try
            {
                var usuarios = lnp.GetUsuariosActivos();
                if (usuarios == null || usuarios.Count == 0)
                {
                    MostrarInformacion("No hay usuarios activos en el sistema.");
                    return;
                }

                bindingSourceUsuarios = new BindingSource();
                bindingSourceUsuarios.DataSource = usuarios;

                comboBox_Dnis.DataSource = bindingSourceUsuarios;
                comboBox_Dnis.DisplayMember = "Dni";
                comboBox_Dnis.ValueMember = "Dni";

                comboBox_Dnis.SelectedIndexChanged += ComboBox_Dnis_SelectedIndexChanged;

                MostrarUsuarioSeleccionado();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al inicializar el formulario: {ex.Message}");
            }
        }

        private void ComboBox_Dnis_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarUsuarioSeleccionado();
        }

        private void MostrarUsuarioSeleccionado()
        {
            if (comboBox_Dnis.SelectedIndex>= 0 && comboBox_Dnis.SelectedItem != null)
            {
                Usuario usuario = comboBox_Dnis.SelectedItem as Usuario;
                if (usuario != null)
                {
                    textBox_Nombre.Text = usuario.Nombre;
                    MostrarInfoRestante(usuario.Dni);
                }
            }
        }

        private void MostrarInfoRestante(string dni)
        {
            try
            {
                int prestamosActivos = lnp.GetNumPrestamosActivosPorUsuario(dni);
                textBox_PrestamosActivos.Text = prestamosActivos.ToString();

                int ejemplaresUltMes = lnp.GetNumEjemplaresUltimoMes(dni);
                textBox_EjemUltMes.Text = ejemplaresUltMes.ToString();

                int prestamosVencidos = lnp.GetNumPrestamosVencidos(dni);
                textBox_PrestVencidos.Text = prestamosVencidos.ToString();

            }
            catch (Exception ex)
            {
                textBox_PrestamosActivos.Text = "0";
                textBox_EjemUltMes.Text = "0";
                textBox_PrestVencidos.Text = "0";

                MessageBox.Show($"Error al cargar información de préstamos: {ex.Message}",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bt_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
