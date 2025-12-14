using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{

    // Asi o un formulario comun de introducir algo?
    public partial class FIntroducirDNI : FComun
    {
        public FIntroducirDNI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                //this.MostrarAdvertencia("Debe introducir un DNI.");
                textBox1.Focus();
                return;
            }
        }
    }
}
