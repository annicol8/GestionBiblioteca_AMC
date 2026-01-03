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
    public partial class FAltaPersonal : FComun
    {
        private ILNPersonal lnp;
        private string dniPersonal;

        public FAltaPersonal() : base()
        {
            InitializeComponent();
            this.AcceptButton = button_Aceptar;
        }

        public FAltaPersonal(ILNPersonal lnp, string dni) : this()
        {
            this.lnp = lnp;
            this.dniPersonal = dni;
            tb_Dni.Text = dniPersonal;  
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            // DNI
            if (!ValidarDNI(dniPersonal))
            {
                MostrarError("El DNI no es válido.");
                Close();
                return;
            }

            // Nombre
            if (!ValidarCampoNoVacio(tb_Nombre, "Nombre"))
                return;

            if (!ValidarNombre(tb_Nombre.Text))
                return;

            string nombre = NormalizarNombre(tb_Nombre.Text.Trim());

            // Contraseña
            if (!ValidarContraseña(tb_Contraseña))
                return;

            // Tipo de personal
            if (!ValidarTipoPersonal())
                return;

            try
            {
                if (lnp.GetPersonal(dniPersonal) != null)
                {
                    MostrarAdvertencia("Ya existe un personal con ese DNI.");
                    return;
                }

                Personal nuevoPersonal;

                if (check_Sala.Checked)
                {
                    nuevoPersonal = new PersonalSala(
                        dniPersonal,
                        nombre,
                        tb_Contraseña.Text.Trim());
                }
                else // Adquisiciones
                {
                    nuevoPersonal = new PersonalAdquisiciones(
                        dniPersonal,
                        nombre,
                        tb_Contraseña.Text.Trim());
                }

                lnp.AltaPersonal(nuevoPersonal);

                MostrarExito("Personal dado de alta correctamente");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex, "dar de alta el personal");
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkSala_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Sala.Checked)
                check_Adq.Checked = false;
        }

        private void chkAdquisiciones_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Adq.Checked)
                check_Sala.Checked = false;
        }

        private bool ValidarTipoPersonal()
        {
            if (!check_Sala.Checked && !check_Adq.Checked)
            {
                MostrarAdvertencia("Debe seleccionar el tipo de personal.");
                return false;
            }
            return true;
        }


    }
}
