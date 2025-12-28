using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;


namespace Presentacion
{
    public partial class FAltaPrestamo : FComun
    {
        private ILNPSala lnSala;
        private List<int> codigosEjemplaresAñadidos;  // Códigos de ejemplares seleccionados
        private BindingSource bindingSourceEjemplares;
        private BindingSource bindingSourceUsuarios;


        public FAltaPrestamo()
        {
            InitializeComponent();
            codigosEjemplaresAñadidos = new List<int>();

            bindingSourceEjemplares = new BindingSource();
            bindingSourceUsuarios = new BindingSource();
        }

        public FAltaPrestamo(ILNPSala lnSala) : this()
        {
            this.lnSala = lnSala;
        }

        private void FAltaPrestamo_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar datos iniciales
                CargarUsuarios();
                CargarFechaActual();
                GenerarIdPrestamo();

                ActualizarListaEjemplares();

            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "inicializar el formulario");
                this.Close();
            }
        }

        private void CargarUsuarios()
        {
            /*
            try
            {

                var usuarios = lnSala.GetUsuariosActivos();

                if (usuarios == null || usuarios.Count == 0)
                {
                    MessageBox.Show("No hay usuarios activos en el sistema.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                bindingSourceUsuarios = new BindingSource();
                bindingSourceUsuarios.DataSource = usuarios;

                cbUsuarios.DataSource = bindingSourceUsuarios;
                cbUsuarios.DisplayMember = "Dni";
                cbUsuarios.ValueMember = "Dni";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message} \n {ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

            try
            {
                var usuarios = lnSala.GetUsuariosActivos();

                if (usuarios == null || usuarios.Count == 0)
                {
                    MostrarInformacion("No hay usuarios activos en el sistema.");
                    return;
                }

                bindingSourceUsuarios.DataSource = usuarios;
                cbUsuarios.DataSource = bindingSourceUsuarios;
                cbUsuarios.DisplayMember = "Dni";
                cbUsuarios.ValueMember = "Dni";
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "cargar usuarios");
            }
        }


        private void CargarFechaActual()
        {
            dtpFecha.Value = DateTime.Now;
        }

        private void GenerarIdPrestamo()
        {
            // Si el ID es autogenerado en BD, puedes dejar esto vacío o mostrar "Autogenerado"
            tbId.Text = "Autogenerado";
            tbId.ReadOnly = true;
        }

        private void ActualizarListaEjemplares()
        {
            /*
            List<EjemplarPrestamoInfo> ejemplaresInfo = new List<EjemplarPrestamoInfo>();

            // Obtener información de cada ejemplar añadido
            foreach (int codigoEjemplar in codigosEjemplaresAñadidos)
            {
                //Ejemplar ej = Persistencia.Persistencia.GetEjemplar(new Ejemplar(codigoEjemplar)); // ESTO ESTÁ MAL. HAY QUE HACER UN MÉTODO EN LOGICA NEGOCIO

                Ejemplar ej = lnSala.GetEjemplar(codigoEjemplar);
                if (ej != null)
                {
                    Documento doc = lnSala.GetDocumento(ej.IsbnDocumento);
                    ejemplaresInfo.Add(new EjemplarPrestamoInfo
                    {
                        Codigo = ej.Codigo,
                        Titulo = doc?.Titulo ?? "Documento sin título",
                        Isbn = ej.IsbnDocumento,
                        Estado = "No devuelto"
                    });
                }
            }

            bindingSourceEjemplares.DataSource = ejemplaresInfo;
            ActualizarPanelEjemplares(ejemplaresInfo);
            */

            List<EjemplarPrestamoInfo> ejemplaresInfo = new List<EjemplarPrestamoInfo>();

            foreach (int codigoEjemplar in codigosEjemplaresAñadidos)
            {
                Ejemplar ej = lnSala.GetEjemplar(codigoEjemplar);
                if (ej != null)
                {
                    Documento doc = lnSala.GetDocumento(ej.IsbnDocumento);
                    ejemplaresInfo.Add(new EjemplarPrestamoInfo
                    {
                        Codigo = ej.Codigo,
                        Titulo = doc?.Titulo ?? "Documento sin título",
                        Isbn = ej.IsbnDocumento,
                        Estado = "No devuelto"
                    });
                }
            }

            bindingSourceEjemplares.DataSource = ejemplaresInfo;
            bindingSourceEjemplares.ResetBindings(false);

            ActualizarPanelEjemplares(ejemplaresInfo);
        }

        private void btAñadirEjemplar_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                FAñadirEjemplarPrestamo formularioAñadir =
                    new FAñadirEjemplarPrestamo(lnSala, codigosEjemplaresAñadidos);

                if (formularioAñadir.ShowDialog(this) == DialogResult.OK)
                {
                    // PASO 3.7: Ejemplar fue seleccionado
                    Ejemplar ejemplarSeleccionado = formularioAñadir.EjemplarSeleccionado;
                    if (ejemplarSeleccionado != null)
                    {
                        // Añadir a la lista si no estaba ya
                        if (!codigosEjemplaresAñadidos.Contains(ejemplarSeleccionado.Codigo))
                        {
                            codigosEjemplaresAñadidos.Add(ejemplarSeleccionado.Codigo);
                            ActualizarListaEjemplares();
                        }
                        else
                        {
                            MessageBox.Show("Este ejemplar ya ha sido añadido al préstamo",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

            try
            {
                FAñadirEjemplarPrestamo formularioAñadir =
                    new FAñadirEjemplarPrestamo(lnSala, codigosEjemplaresAñadidos);

                if (formularioAñadir.ShowDialog(this) == DialogResult.OK)
                {
                    Ejemplar ejemplarSeleccionado = formularioAñadir.EjemplarSeleccionado;

                    if (ejemplarSeleccionado != null)
                    {
                        // Validar que no está duplicado y que esta disponible antes de añadirlo al prestamo
                        if (codigosEjemplaresAñadidos.Contains(ejemplarSeleccionado.Codigo))
                        {
                            MostrarInformacion("Este ejemplar ya ha sido añadido al préstamo.");
                            return;
                        }

                        if (!lnSala.EjemplarDisponibleParaPrestamo(ejemplarSeleccionado.Codigo))
                        {
                            MostrarError("El ejemplar ya no está disponible.");
                            return;
                        }

                        codigosEjemplaresAñadidos.Add(ejemplarSeleccionado.Codigo);
                        ActualizarListaEjemplares();

                        MostrarExito("Ejemplar añadido correctamente.", "Éxito");
                    }
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "añadir ejemplar");
            }

        }

        // PASO 3.8: Eliminar un ejemplar de la lista
        private void EliminarEjemplar(int codigoEjemplar)
        {
            /*
            codigosEjemplaresAñadidos.Remove(codigoEjemplar);
            ActualizarListaEjemplares();
            */

            if (SolicitarConfirmacion("¿Está seguro de que desea eliminar el ejemplar del préstamo?", "Confirmar eliminación"))
            {
                codigosEjemplaresAñadidos.Remove(codigoEjemplar);
                ActualizarListaEjemplares();
            }
        }




        private void ActualizarPanelEjemplares(List<EjemplarPrestamoInfo> ejemplares)
        {
            panelEjemplares.SuspendLayout();
            panelEjemplares.Controls.Clear();

            int posicionY = 10;

            foreach (EjemplarPrestamoInfo ej in ejemplares)
            {
                // Crear panel para cada ejemplar
                Panel pnlEjemplar = new Panel();
                pnlEjemplar.BorderStyle = BorderStyle.FixedSingle;
                pnlEjemplar.Height = 60;
                pnlEjemplar.Width = panelEjemplares.Width - 20;
                pnlEjemplar.Location = new System.Drawing.Point(5, posicionY);

                // Label con información del ejemplar
                Label lblInfo = new Label();
                lblInfo.Text = $"Código: {ej.Codigo} - {ej.Titulo}";
                lblInfo.AutoSize = false;
                lblInfo.Width = pnlEjemplar.Width - 110;
                lblInfo.Height = 50;
                lblInfo.Location = new System.Drawing.Point(5, 5);
                lblInfo.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

                // Botón eliminar
                Button btnEliminar = new Button();
                btnEliminar.Text = "Eliminar";
                btnEliminar.Width = 100;
                btnEliminar.Location = new System.Drawing.Point(pnlEjemplar.Width - 105, 15);
                btnEliminar.Tag = ej.Codigo;  // Guardar código para identificar qué eliminar
                btnEliminar.Click += (s, e) => EliminarEjemplar(ej.Codigo);

                pnlEjemplar.Controls.Add(lblInfo);
                pnlEjemplar.Controls.Add(btnEliminar);
                panelEjemplares.Controls.Add(pnlEjemplar);

                posicionY += 70;
            }
            panelEjemplares.ResumeLayout();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(cbUsuarios.Text))
                {
                    MessageBox.Show("Debe seleccionar un usuario", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (codigosEjemplaresAñadidos.Count == 0)
                {
                    MessageBox.Show("Debe añadir al menos un ejemplar", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear objeto Préstamo
                string dniUsuario = cbUsuarios.SelectedValue.ToString();
                DateTime fechaPrestamo = dtpFecha.Value;
                DateTime fechaDevolucion = fechaPrestamo.AddDays(15);  // 15 días por defecto

                Prestamo prestamo = new Prestamo(
                    0,  // ID será autogenerado
                    fechaPrestamo,
                    fechaDevolucion,
                    EstadoPrestamo.enProceso,
                    lnSala.Personal.Dni,  // DNI del personal logueado
                    dniUsuario
                );

                // PASO 3.10: Llamar a LN para crear préstamo completo
                int idPrestamoCreado = lnSala.CrearPrestamoCompleto(prestamo, codigosEjemplaresAñadidos);

                MessageBox.Show($"Préstamo creado exitosamente. ID: {idPrestamoCreado}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el préstamo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

            try
            {
                if (!ValidarSeleccionComboBox(cbUsuarios, "Usuario"))
                    return;

                if (codigosEjemplaresAñadidos.Count == 0)
                {
                    MostrarAdvertencia("Debe añadir al menos un ejemplar al préstamo.", "Validación");
                    return;
                }


                // Crear objeto Préstamo
                string dniUsuario = cbUsuarios.SelectedValue.ToString();

                if (!lnSala.PuedeRealizarPrestamo(dniUsuario))
                {
                    MostrarAdvertencia(
                        "El usuario no puede realizar préstamos.\n" +
                        "Puede tener documentos fuera de plazo o estar inactivo.",
                        "Usuario no válido");
                    return;
                }
                
                DateTime fechaPrestamo = dtpFecha.Value;
                DateTime fechaDevolucion = fechaPrestamo.AddDays(15);  // 15 días por defecto
                Prestamo prestamo = new Prestamo(
                    0,
                    fechaPrestamo,
                    fechaDevolucion,
                    EstadoPrestamo.enProceso,
                    lnSala.Personal.Dni,
                    dniUsuario
                );
                EstablecerEstadoControles(false, btAceptar, btCancelar, btAñadirEjemplar);
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    int idPrestamoCreado = lnSala.CrearPrestamoCompleto(prestamo, codigosEjemplaresAñadidos);

                    MostrarExito(  $"Préstamo creado con éxito.\n");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                finally
                {
                    // Re-habilitar controles en caso de error
                    EstablecerEstadoControles(true, btAceptar, btCancelar, btAñadirEjemplar);
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "crear el préstamo");
            }

        }
        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            if (codigosEjemplaresAñadidos.Count > 0)
            {
                if (!SolicitarConfirmacion(
                    "¿Está seguro de que desea cancelar?\nSe perderán los datos introducidos.",
                    "Confirmar cancelación"))
                {
                    return;
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }

}
