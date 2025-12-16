using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FPAdq : FPersonal
    {
        private ILNPAdq lnAdq;
        public FPAdq()
        {
            InitializeComponent();
        }

        public FPAdq(ILNPAdq lnpa): base(lnpa)
        {
            InitializeComponent();
            this.lnAdq = lnpa;
        }

        protected override void menuDocumentosAlta_Click(object sender, EventArgs e)
        {
            string isbn;

            while (true)
            {
                isbn = pedirISBN();

                if (isbn == null)
                    return;

                Documento documentoExistente = lnAdq.getDocumento(isbn);

                if (documentoExistente != null)
                {
                    DialogResult dr = MostrarPregunta(
                        "¿Quieres introducir otro?",
                        "Ya existe un documento con ese ISBN"
                    );
                    if (dr == DialogResult.Yes)
                        continue;
                    else
                        return;
                }

                break;
            }
            FAltaDocumento formulario = new FAltaDocumento(lnAdq, isbn);
            formulario.ShowDialog(this);
        }

        private string pedirISBN()
        {
            FClave fClave = new FClave("ISBN");
            if (fClave.ShowDialog(this) == DialogResult.OK)
            {
                return fClave.Clave;
            }
            return null;
        }


        protected override void menuDocumentosBaja_Click(object sender, EventArgs e)
        {
            string isbn;

            while (true)
            {
                isbn = pedirISBN();
                if (isbn == null)
                    return;

                Documento documentoExistente = lnAdq.getDocumento(isbn);

                if (documentoExistente == null)
                {
                    DialogResult dr = MostrarPregunta(
                        "¿Quieres introducir otro?",
                        "No existe ningún documento con ese ISBN"
                    );

                    if (dr == DialogResult.Yes)
                        continue;
                    else
                        return;
                }
                // Documento encontrado, abrir formulario de baja
                FBajaDocumento formulario = new FBajaDocumento(lnAdq, documentoExistente);
                formulario.ShowDialog(this);
                return;
            }
        }
    }
}
