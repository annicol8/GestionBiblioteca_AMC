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
    public partial class FEjemplaresPrestados : FComun
    {
        private string dni;
        private ILNPersonal lnp;

        public FEjemplaresPrestados()
        {
            InitializeComponent();
        }

        //PRE: dni != null y no vacío, lnp != null
        //POST: El formulario queda inicializado con las referencias a dni y lnAdq asignadas
        public FEjemplaresPrestados(string dni, ILNPersonal lnp) : this()
        {
            this.dni = dni;
            this.lnp = lnp;
        }

        //PRE: dni != null y no vacío, lnp != null, el usuario con ese DNI debe existir
        //POST: Se cargan los datos del usuario y sus préstamos activos en el formulario
        //      Si hay un error, se muestra mediante MostrarError y se cierra el formulario
        private void FEjemplaresPrestados_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosUsuario();
                CargarEjemplaresPrestados();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar la información de préstamos:\n{ex.Message}",
                           "Error");
                this.Close();
            }
        }

        //PRE: dni != null y no vacío, lnp != null, el usuario debe existir
        //POST: Se cargan y muestran los datos del usuario
        private void CargarDatosUsuario()
        {
            Usuario usuario = lnp.GetUsuario(dni);

            if (usuario == null)
                throw new InvalidOperationException("El usuario no existe");

            lb_infoUsuario.Text = $"{usuario.Nombre}, {usuario.Dni}";
            Text = $"Ejemplares en préstamos activos - {usuario.Nombre}";
        }

        //PRE:
        //POST: Recargar los datos cada vez que el formulario vuelve a estar activO
        private void FEjemplaresPrestados_Activated(object sender, EventArgs e)
        {
            CargarEjemplaresPrestados();
        }

        //PRE: dni != null y no vacío, lnp != null
        //POST: Se cargan los ejemplares prestados al usuario en el DataGridView
        //      Si no tiene préstamos activos, se muestra un mensaje informativo
        private void CargarEjemplaresPrestados()
        {
            try
            {
                List<Ejemplar> ejemplares = lnp.GetEjemplaresPrestadosPorUsuario(dni);

                dgv_Ejemplares.Rows.Clear();
                dgv_Ejemplares.Columns.Clear();

                DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
                colCodigo.Name = "Codigo";
                colCodigo.HeaderText = "Código Ejemplar";
                colCodigo.Width = 130;
                colCodigo.ReadOnly = true;

                DataGridViewTextBoxColumn colTitulo = new DataGridViewTextBoxColumn();
                colTitulo.Name = "Titulo";
                colTitulo.HeaderText = "Título del Documento";
                colTitulo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colTitulo.ReadOnly = true;

                dgv_Ejemplares.Columns.Add(colCodigo);
                dgv_Ejemplares.Columns.Add(colTitulo);

                if (ejemplares == null || ejemplares.Count == 0)
                {
                    dgv_Ejemplares.Rows.Add("---", "No tiene préstamos activos");
                    dgv_Ejemplares.Rows[0].DefaultCellStyle.ForeColor = Color.Gray;
                    dgv_Ejemplares.Rows[0].DefaultCellStyle.Font = new Font(dgv_Ejemplares.Font, FontStyle.Italic);
                    return;
                }

                foreach (Ejemplar ejemplar in ejemplares)
                {
                    Documento doc = lnp.GetDocumento(ejemplar.IsbnDocumento);
                    string titulo = doc != null ? doc.Titulo : "(Documento no encontrado)";
                    dgv_Ejemplares.Rows.Add(ejemplar.Codigo, titulo);
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar ejemplares: {ex.Message}");
            }
        }

        //PRE: dni y lnp fueron inicializados correctamente
        //POST: Se recargan los ejemplares prestados del usuario
        public void Refrescar()
        {
            CargarEjemplaresPrestados();
        }

    }
}
