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
    public partial class FAltaEjemplar : FComun
    {

        private ILNPAdq lnAdq;
        private int codigo;
        private string isbn;

        //PRE: 
        //POST: Se inicializa el formulario de alta de ejemplares.
        public FAltaEjemplar()
        {
            InitializeComponent();
        }

        //PRE: lnAdq no debe ser null y codigo debe ser un valor positivo.
        //POST: Se inicializa el formulario con la lógica de negocio y el código del ejemplar.
        public FAltaEjemplar(ILNPAdq lnAdq, int codigo) : this()
        {
            this.lnAdq = lnAdq;
            this.codigo = codigo;
        }

        //PRE: lnAdq no debe ser null, codigo debe ser positivo e isbnFijo no debe ser null.
        //POST: Se inicializa el formulario con un ISBN fijo que no podrá modificarse.
        public FAltaEjemplar(ILNPAdq lnAdq, int codigo, string isbnFijo): this(lnAdq, codigo)
        {
            this.isbn = isbnFijo;
        }

        //PRE: El formulario ha sido creado y lnAdq está correctamente inicializado.
        //POST: Se muestra el código del ejemplar, el personal logueado y se cargan los documentos.
        //      Si el ejemplar ya existe o ocurre un error, se muestra un mensaje y se cierra el formulario.
        private void FAltaEjemplar_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxCodigoEj.Text = codigo.ToString();
                textBoxCodigoEj.ReadOnly = true;

                textBox_Personal.Text = $"{lnAdq.Personal.Dni} - {lnAdq.Personal.Nombre}";

                Ejemplar ejemplarExistente = lnAdq.GetEjemplar(codigo);
                if (ejemplarExistente != null)
                {
                    MostrarError(
                        $"Ya existe un ejemplar con el código {codigo}.\n" +
                        "No se puede continuar con el alta.",
                        "Error");
                    this.Close();
                    return;
                }

                CargarDocumentos();
            } catch (Exception ex)
            {
                ManejarExcepcion(ex, "cargar el formulario");
                this.Close();
            } 
        }

        //PRE: lnAdq está inicializado y existen documentos en el sistema.
        //POST: Se cargan los ISBN disponibles en el ComboBox.
        //      Si hay un ISBN fijo, se selecciona y se bloquea la selección.
        //      Si no hay documentos, se muestra una advertencia y se cierra el formulario.
        private void CargarDocumentos()
        {
            try
            {
                List<Documento> documentos = lnAdq.getDocumentos();
                 
                if (documentos == null || documentos.Count == 0)
                {
                    MostrarAdvertencia(
                        "No hay documentos disponibles en el sistema.\n" +
                        "Debe dar de alta al menos un documento antes de crear ejemplares.",
                        "Sin documentos");
                    this.Close();
                    return;
                }

                comboBoxISBN.Items.Clear();

                foreach (Documento documento in documentos)
                {
                    this.comboBoxISBN.Items.Add(documento.Isbn);
                }

                if (!string.IsNullOrEmpty(this.isbn))
                {
                    int index = comboBoxISBN.Items.IndexOf(this.isbn);
                    if (index >= 0)
                    {
                        comboBoxISBN.SelectedIndex = index;
                        comboBoxISBN.Enabled = false;
                    }
                    else
                    {
                        MostrarAdvertencia(
                            $"El documento con ISBN {this.isbn} no existe en el sistema.",
                            "Documento no encontrado");
                    }
                }
            } catch (Exception ex)
            {
                ManejarExcepcion(ex, "cargar los documentos");
            }
        }


        //PRE: El usuario ha seleccionado un documento y pulsa Aceptar.
        //POST: Si los datos son válidos, se da de alta el ejemplar,
        //      se muestra un mensaje de éxito y se cierra el formulario. En caso de error, se muestra el mensaje correspondiente.
        private void botonAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            try
            {
                string isbn = comboBoxISBN.Text;

                // El personal que da de alta es el que está logueado
                string dniPersonal = lnAdq.Personal.Dni;

                lnAdq.AltaEjemplar(codigo, isbn);

                MostrarExito("Ejemplar dado de alta correctamente");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "dar de alta el ejemplar");
            }
        }

        //PRE: El usuario intenta confirmar el alta del ejemplar.
        //POST: Devuelve true si se ha seleccionado un documento válido;
        //      en caso contrario, muestra un error y devuelve false.
        private bool ValidarDatos()
        {
            if (comboBoxISBN.SelectedIndex < 0)
            {
                MostrarError("Debes seleccionar un documento");
                comboBoxISBN.Focus();
                return false;
            }

            return true;
        }

        //PRE: El formulario está abierto y el usuario pulsa Cancelar.
        //POST: Se cierra el formulario devolviendo DialogResult.Cancel.
        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }

}
