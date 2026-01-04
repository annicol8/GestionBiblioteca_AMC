using System;
using System.Windows.Forms;
using LogicaNegocio;
using ModeloDominio;

namespace Presentacion
{
    public partial class FPSala : FPersonal
    {
        private ILNPSala lnSala;

        //POST: El formulario queda inicializado
        //POST: Se actualiza el título del formulario con los datos del personal
        public FPSala(): base()
        {
            ActualizarTituloFormulario();
        }

        //PRE: lnSala != null
        //POST: El formulario queda inicializado. Se asigna la referencia lnSala
        //      Se actualiza el título del formulario con los datos del personal y se configuran los permisos, ocultando menús de documentos y ejemplares
        public FPSala(ILNPSala lnSala) : base(lnSala)
        {
            this.lnSala = lnSala;
            ActualizarTituloFormulario();
            ConfigurarPermisos();
        }

        //PRE:
        //POST: Se ocultan los menús de documentos y ejemplares
        private void ConfigurarPermisos()
        {
            OcultarDocumentos();
            OcultarEjemplares();
        }

        //PRE: lnSala != null
        //POST: Se abre el formulario FPrestamosUnoAUno mostrando los préstamos uno a uno
        //      Si ocurre un error, se muestra un mensaje mediante MostrarError
        protected override void menuPrestamosRecorrido_Click(object sender, EventArgs e)
        {
            try
            {
                FPrestamosUnoAUno formulario = new FPrestamosUnoAUno(lnSala);
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al abrir préstamos: {ex.Message}");
            }
        }

        //PRE: lnSala != null
        //POST: Se abre el formulario FListaPrestamos mostrando el listado de préstamos
        //      Si ocurre un error, se muestra un mensaje mediante MostrarError
        protected override void menuPrestamosListado_Click(object sender, EventArgs e)
        {
            try
            {
                FListaPrestamos formulario = new FListaPrestamos(lnSala);
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al abrir el listado de préstamos: {ex.Message}");
            }
        }

        //PRE: lnSala != null
        //POST: Se abre el formulario FAltaPrestamo para dar de alta un nuevo préstamo
        //      Si ocurre un error, se muestra un mensaje mediante MostrarError
        protected override void menuPrestamosNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                FAltaPrestamo formulario = new FAltaPrestamo(lnSala);
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al abrir el alta de préstamos: {ex.Message}");
            }
        } 


        //PRE: lnSala != null. Se solicita un identificador de préstamo válido mediante pedirClave<int>
        //POST: Si el préstamo no existe, se muestra un error y no se hace nada
        //      Si el préstamo ya está finalizado, se muestra un error y no se hace nada
        //      Si el préstamo es válido, se abre FDevolverPrestamo para procesar la devolución
        protected override void menuPrestamosDevolver_Click(object sender, EventArgs e)
        {
            int idPrestamo = pedirClave<int>("Identificador ");
            if (idPrestamo == 0) return;

            Prestamo prestamo = lnSala.GetPrestamo(idPrestamo);

            if (prestamo == null)
            {
                MostrarError("No existe ningún préstamo con ese identificador");
                return;
            }

            if (prestamo.Estado == EstadoPrestamo.finalizado)
            {
                MostrarError("Este préstamo no tiene ejemplares pendientes de devolver");
                return;
            }

            FDevolverPrestamo formulario = new FDevolverPrestamo(lnSala, prestamo);
            formulario.ShowDialog(this);
        }

        //PRE: lnSala != null. Se solicita un identificador de préstamo válido mediante pedirClave<int>
        //POST: Si el préstamo no existe, se muestra un error y no se hace nada
        //      Si el préstamo existe, se abre FBuscarPrestamo para mostrar sus datos
        protected override void menuPrestamosBuscar_Click(object sender, EventArgs e)
        {
            int idPrestamo = pedirClave<int>("Identificador ");
            if (idPrestamo == 0) return;

            Prestamo prestamo = lnSala.GetPrestamo(idPrestamo);

            if (prestamo == null)
            {
                MostrarError("No existe ningún préstamo con ese identificador");
                return;
            }


            FBuscarPrestamo formulario = new FBuscarPrestamo(lnSala, prestamo);
            formulario.ShowDialog(this);
        }

    }
}
