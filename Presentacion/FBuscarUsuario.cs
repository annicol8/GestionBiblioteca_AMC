using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public FBuscarUsuario(Usuario usuario) : this()
        {
            this.usuario = usuario;
        }

        private void FBuscarUsuario_Load(object sender, EventArgs e)
        {
            // Cargar los datos del usuario
            tbDni.Text = usuario.Dni;
            tbNombre.Text = usuario.Nombre;

            tbDni.ReadOnly = true;
            tbNombre.ReadOnly = true;
        }

    }
}
