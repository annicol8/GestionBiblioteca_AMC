using System;
using System.Drawing;
using ModeloDominio;

namespace Presentacion
{
    public partial class FBuscarUsuario : FComun
    {
        private Usuario usuario;

        public FBuscarUsuario()
        {
            InitializeComponent();
        }
        /* PRE: usuario puede ser null
   POST: Inicializa el formulario con el usuario a mostrar */
        public FBuscarUsuario(Usuario usuario) : this()
        {
            this.usuario = usuario;
        }
        /* PRE: usuario != null
   POST: Muestra la información del usuario en modo solo lectura.
         Si está dado de baja, cambia el color de fondo y muestra advertencia */
        private void FBuscarUsuario_Load(object sender, EventArgs e)
        {
            tbDni.Text = usuario.Dni;
            tbNombre.Text = usuario.Nombre;

            tbDni.ReadOnly = true;
            tbNombre.ReadOnly = true;

            if (usuario.DadoAlta)
            {
                label_Estado.Text = "Estado: ACTIVO";
                label_Estado.ForeColor = Color.Green;
                this.BackColor = SystemColors.Control;
            }
            else
            {
                label_Estado.Text = "Estado: DADO DE BAJA";
                label_Estado.ForeColor = Color.Black;
                this.BackColor = Color.LightCoral;

                MostrarAdvertencia(
                    "Este usuario está dado de baja y no puede realizar operaciones.",
                    "Usuario Inactivo");
            }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
