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

        //PRE:
        //POST: Se inicializa el formulario y se establece el botón Aceptar como botón por defecto.
        public FAltaUsuario() : base()
        {
            InitializeComponent();
            this.AcceptButton = btAceptar;
        }

        //PRE: lnp no nulO y dni debe contener un DNI válido.
        //POST: Se inicializa el formulario con la lógica de negocio y el DNI del usuario.
        public FAltaUsuario(ILNPersonal lnp, string dni) : this()
        {
            this.lnp = lnp;
            this.dniUsuario = dni;
        }

        //PRE: El formulario ya creado y dniUsuario contiene un valor.
        //POST: El DNI se muestra en el textbox y queda en modo solo lectura.
        private void FAltaUsuario_Load(object sender, EventArgs e)
        {
            tbDni.Text = dniUsuario;
            tbDni.ReadOnly = true;  
        }

        //PRE: El usuario ha introducido datos en el formulario y ha pulsado Aceptar.
        //POST: Se valida la información y:
        //      - Se da de alta un nuevo usuario, o
        //      - Se reactiva un usuario dado de baja, o
        //      - Se muestra un mensaje de error/advertencia y se cierra el formulario.

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
                        usuarioExistente.Nombre = tbNombre.Text.Trim(); 
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

        //PRE: El formulario está abierto y se ha pulsado el botón cancelar
        //POST: Se cierra el formulario devolviendo DialogResult.Cancel.
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //PRE: El formulario ya es visible para el usuario.
        //POST: El foco queda situado en el textbox del nombre.
        private void FAltaUsuario_Shown(object sender, EventArgs e)
        {
            tbNombre.Focus();
        }


    }
}
