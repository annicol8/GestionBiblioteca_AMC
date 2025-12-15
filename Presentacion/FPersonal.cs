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
    public partial class FPersonal : FComun
    {
        /*private Personal personal;
         * 
        private Personal Personal
        {
            get { return personal; }
            set { personal = value; }
        }*/

        protected ILNPersonal lnp;




        public FPersonal()
        {
            InitializeComponent();
        }

        public FPersonal(ILNPersonal lnp) : this()
        {
            this.lnp = lnp;
        }


        private void menuUsuariosAlta_Click(object sender, EventArgs e)
        {
            string dni;

            while (true)
            {
                dni = pedirDNI();

                if (dni == null)
                    return; // cancelado

                Usuario usuarioExistente = lnp.GetUsuario(dni);


                if (usuarioExistente != null && usuarioExistente.DadoAlta)
                {
                    DialogResult dr = MostrarPregunta(
                        "¿Quieres introducir otro?",
                        "Ya existe un usuario activo con ese DNI"
                    );
                    if (dr == DialogResult.Yes)
                        continue;
                    else
                        return;
                }

                // DNI válido
                break;
            }

            FAltaUsuario formulario = new FAltaUsuario(lnp, dni);
            formulario.ShowDialog(this);
        }

        

        private string pedirDNI()
        {
            FClave fClave = new FClave("DNI");

            if (fClave.ShowDialog(this) == DialogResult.OK)

            {
                return fClave.Clave;

            }
            return null;
        }

        private void menuUsuariosBuscar_Click(object sender, EventArgs e)
        {
            string dni;
            while (true)
            {
                dni = pedirDNI();
                if (dni == null)
                    return; // cancelado

                Usuario usuario = lnp.GetUsuario(dni);

                if (usuario == null)
                {
                    DialogResult dr = MostrarPregunta(
                        "¿Quieres introducir otro?",
                        "No existe un usuario con ese DNI"
                    );
                    if (dr == DialogResult.Yes)
                        continue;
                    else
                        return;
                }

                FBuscarUsuario formulario = new FBuscarUsuario(usuario);
                formulario.ShowDialog(this);
                return;
            }
        }
    }
}
