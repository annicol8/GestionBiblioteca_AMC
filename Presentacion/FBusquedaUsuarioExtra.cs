using System;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FBusquedaUsuarioExtra : FComun
    {
        private ILNPersonal lnp;
        private BindingSource bindingSourceUsuarios;

        /* PRE: lnp != null
        POST: Inicializa el formulario y carga los usuarios activos del sistema */
        public FBusquedaUsuarioExtra(ILNPersonal lnp)
        {
            this.lnp = lnp;
            InitializeComponent();
            InicializarFormulario();
        }
        /* PRE: lnp inicializado
        POST: Carga los usuarios activos en el comboBox y muestra el primero seleccionado.
         Si no hay usuarios, muestra mensaje informativo */
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
        /* PRE: comboBox_Dnis inicializado con usuarios
   POST: Actualiza la información mostrada del usuario seleccionado */
        private void ComboBox_Dnis_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarUsuarioSeleccionado();
        }
        /* PRE: comboBox_Dnis con elementos cargados
   POST: Muestra el nombre y la información de préstamos del usuario seleccionado en el comboBox */
        private void MostrarUsuarioSeleccionado()
        {
            if (comboBox_Dnis.SelectedIndex >= 0 && comboBox_Dnis.SelectedItem != null)
            {
                Usuario usuario = comboBox_Dnis.SelectedItem as Usuario;
                if (usuario != null)
                {
                    textBox_Nombre.Text = usuario.Nombre;
                    MostrarInfoRestante(usuario.Dni);
                }
            }
        }
        /* PRE: dni != null && dni corresponde a un usuario existente, lnp inicializado
   POST: Muestra el número de préstamos activos, ejemplares del último mes y préstamos vencidos.
         Si hay error, muestra 0 en todos los campos y mensaje de advertencia */
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
