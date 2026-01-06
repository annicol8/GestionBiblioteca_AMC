using System;
using System.Linq;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FPersonal : FComun
    {
        protected ILNPersonal lnp;

        //POST: El formulario queda inicializado
        //POST: Controles y componentes cargados
        public FPersonal()
        {
            InitializeComponent();
        }

        //PRE: lnp != null
        //POST: El formulario queda inicializado. Se asigna la referencia a lnp
        public FPersonal(ILNPersonal lnp) : this()
        {
            this.lnp = lnp;
        }

        //PRE: 
        //POST: Si lnp.Personal != null, el título del formulario se actualiza con el nombre y tipo del personal
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

        //PRE: Los ToolStripMenuItems existen en el formulario
        //POST: El elemento correspondiente queda invisible
        protected void OcultarDocumentos()
        {
            documentosToolStripMenuItem.Visible = false;
        }

        //PRE: Los ToolStripMenuItems existen en el formulario
        //POST: El elemento correspondiente queda invisible
        protected void OcultarEjemplares()
        {
            ejemplaresToolStripMenuItem.Visible = false;
        }

        //PRE: Los ToolStripMenuItems existen en el formulario
        //POST: El elemento correspondiente queda invisible
        protected void OcultarPrestamos()
        {
            prestamosToolStripMenuItem.Visible = false;
        }

        //PRE: lnp != null
        //POST: Se solicita un DNI válido mediante diálogo
        //      Si se introduce un DNI válido y no existe usuario activo, se abre FAltaUsuario
        //      Si se cancela o no se puede crear, no se realiza ninguna acción
        private void menuUsuariosAlta_Click(object sender, EventArgs e)
        {
            string dni;

            while (true)
            {
                dni = pedirDNI();

                if (dni == null)
                    return; 

                if (!ValidarDNI(dni))
                {
                    MostrarAdvertencia(
                        "El DNI introducido no tiene un formato válido.\n\n" +
                        "Formato correcto: 8 dígitos seguidos de una letra (ej: 12345678Z)",
                        "DNI inválido");
                    continue; 
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

        //PRE: 
        //POST: Se muestra un diálogo para introducir el DNI
        //      Devuelve un DNI válido en mayúsculas o null si se cancela
        private string pedirDNI()
        {
            FClave fClave = new FClave("DNI");

            if (fClave.ShowDialog(this) == DialogResult.OK)

            {
                return fClave.Clave?.Trim().ToUpper();

            }
            return null;
        }

        //PRE: lnp != null
        //POST: Se solicita un DNI mediante diálogo. Si el usuario existe, se abre FBuscarUsuario
        //      Si no existe o está dado de baja y el usuario decide no continuar, no se realiza ninguna acción
        private void menuUsuariosBuscar_Click(object sender, EventArgs e)
        {
            string dni;
            while (true)
            {
                dni = pedirDNI();
                if (dni == null)
                    return; 

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

        //PRE: lnp != null
        //POST: Se solicita un DNI mediante diálogo. Si el usuario existe y está activo, se abre FBajaUsuario
        //      Si se cancela o no se puede dar de baja, no se realiza ninguna acción
        private void menuUsuariosBaja_Click(object sender, EventArgs e)
        {
            string dni;

            while (true)
            {
                dni = pedirDNI();
                if (dni == null)
                    return; 

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

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuDocumentosAlta_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuEjemplaresAlta_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: lnp != null
        //POST: Se abre el formulario FListaUsuarios mostrando todos los usuarios
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

        //PRE: lnp != null
        //POST: Se abre el formulario FUsuariosUnoAUno mostrando el recorrido de usuarios
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

        //PRE: lnp != null
        //POST: Se abre el formulario FBusquedaUsuarioExtra para buscar usuarios por DNI
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

        private void ejempToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dni;
            while (true)
            {
                dni = pedirClave<string>("DNI");
                if (dni == null)
                    return;

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

                try
                {
                    FEjemplaresPrestados formulario = new FEjemplaresPrestados(dni, lnp);
                    formulario.ShowDialog(this);
                }
                catch (Exception ex)
                {
                    ManejarExcepcion(ex, "consultar los ejemplares prestados del usuario");
                }
                return;
            }
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuDocumentosBaja_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");

        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuEjemplaresBaja_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuEjemplaresBuscar_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuDocumentosListado_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuDocumentosRecorrido_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuPrestamosRecorrido_Click(object sender, EventArgs e) //falla al entrar
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuPrestamosListado_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuDocumentosBuscar_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");

        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuEjemplarListado_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuPrestamosNuevo_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuPrestamosDevolver_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void menuPrestamosBuscar_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void ejemplaresDisponiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void documentoMásPrestadoDelÚltimoMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void prestamosPorDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE: 
        //POST: Se muestra mensaje de "Funcionalidad no implementada aún"
        protected virtual void préstamosFueraDePlazoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarInformacion("Funcionalidad no implementada aún", "Atención");
        }

        //PRE:
        //POST: se cierra la sesión y se vuelve al formulario login de inicio en caso de confirmación, si no se cierra el aviso y se continua donde estaba 
        private void volverALoguinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SolicitarConfirmacion("¿Desea cerrar la sesión y volver al login?"))
                return;

            this.Hide();

            using (FLogin login = new FLogin())
            {
                login.ShowDialog();
            }
            this.Close();
        }



        //PRE: lnp != null
        //POST: Se solicita un DNI válido mediante diálogo
        //      Si se introduce un DNI válido y no existe personal activo, se abre FAltaPersonal
        //      Si se cancela o no se puede crear, no se realiza ninguna acción
        private void altaPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dni = pedirClave<string>("DNI");

            if (string.IsNullOrWhiteSpace(dni))
                return;

            if (!ValidarDNI(dni))
            {
                MostrarAdvertencia("El DNI introducido no es válido");
                return;
            }

            using (FAltaPersonal fAlta = new FAltaPersonal(lnp, dni))
            {
                if (fAlta.ShowDialog() == DialogResult.OK)
                {
                    MostrarExito("Personal dado de alta correctamente");
                }
            }
        }
    }
}

