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
            this.AcceptButton = btAceptar;
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

            if (!usuario.DadoAlta)
            {
                MostrarError("Este usuario ya está dado de baja.");
                this.Close();
            }
        }

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

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}