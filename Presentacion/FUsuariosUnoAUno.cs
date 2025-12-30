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
    public partial class FUsuariosUnoAUno : FComun
    {
        private ILNPersonal lnp;
        private BindingSource bindingSource;

        //PRE: El objeto lnp no es nulo y proporciona acceso a la lógica de negocio.
        //POST: El formulario queda creado e inicializado para mostrar usuarios uno a uno.
        public FUsuariosUnoAUno(ILNPersonal lnp)
        {
            this.lnp = lnp;
            InitializeComponent();
            InicializarFormulario();
        }

        //PRE: La lógica de negocio (lnp) está correctamente inicializada.
        //POST: Se cargan los usuarios activos en el BindingSource y se enlazan a los controles del formulario.
        private void InicializarFormulario()
        {
            try
            {
                bindingSource = new BindingSource();
                bindingSource.DataSource = lnp.GetUsuariosActivos();

                bindingNavigator1.BindingSource = bindingSource;

                textBox_Dni.DataBindings.Add("Text", bindingSource, "Dni");
                textBox_Nombre.DataBindings.Add("Text", bindingSource, "Nombre");


            }
            catch (Exception ex) 
            {
                MostrarError($"Error al inicializar el formulario: {ex.Message}");
            }
        }
    }
}
