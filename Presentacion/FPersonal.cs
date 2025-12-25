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
        protected ILNPersonal lnp;

        public FPersonal()
        {
            InitializeComponent();
        }

        public FPersonal(ILNPersonal lnp) : this()
        {
            this.lnp = lnp;
        }

        protected void ActualizarTituloFormulario()
        {
            if (lnp?.Personal != null)
            {
                string tipoPersonal;
                if (lnp.Personal.Tipo == TipoPersonal.personalSala)
                {
                    tipoPersonal = "Personal de sala";
                }
                else
                {
                    tipoPersonal = "Personal de servicio de adquisiciones";
                }
                this.Text = $"{lnp.Personal.Nombre} - Gestión de biblioteca - {tipoPersonal}";
            }
        }

        protected void OcultarDocumentos()
        {
            documentosToolStripMenuItem.Visible = false;
        }

        protected void OcultarEjemplares()
        {
            ejemplaresToolStripMenuItem.Visible = false;
        }

        protected void OcultarPrestamos()
        {
            prestamosToolStripMenuItem.Visible = false;
        }


        private void menuUsuariosAlta_Click(object sender, EventArgs e)
        {
            string dni;

            while (true)
            {
                dni = pedirDNI();

                if (dni == null)
                    return; // cancelado

                if (!ValidarDNI(dni))
                {
                    MostrarAdvertencia(
                        "El DNI introducido no tiene un formato válido.\n\n" +
                        "Formato correcto: 8 dígitos seguidos de una letra (ej: 12345678Z)",
                        "DNI inválido");
                    continue; // Pedir de nuevo
                }

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
                return fClave.Clave?.Trim().ToUpper();

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
                        $"No existe ningún usuario con el DNI {dni}.\n\n" +
                        "¿Desea introducir otro DNI?",
                        "Usuario no encontrado");
                    if (dr == DialogResult.Yes)
                        continue;
                    else
                        return;
                }

                if (!usuario.DadoAlta)
                {
                    DialogResult dr = MostrarPregunta(
                        $"El usuario con DNI {dni} está dado de baja.\n\n" +
                        "¿Desea ver los datos del usuario inactivo de todos modos?",
                        "Usuario dado de baja");

                    if (dr == DialogResult.No)
                    {
                        DialogResult buscarOtro = MostrarPregunta(
                            "¿Desea buscar otro usuario?",
                            "Buscar otro");

                        if (buscarOtro == DialogResult.Yes)
                            continue;
                        else
                            return;
                    }
                }

                FBuscarUsuario formulario = new FBuscarUsuario(usuario);
                formulario.ShowDialog(this);
                return;
            }
        }

        private void menuUsuariosBaja_Click(object sender, EventArgs e)
        {
            string dni;

            while (true)
            {
                dni = pedirDNI();
                if (dni == null)
                    return; // cancelado

                Usuario usuario = lnp.GetUsuario(dni);
                if (usuario == null || !usuario.DadoAlta)
                {
                    string mensaje = usuario == null
                        ? $"No existe ningún usuario con el DNI {dni}."
                        : $"El usuario con DNI {dni} ya está dado de baja.";


                    DialogResult dr = MostrarPregunta(
                        mensaje + "\n\n¿Desea introducir otro DNI?",
                        "Usuario no disponible");
                    
                    if (dr == DialogResult.Yes)
                        continue;
                    else
                        return;
                }

                FBajaUsuario formulario = new FBajaUsuario(lnp, usuario);
                formulario.ShowDialog(this);
                return;
            }


        }

        protected virtual void menuDocumentosAlta_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }
        protected virtual void menuEjemplaresAlta_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        private void menuListado_Click(object sender, EventArgs e)
        {
            try
            {
                FListaUsuarios formulario = new FListaUsuarios(lnp);
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al abrir el listado de usuarios: {ex.Message}", "Error");
            }
        }

        private void menuRecorrerUnoAUno_Click(object sender, EventArgs e)
        {
            try
            {
                FUsuariosUnoAUno formulario = new FUsuariosUnoAUno(lnp);
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al abrir el recorrido de usuarios: {ex.Message}", "Error");
            }
        }

        private void busquedaPorDniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FBusquedaUsuarioExtra formulario = new FBusquedaUsuarioExtra(lnp);
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al abrir la búsqueda de usuarios por dni: {ex.Message}", "Error");
            }
        }

        protected virtual void menuDocumentosBaja_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");

        }

        protected virtual void menuEjemplaresBaja_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }
        protected virtual void menuEjemplaresBuscar_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        protected virtual void menuDocumentosListado_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        protected virtual void menuDocumentosRecorrido_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        protected virtual void menuPrestamosRecorrido_Click(object sender, EventArgs e) //falla al entrar
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        protected virtual void menuPrestamosListado_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        protected virtual void menuDocumentosBuscar_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");

        }

        protected virtual void menuEjemplarListado_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }
    }
        
}
