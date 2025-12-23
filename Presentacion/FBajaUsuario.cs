using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public FBajaUsuario(ILNPersonal lnp, Usuario usuario) : this()
        {
            this.lnp = lnp;
            this.usuario = usuario;
        }

        private void FBajaUsuario_Load(object sender, EventArgs e)
        {
            // Cargar los datos del usuario
            tbDni.Text = usuario.Dni;
            tbNombre.Text = usuario.Nombre;

            tbDni.ReadOnly = true;
            tbNombre.ReadOnly = true;


        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MostrarPregunta("¿Está seguro que desea dar de baja al usuario?", "Aviso");

            if (dr == DialogResult.Yes)
            {
                lnp.BajaUsuario(usuario);
                MostrarInformacion("Usuario eliminado", "Aviso");
                this.Close();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}