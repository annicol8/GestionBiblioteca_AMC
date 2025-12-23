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
            textBoxCodigoEj.Text = codigo.ToString();
            textBoxCodigoEj.ReadOnly = true;

            textBox_Personal.Text = lnAdq.Personal.Nombre; 
            CargarDocumentos();
            
            
        }
        
        private void CargarDocumentos()
        {
            try
            {
                List<Documento> documentos = lnAdq.getDocumentos();

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
            this.Close();
        }

        
    }

}
