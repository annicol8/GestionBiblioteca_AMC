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
        public FAltaEjemplar()
        {
            InitializeComponent();
        }

        public FAltaEjemplar(ILNPAdq lnAdq, int codigo) : this()
        {
            this.lnAdq = lnAdq;
            this.codigo = codigo;
        }

        public FAltaEjemplar(ILNPAdq lnAdq, int codigo, string isbnFijo): this(lnAdq, codigo)
        {
            this.isbn = isbnFijo;
        }
        
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

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }

}
