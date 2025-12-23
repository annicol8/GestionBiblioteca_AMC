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
    public partial class FAltaUsuario : FComun
    {
        private ILNPersonal lnp;
        private string dniUsuario;

        public FAltaUsuario() : base()
        {
            InitializeComponent();
        }

        public FAltaUsuario(ILNPersonal lnp, string dni) : this()
        {
            this.lnp = lnp;
            this.dniUsuario = dni;
        }

        private void FAltaUsuario_Load(object sender, EventArgs e)
        {
            tbDni.Text = dniUsuario;
            tbDni.ReadOnly = true;  
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNombre.Text))
            {
                MostrarError("Debes introducir un nombre para el usuario");
                tbNombre.Focus();
                return;
            }

            string nombre = tbNombre.Text.Trim();

            Usuario u = new Usuario(dniUsuario, nombre, true);

            lnp.AltaUsuario(u); // Hay que pasar un usuario

            MostrarExito("Usuario dado de alta correctamente");
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FAltaUsuario_Shown(object sender, EventArgs e)
        {
            tbNombre.Focus();
        }


    }
}
