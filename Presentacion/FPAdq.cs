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
            ConfigurarPermisos();
            ActualizarTituloFormulario();
        }
        private void ConfigurarPermisos()
        {
            OcultarPrestamos();
        }

        protected override void menuDocumentosAlta_Click(object sender, EventArgs e)
        {
            string isbn;

            while (true)
            {
                isbn = pedirClave<string>("ISBN");

                if (isbn == null)
                    return;

                if (!ValidarISBN(isbn))
                {
                    MostrarAdvertencia(
                        "El ISBN introducido no es válido.\n\n" +
                        "Formato: 13 dígitos (ej: 9788420412146 o 978-84-204-1214-6)",
                        "ISBN inválido");
                    continue; //Volver a pedir
                }

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
            try
            {
                FAltaDocumento formulario = new FAltaDocumento(lnAdq, isbn);
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al dar de alta el documento: {ex.Message}", "Error");
            }
        }

        protected override void menuEjemplaresAlta_Click(object sender, EventArgs e)
        {
            int codigo;

            while (true)
            {
                codigo = pedirClave<int>("Código ");

                if (codigo == 0)
                    return; 

                if (codigo < 0)
                {
                    MostrarAdvertencia(
                        "El código debe ser un número entero mayor que 0.\n\n" ,
                        "Código inválido");
                     continue;
                }
               
                Ejemplar ejemplarExistente = lnAdq.GetEjemplar(codigo);

                if (ejemplarExistente != null)
                {
                    if (ejemplarExistente.Activo)
                    {
                        MostrarAdvertencia(
                            $"Ya existe un ejemplar ACTIVO con el código {codigo}.\n\n" ,
                            "Código duplicado");
                    }
                    else
                    {
                        MostrarAdvertencia(
                            $"Ya existe un ejemplar DADO DE BAJA con el código {codigo}.\n\n" 
                            ,"Código duplicado");
                    }

                    DialogResult dr = MostrarPregunta(
                        "¿Desea introducir otro código?",
                        "Ya existe un ejemplar con ese código.");

                    if (dr == DialogResult.Yes)
                        continue;
                    else
                        return;
                }
                break;
            }

            try
            {
                FAltaEjemplar formulario = new FAltaEjemplar(lnAdq, codigo);
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "dar de alta el ejemplar");
            }
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

        protected override void menuDocumentosBuscar_Click(object sender, EventArgs e)
        {

            while (true)
            {
                String isbnBuscado = pedirClave<string>("ISBN");

                if (isbnBuscado != null)
                {

                    Documento documento = lnAdq.getDocumento(isbnBuscado);

                    if (documento == null)
                    {
                        DialogResult dr = MostrarPregunta(
                                "¿Quieres introducir otro?",
                                "No existe ningún documento con ese ISBN"
                            );

                        if (dr == DialogResult.Yes)
                        {
                            continue;
                        }
                        else
                            return;
                    }

                    FBuscarDocumento formulario = new FBuscarDocumento(documento);
                    formulario.ShowDialog(this);
                    return;
                }
                else
                {
                    break;
                }

            }
            

        }


        protected override void menuEjemplaresBaja_Click(object sender, EventArgs e)
        {
            int codigo;

            while (true)
            {
                codigo = pedirClave<int>("Código");

                if (codigo == 0)
                    return;

                Ejemplar ejemplarExistente = lnAdq.GetEjemplar(codigo);

                if (ejemplarExistente == null)
                {
                    DialogResult dr = MostrarPregunta(
                        "¿Desea introducir otro?",
                        "No existe ningún ejemplar con ese código"
                    );

                    if (dr == DialogResult.Yes)
                        continue;
                    else
                        return;
                }

                if (!ejemplarExistente.Activo)
                {
                    MostrarAdvertencia(
                        $"El ejemplar con código {codigo} ya está dado de baja.\n\n" ,
                        "Ejemplar inactivo");

                    DialogResult dr = MostrarPregunta(
                        "¿Desea buscar otro?",
                        "Ejemplar ya dado de baja");

                    if (dr == DialogResult.Yes)
                        continue;
                    else
                        return;
                }

                try
                {
                    // Ejemplar encontrado, abrir formulario de baja
                    FBajaEjemplar formulario = new FBajaEjemplar(lnAdq, ejemplarExistente);
                    formulario.ShowDialog(this);
                }
                catch (Exception ex)
                {
                    ManejarExcepcion(ex, "dar de baja el ejemplar");
                }
                return;
            }
        }

        protected override void menuEjemplaresBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                FBuscarEjemplar formulario = new FBuscarEjemplar(lnAdq);

                if (formulario.ShowDialog(this) == DialogResult.OK)
                {
                    Ejemplar ejemplar = formulario.EjemplarEncontrado;

                    if (ejemplar != null)
                    {
                        // Opcional: Mostrar un mensaje de confirmación con los datos
                        string mensaje = $"Ejemplar encontrado:\n\n" +
                                        $"Código: {ejemplar.Codigo}\n" +
                                        $"ISBN: {ejemplar.IsbnDocumento}\n" +
                                        $"DNI Personal: {ejemplar.DniPAdq}\n" +
                                        $"Estado: {(ejemplar.Activo ? "Activo" : "Inactivo")}";

                        MostrarInformacion(mensaje, "Datos del Ejemplar");
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al buscar el ejemplar: {ex.Message}");
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
