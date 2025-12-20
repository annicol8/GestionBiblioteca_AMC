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

            CargarDocumentos();
        }
        
        private void CargarDocumentos()
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

        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            string isbn = comboBoxISBN.Text;

            lnAdq.AltaEjemplar(codigo, isbn);

            MostrarExito("Ejemplar dado de alta correctamente");
            this.Close();
            
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
