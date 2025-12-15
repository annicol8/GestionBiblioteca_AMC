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
    public partial class FListaUsuarios : Form
    {
        private ILNPersonal ln;
        private List<Usuario> usuarios;
        private BindingSource bindingSource;
        public FListaUsuarios(ILNPersonal ln)
        {
            this.ln = ln;
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            usuarios = ln.GetUsuariosActivos(); //obtener los usuarios dados de alta
            bindingSource = new BindingSource();
            bindingSource.DataSource = usuarios;

            //Sincronizamos ambas listas, si se cambia el orden de una de la otra también
            listBox_Dni.DataSource = bindingSource;
            listBox_Dni.DisplayMember = "Dni";

            listBox_Nombre.DataSource = bindingSource;
            listBox_Nombre.DisplayMember = "Nombre";
        }

        private void bt_OrdenDni_Click(object sender, EventArgs e)
        {
            usuarios.Sort((u1, u2) => string.Compare(u1.Dni, u2.Dni, StringComparison.Ordinal));
            bindingSource.ResetBindings(false);

            bt_OrdenDni.Text = "Dni ▲" ;
            bt_OrdenNombre.Text = " Nombre ▼";
        }

        private void bt_OrdenNombre_Click(object sender, EventArgs e)
        {
            usuarios.Sort((u1, u2) => string.Compare(u1.Nombre, u2.Nombre, StringComparison.OrdinalIgnoreCase));
            bindingSource.ResetBindings(false);

            bt_OrdenDni.Text = "Nombre ▲";
            bt_OrdenNombre.Text = "DNI ▼";
        }

        private void bt_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox_Dni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Nombre.SelectedIndex != listBox_Dni.SelectedIndex)
            {
                listBox_Nombre.SelectedIndex = listBox_Dni.SelectedIndex;
            }
        }

        private void listBox_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Dni.SelectedIndex != listBox_Nombre.SelectedIndex)
            {
                listBox_Dni.SelectedIndex = listBox_Nombre.SelectedIndex;
            }
        }
    }
}
