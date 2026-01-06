using System;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FPAdq : FPersonal
    {
        private ILNPAdq lnAdq;

        //PRE:
        //POST: El formulario queda inicializado y con el título actualizado
        public FPAdq() : base()
        {
            ActualizarTituloFormulario();
        }

        //PRE: lnpa != null. El formulario queda inicializado
        //POST: Se asigna la referencia lnAdq
        //      Se configuran los permisos, ocultando el menú de préstamos
        //      El título del formulario se actualiza con los datos del personal
        public FPAdq(ILNPAdq lnpa) : base(lnpa)
        {
            this.lnAdq = lnpa;
            ConfigurarPermisos();
            ActualizarTituloFormulario();
        }

        //PRE: 
        //POST: El menú de préstamos queda oculto
        private void ConfigurarPermisos()
        {
            OcultarPrestamos();
        }

        //PRE: lnAdq != null
        //POST: Se solicita un ISBN válido mediante pedirClave<string>
        //      Si el ISBN ya existe y el usuario no desea introducir otro, no se realiza ninguna acción
        //      Si el ISBN es válido y no existe, se abre FAltaDocumento para dar de alta el documento
        //      Si ocurre un error durante la apertura del formulario, se muestra un mensaje mediante MostrarError
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

                Documento documentoExistente = lnAdq.GetDocumento(isbn);

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

        //PRE: lnAdq != null.Se solicita un código de ejemplar válido mediante pedirClave<int>
        //POST: Si el código ya existe y el usuario no desea introducir otro, no se realiza ninguna acción
        //       Si el código es válido y no existe, se abre FAltaEjemplar para dar de alta el ejemplar
        //       Si ocurre un error durante la apertura del formulario, se muestra un mensaje mediante ManejarExcepcion
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
                        "El código debe ser un número entero mayor que 0.\n\n",
                        "Código inválido");
                    continue;
                }

                Ejemplar ejemplarExistente = lnAdq.GetEjemplar(codigo);

                if (ejemplarExistente != null)
                {
                    if (ejemplarExistente.Activo)
                    {
                        MostrarAdvertencia(
                            $"Ya existe un ejemplar ACTIVO con el código {codigo}.\n\n",
                            "Código duplicado");
                    }
                    else
                    {
                        MostrarAdvertencia(
                            $"Ya existe un ejemplar DADO DE BAJA con el código {codigo}.\n\n"
                            , "Código duplicado");
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

        //PRE: lnAdq != null. Se solicita un ISBN mediante pedirClave<string>
        //POST: Si el documento no existe y el usuario no desea introducir otro, no se realiza ninguna acción
        //       Si el documento existe, se abre FBajaDocumento para procesar la baja
        //       Si ocurre un error durante la apertura del formulario, se muestra un mensaje mediante MostrarError
        protected override void menuDocumentosBaja_Click(object sender, EventArgs e)
        {
            string isbn;

            while (true)
            {
                isbn = pedirClave<String>("ISBN");
                if (isbn == null)
                    return;

                Documento documentoExistente = lnAdq.GetDocumento(isbn);

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

        //PRE: lnAdq != null
        //POST: Se solicita un ISBN mediante pedirClave<string>
        //       Si el documento no existe y el usuario no desea introducir otro, no se realiza ninguna acción
        //       Si el documento existe, se abre FBuscarDocumento para mostrar sus datos
        //       Si ocurre un error durante la apertura del formulario, se muestra un mensaje mediante MostrarError
        protected override void menuDocumentosBuscar_Click(object sender, EventArgs e)
        {

            while (true)
            {
                String isbnBuscado = pedirClave<string>("ISBN");

                if (isbnBuscado != null)
                {

                    Documento documento = lnAdq.GetDocumento(isbnBuscado);

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

        //PRE: lnAdq != null. Se solicita un código de ejemplar mediante pedirClave<int>
        //POST: Si el ejemplar no existe o está dado de baja y el usuario no desea introducir otro, no se realiza ninguna acción
        //      Si el ejemplar existe y está activo, se abre FBajaEjemplar para procesar la baja
        //      Si ocurre un error durante la apertura del formulario, se muestra un mensaje mediante ManejarExcepcion
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
                        $"El ejemplar con código {codigo} ya está dado de baja.\n\n",
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

        //PRE: lnAdq != null
        //POST: Se abre FBuscarEjemplar para buscar un ejemplar
        //       Si se encuentra un ejemplar, se muestra su información mediante MostrarInformacion
        //       Si ocurre un error durante la búsqueda, se muestra un mensaje mediante MostrarError
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

        //PRE: lnAdq != null
        //POST: Se abre FListaEjemplar para mostrar todos los ejemplares
        //       Si ocurre un error durante la apertura del formulario, se maneja mediante ManejarExcepcion
        protected override void menuEjemplarListado_Click(object sender, EventArgs e)
        {
            try
            {
                FListaEjemplar formulario = new FListaEjemplar(lnAdq);
                formulario.Show();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "abrir listado de ejemplares");
            }
        }

        //PRE: lnAdq != null
        //POST: Se abre FListaDocumentos para mostrar todos los documentos
        //      Si ocurre un error durante la apertura del formulario, se muestra un mensaje mediante MostrarError
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

        //PRE: lnAdq != null
        //POST: Se abre FDocumentosUnoAUno para recorrer los documentos uno a uno
        //      Si ocurre un error durante la apertura del formulario, se muestra un mensaje mediante MostrarError
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

        //PRE: lnAdq != null
        //POST: Se solicita un ISBN mediante pedirClave<string>
        //      Si el ISBN es válido y el documento existe, se abre FEjemplaresDisponibles
        //      Si el documento no existe, se pregunta si desea introducir otro ISBN
        //      Si ocurre un error, se muestra mediante ManejarExcepcion
        protected override void ejemplaresDisponiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string isbn;

            while (true)
            {
                isbn = pedirClave<string>("ISBN");

                if (isbn == null)
                    return;

                Documento documento = lnAdq.GetDocumento(isbn);

                if (documento == null)
                {
                    DialogResult dr = MostrarPregunta(
                        $"No existe ningún documento con el ISBN {isbn}.\n\n" +
                        "¿Desea introducir otro ISBN?",
                        "Documento no encontrado");

                    if (dr == DialogResult.Yes)
                        continue;
                    else
                        return;
                }

                try
                {
                    FEjemplaresDisponibles formulario = new FEjemplaresDisponibles(isbn, lnAdq);
                    formulario.ShowDialog(this);
                }
                catch (Exception ex)
                {
                    ManejarExcepcion(ex, "consultar la disponibilidad de ejemplares");
                }

                return;
            }
        }


        //PRE: lnAdq != null
        //POST: Se abre FDocumentoMasPrestado mostrando el documento más prestado del último mes
        //      Si ocurre un error, se muestra mediante ManejarExcepcion
        protected override void documentoMásPrestadoDelÚltimoMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FDocumentoMasPrestado formulario = new FDocumentoMasPrestado(lnAdq);
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "consultar el documento más prestado");
            }
        }
    }
}
