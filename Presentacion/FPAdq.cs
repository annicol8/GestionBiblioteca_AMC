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
            ActualizarTituloFormulario();

        }

        public FPAdq(ILNPAdq lnpa): base(lnpa)
        {
            this.lnAdq = lnpa;
            InitializeComponent();
        }

        protected override void menuDocumentosAlta_Click(object sender, EventArgs e)
        {
            string isbn;

            while (true)
            {
                isbn = pedirClave<string>("ISBN");

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

        protected override void menuEjemplaresAlta_Click(object sender, EventArgs e)
        {
            int codigo;

            while (true)
            {
                codigo = pedirClave<int>("Código del ejemplar");

                if (codigo == 0)
                    return;

                Ejemplar ejemplarExistente = lnAdq.GetEjemplar(codigo);

                if (ejemplarExistente != null)
                {
                    DialogResult dr = MostrarPregunta(
                        "¿Quieres introducir otro?",
                        "Ya existe un ejemplar con ese código"
                    );

                    if (dr == DialogResult.Yes)
                        continue;
                    else
                        return;
                }

                break;
            }

            FAltaEjemplar formulario = new FAltaEjemplar(lnAdq, codigo);
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

        protected override void menuEjemplaresBaja_Click(object sender, EventArgs e)
        {
            int codigo;

            while (true)
            {
                codigo = pedirClave<int>("Código del ejemplar");

                if (codigo == 0)
                    return;

                Ejemplar ejemplarExistente = lnAdq.GetEjemplar(codigo);

                if (ejemplarExistente == null)
                {
                    DialogResult dr = MostrarPregunta(
                        "¿Quieres introducir otro?",
                        "No existe ningún ejemplar con ese código"
                    );

                    if (dr == DialogResult.Yes)
                        continue;
                    else
                        return;
                }

                // Ejemplar encontrado, abrir formulario de baja
                FBajaEjemplar formulario = new FBajaEjemplar(lnAdq, ejemplarExistente);
                formulario.ShowDialog(this);
                return;
            }
        }


        protected override void menuDocumentosListado_Click(object sender, EventArgs e)
        {
            try
            {
                FListaDocumentos formulario = new FListaDocumentos(lnAdq);
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al abrir el listado de documentos: {ex.Message}");
            }
        }

        protected override void menuDocumentosRecorrido_Click(object sender, EventArgs e)
        {
            try
            {
                FDocumentosUnoAUno formulario = new FDocumentosUnoAUno(lnAdq);
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al abrir el recorrido de documentos: {ex.Message}");
            }
        }
    }
}
