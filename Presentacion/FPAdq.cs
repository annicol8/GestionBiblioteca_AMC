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


        private T pedirClave<T>(string mensaje)
        {
            while (true)
            {
                FClave fClave = new FClave(mensaje);

                if (fClave.ShowDialog(this) != DialogResult.OK)
                    return default; // cancelado

                string texto = fClave.Clave;

                try
                {
                    return (T)Convert.ChangeType(texto, typeof(T));
                }
                catch
                {
                    MessageBox.Show(
                        $"El valor introducido no es un {typeof(T).Name} válido",
                        "Valor incorrecto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }


        /*  LO VOY A HACER GENÉRICO: ejemplar tiene código que es int
         * private string pedirISBN()
        {
            FClave fClave = new FClave("ISBN");
            if (fClave.ShowDialog(this) == DialogResult.OK)
            {
                return fClave.Clave;
            }
            return null;
        }*/
    }
}
