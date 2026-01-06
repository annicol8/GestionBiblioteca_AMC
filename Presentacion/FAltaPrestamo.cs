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

        //PRE: 
        //POST: Se inicializa el formulario, la lista de ejemplares y los BindingSource.
        public FAltaPrestamo()
        {
            InitializeComponent();
            codigosEjemplaresAñadidos = new List<int>();

            bindingSourceEjemplares = new BindingSource();
            bindingSourceUsuarios = new BindingSource();
        }

        //PRE: lnSala no debe ser null.
        //POST: Se inicializa el formulario con la lógica de negocio de préstamos.
        public FAltaPrestamo(ILNPSala lnSala) : this()
        {
            this.lnSala = lnSala;
        }

        //PRE: El formulario ha sido creado y lnSala está inicializado.
        //POST: Se cargan los usuarios, la fecha actual, el identificador del préstamo
        //      y se inicializa la lista de ejemplares.
        private void FAltaPrestamo_Load(object sender, EventArgs e)
        {
            try
            {
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

        //PRE: lnSala está inicializado.
        //POST: Se cargan los usuarios activos en el ComboBox.  Si no hay usuarios, se informa al usuario.
        private void CargarUsuarios()
        {
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

        //PRE: El DateTimePicker está inicializado.
        //POST: Se establece la fecha actual como fecha del préstamo.
        private void CargarFechaActual()
        {
            dtpFecha.Value = DateTime.Now;
        }

        //PRE: El TextBox del ID está inicializado.
        //POST: Se muestra que el identificador del préstamo es autogenerado.
        private void GenerarIdPrestamo()
        {
            tbId.Text = "Autogenerado";
            tbId.ReadOnly = true;
        }

        //PRE: lnSala está inicializado y la lista de códigos puede estar vacía.
        //POST: Se actualiza la lista visual de ejemplares añadidos al préstamo.
        private void ActualizarListaEjemplares()
        {
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

        //PRE: El formulario está activo y lnSala está inicializado.
        //POST: Si el usuario selecciona un ejemplar válido, se añade al préstamo
        //      y se actualiza la lista de ejemplares.
        private void btAñadirEjemplar_Click(object sender, EventArgs e)
        {
            try
            {
                FAñadirEjemplarPrestamo formularioAñadir =
                    new FAñadirEjemplarPrestamo(lnSala, codigosEjemplaresAñadidos);

                if (formularioAñadir.ShowDialog(this) == DialogResult.OK)
                {
                    Ejemplar ejemplarSeleccionado = formularioAñadir.EjemplarSeleccionado;

                    if (ejemplarSeleccionado != null)
                    {
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

        //PRE: El código del ejemplar pertenece a la lista de ejemplares añadidos.
        //POST: Si el usuario confirma, el ejemplar se elimina del préstamo
        //      y se actualiza la lista visual.
        private void EliminarEjemplar(int codigoEjemplar)
        {
            if (SolicitarConfirmacion("¿Está seguro de que desea eliminar el ejemplar del préstamo?", "Confirmar eliminación"))
            {
                codigosEjemplaresAñadidos.Remove(codigoEjemplar);
                ActualizarListaEjemplares();
            }
        }

        //PRE: La lista de ejemplares no es null.
        //POST: Se reconstruye el panel visual con los ejemplares actuales del préstamo.
        private void ActualizarPanelEjemplares(List<EjemplarPrestamoInfo> ejemplares)
        {
            panelEjemplares.SuspendLayout();
            panelEjemplares.Controls.Clear();

            int posicionY = 10;

            foreach (EjemplarPrestamoInfo ej in ejemplares)
            {
                // panel para cada ejemplar
                Panel pnlEjemplar = new Panel();
                pnlEjemplar.BorderStyle = BorderStyle.FixedSingle;
                pnlEjemplar.Height = 60;
                pnlEjemplar.Width = panelEjemplares.Width - 20;
                pnlEjemplar.Location = new System.Drawing.Point(5, posicionY);

                // información del ejemplar
                Label lblInfo = new Label();
                lblInfo.Text = $"Código: {ej.Codigo} - {ej.Titulo}";
                lblInfo.AutoSize = false;
                lblInfo.Width = pnlEjemplar.Width - 110;
                lblInfo.Height = 50;
                lblInfo.Location = new System.Drawing.Point(5, 5);
                lblInfo.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

                Button btnEliminar = new Button();
                btnEliminar.Text = "Eliminar";
                btnEliminar.Width = 100;
                btnEliminar.Location = new System.Drawing.Point(pnlEjemplar.Width - 105, 15);
                btnEliminar.Tag = ej.Codigo; 
                btnEliminar.Click += (s, e) => EliminarEjemplar(ej.Codigo);

                pnlEjemplar.Controls.Add(lblInfo);
                pnlEjemplar.Controls.Add(btnEliminar);
                panelEjemplares.Controls.Add(pnlEjemplar);

                posicionY += 70;
            }
            panelEjemplares.ResumeLayout();
        }

        //PRE: El usuario ha seleccionado un usuario válido y ha añadido al menos un ejemplar.
        //POST: Se crea el préstamo con sus ejemplares asociados,
        //      se muestra un mensaje de éxito y se cierra el formulario.
        private void btAceptar_Click(object sender, EventArgs e)
        {
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

                int diasPrestamo = 15;

                foreach (int codigo in codigosEjemplaresAñadidos)
                {
                    Ejemplar ej = lnSala.GetEjemplar(codigo);
                    Documento doc = lnSala.GetDocumento(ej.IsbnDocumento);

                    if (doc is AudioLibro)
                    {
                        diasPrestamo = 10;
                        break;
                    }
                }

                DateTime fechaDevolucion = fechaPrestamo.AddDays(diasPrestamo);
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

                    MostrarExito($"Préstamo creado con éxito.\n");

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



        //PRE: El formulario está abierto.
        //POST: Si el usuario confirma, se cancela el alta del préstamo y se cierra el formulario.
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
