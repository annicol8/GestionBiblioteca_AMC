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
    public partial class FPSala : FPersonal
    {
        private ILNPSala lnSala;

        public FPSala(ILNPSala lnSala) : base(lnSala)
        {
            this.lnSala = lnSala;
            InitializeComponent();
            ActualizarTituloFormulario();
            ConfigurarPermisos();
        }

        private void ConfigurarPermisos()
        {
            
            OcultarDocumentos();
            OcultarEjemplares();
        }

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


    }
}
