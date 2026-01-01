using System;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FBajaUsuario : FComun
    {
        private ILNPersonal lnp;
        private Usuario usuario;

        public FBajaUsuario()
        {
            InitializeComponent();
            this.AcceptButton = btAceptar;
        }
        /* PRE: lnp != null, usuario != null
   POST: Inicializa el formulario con los datos necesarios para dar de baja un usuario */
        public FBajaUsuario(ILNPersonal lnp, Usuario usuario) : this()
        {
            this.lnp = lnp;
            this.usuario = usuario;
        }
        /* PRE: usuario != null
   POST: Carga y muestra la información del usuario en modo solo lectura.
         Si el usuario ya está dado de baja, muestra error y cierra el formulario */
        private void FBajaUsuario_Load(object sender, EventArgs e)
        {
            // Cargar los datos del usuario
            tbDni.Text = usuario.Dni;
            tbNombre.Text = usuario.Nombre;

            tbDni.ReadOnly = true;
            tbNombre.ReadOnly = true;

            if (!usuario.DadoAlta)
            {
                MostrarError("Este usuario ya está dado de baja.");
                this.Close();
            }
        }
        /* PRE: usuario.DadoAlta == true, lnp inicializado
   POST: Si el usuario confirma, marca al usuario como inactivo.
         Cierra con DialogResult.OK si tiene éxito, muestra error en caso contrario */
        private void btAceptar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MostrarPregunta(
                $"¿Está seguro que desea dar de baja al usuario?\n\n" +
                "Esta acción marcará al usuario como inactivo.",
                "Confirmar baja");

            if (dr == DialogResult.Yes)
            {
                try
                {
                    lnp.BajaUsuario(usuario);
                    MostrarExito($"Usuario '{usuario.Nombre}' dado de baja correctamente.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    ManejarExcepcion(ex, "dar de baja al usuario");
                }
            }
        }
        /* PRE: -
   POST: Cierra el formulario con DialogResult.Cancel */
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}