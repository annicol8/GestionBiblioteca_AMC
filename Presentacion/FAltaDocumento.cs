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

namespace Presentacion
{
    public partial class FAltaDocumento : FComun
    {
        private ILNPAdq lnAdq;
        private string isbn;

        public FAltaDocumento()
        {
            InitializeComponent();
        }

        public FAltaDocumento(ILNPAdq lnAdq, string isbn) : this()
        {
            this.lnAdq = lnAdq;
            this.isbn = isbn;
        }

        private void FAltaDocumento_Load(object sender, EventArgs e)
        {
            tbIsbn.Text = isbn;
            tbIsbn.ReadOnly = true;

            OcultarCamposAudioLibro();

        }


        private void rbLibro_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLibro.Checked)
            {
                OcultarCamposAudioLibro();
            }
        }

        private void rbAudioLibro_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAudioLibro.Checked)
            {
                MostrarCamposAudioLibro();
            }
        }

        private void MostrarCamposAudioLibro()
        {
            lbFormatoDigital.Visible = true;
            tbFormatoDigital.Visible = true;
            lbDuracion.Visible = true;
            tbDuracion.Visible = true;
            gbAudioLibro.Visible = true;
        }


        private void OcultarCamposAudioLibro()
        {
            lbFormatoDigital.Visible = false;
            tbFormatoDigital.Visible = false;
            lbDuracion.Visible = false;
            tbDuracion.Visible = false;
            gbAudioLibro.Visible = false;
        }


    }
}