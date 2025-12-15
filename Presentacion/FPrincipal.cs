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
    public partial class FPrincipal : FComun
    {
        /*private Personal personal;
        private Personal Personal
        {
            get { return personal; }
            set { personal = value; }
        }*/

        protected ILNPersonal lnp;
        
        public FPrincipal()
        {
            InitializeComponent();
        }

        public FPrincipal(ILNPersonal lnp) : this()
        {
            this.lnp = lnp;
        }

        /*
        private void FPrincipal_Load(object sender, EventArgs e)
        {
            ILNPSala lnSala = lnp as ILNPSala;
            if (lnSala != null )
            {
                ejemplaresToolStripMenuItem.Enabled = false;
                préstamosToolStripMenuItem.Enabled = true;
                usuariosToolStripMenuItem.Enabled = true;
                documentosToolStripMenuItem.Enabled = false;

            }
            else 
            {
                préstamosToolStripMenuItem.Enabled = true;
                usuariosToolStripMenuItem.Enabled = true;
                documentosToolStripMenuItem.Enabled = true;
                ejemplaresToolStripMenuItem.Enabled = true;
            }

        }*/

        private void menuUsuariosAlta_Click(object sender, EventArgs e)
        {
            //AbrirFormularioHijo(new FAltaUsuario(usuarios));
        }

        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Cerrar formularios abiertos del mismo tipo
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == formularioHijo.GetType())
                {
                    form.Activate();
                    formularioHijo.Dispose();
                    return;
                }
            }

            // Configurar como hijo MDI
            formularioHijo.MdiParent = this;
            formularioHijo.WindowState = FormWindowState.Maximized;
            formularioHijo.Show();
        }
    }
}
