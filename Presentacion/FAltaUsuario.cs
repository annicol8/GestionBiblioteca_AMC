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
            this.AcceptButton = btAceptar;
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
            if (!ValidarCampoNoVacio(tbNombre, "Nombre"))
                return;

            string nombre = tbNombre.Text.Trim();
            if (!ValidarNombre(nombre))
            {
                tbNombre.Focus();
                return;
            }
            nombre = NormalizarNombre(nombre);


            if (!ValidarDNI(dniUsuario))
            {
                MostrarError("El DNI introducido no es válido.");
                this.Close();
                return;
            }

            try
            {
                Usuario usuarioExistente = lnp.GetUsuario(dniUsuario);

                if (usuarioExistente != null && usuarioExistente.DadoAlta)
                {
                    MostrarAdvertencia(
                        $"Ya existe un usuario activo con el DNI {dniUsuario}.\n\n" +
                        "No se puede dar de alta un usuario con un DNI duplicado.",
                        "DNI duplicado");
                    this.Close();
                    return;
                }

                if (usuarioExistente != null && !usuarioExistente.DadoAlta)
                {
                    DialogResult resultado = MostrarPregunta(
                        $"Existe un usuario dado de baja con el DNI {dniUsuario}.\n" +
                        $"Nombre anterior: {usuarioExistente.Nombre}\n\n" +
                        "¿Desea reactivar este usuario en lugar de crear uno nuevo?",
                        "Usuario dado de baja");

                    if (resultado == DialogResult.Yes)
                    {
                        // Reactivar usuario existente
                        usuarioExistente.DadoAlta = true;
                        usuarioExistente.Nombre = tbNombre.Text.Trim(); // Actualizar nombre si cambió
                        lnp.ModificarUsuario(usuarioExistente);
                        MostrarExito("Usuario reactivado correctamente");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                    else
                    {
                        this.Close();
                        return;
                    }
                    
                }

                Usuario u = new Usuario(dniUsuario, nombre, true);
                lnp.AltaUsuario(u); 

                MostrarExito("Usuario dado de alta correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "dar de alta el usuario");
            }



        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FAltaUsuario_Shown(object sender, EventArgs e)
        {
            tbNombre.Focus();
        }


    }
}
