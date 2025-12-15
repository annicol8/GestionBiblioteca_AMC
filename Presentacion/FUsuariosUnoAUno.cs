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
    public partial class FUsuariosUnoAUno : Form
    {
        private ILNPersonal lnp;
        private BindingSource bindingSource;
        public FUsuariosUnoAUno(ILNPersonal lnp)
        {
            InitializeComponent();
            this.lnp = lnp;
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            try
            {
                bindingSource = new BindingSource();
                bindingSource.DataSource = lnp.GetUsuariosActivos();

                textBox_Dni.DataBindings.Add("Text", bindingSource, "Dni");
                textBox_Nombre.DataBindings.Add("Text", bindingSource, "Nombre");


            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error al inicializar el formulario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
    }
}
