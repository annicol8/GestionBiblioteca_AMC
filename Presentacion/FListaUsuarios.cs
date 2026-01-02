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
    public partial class FListaUsuarios : FComun
    {
        private ILNPersonal ln;
        private List<Usuario> usuarios;
        private BindingSource bindingSourceDni;
        private BindingSource bindingSourceNombre;

        //PRE: ln != null
        //POST: El formulario queda inicializado. Se cargan los usuarios activos
        //      Las listas de DNI y Nombre quedan enlazadas y sincronizadas
        public FListaUsuarios(ILNPersonal ln)
        {
            this.ln = ln;
            InitializeComponent();
            CargarUsuarios();
        }

        //PRE: ln ha sido inicializado correctamente
        //POST: Se obtiene la lista de usuarios activos. Los bindingSource quedan asociados a la misma lista
        //      listBox_Dni muestra los DNI de los usuarios y listBox_Nombre muestra los nombres de los usuarios
        private void CargarUsuarios()
        {
            usuarios = ln.GetUsuariosActivos(); //obtener los usuarios dados de alta
            
            bindingSourceDni = new BindingSource();
            bindingSourceDni.DataSource = usuarios;

            bindingSourceNombre = new BindingSource();
            bindingSourceNombre.DataSource = usuarios;

            //Sincronizamos ambas listas, si se cambia el orden de una de la otra también
            listBox_Dni.DataSource = bindingSourceDni;
            listBox_Dni.DisplayMember = "Dni";
            listBox_Dni.ValueMember = "Dni";


            listBox_Nombre.DataSource = bindingSourceNombre;
            listBox_Nombre.DisplayMember = "Nombre";
            listBox_Nombre.ValueMember = "Nombre";
        }

        //PRE: usuarios ha sido cargada correctamente
        //POST: La lista de usuarios queda ordenada por DNI ascendente
        //      Ambas listas se refrescan. El botón de orden por DNI indica el criterio activo
        private void bt_OrdenDni_Click(object sender, EventArgs e)
        {
            usuarios.Sort((u1, u2) => string.Compare(u1.Dni, u2.Dni, StringComparison.Ordinal));
            
            bindingSourceDni.ResetBindings(false);
            bindingSourceNombre.ResetBindings(false);

            bt_OrdenDni.Text = "DNI ▲";
            bt_OrdenNombre.Text = "Nombre ";
        }

        //PRE: usuarios ha sido cargada correctamente
        //POST: La lista de usuarios queda ordenada por Nombre ascendente
        //      Ambas listas se refrescan manteniendo la sincronización. El botón de orden por Nombre indica el criterio activo
        private void bt_OrdenNombre_Click(object sender, EventArgs e)
        {
            usuarios.Sort((u1, u2) => string.Compare(u1.Nombre, u2.Nombre, StringComparison.OrdinalIgnoreCase));

            bindingSourceDni.ResetBindings(false);
            bindingSourceNombre.ResetBindings(false);

            bt_OrdenDni.Text = "DNI";
            bt_OrdenNombre.Text = "Nombre ▲";
        }

        //PRE: El formulario está abierto
        //POST: El formulario se cierra
        private void bt_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
