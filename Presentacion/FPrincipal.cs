using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModeloDominio;

namespace Presentacion
{
    public partial class FPrincipal : Form
    {
        private Personal personal;
        private Personal Personal
        {
            get { return personal; }
            set { personal = value; }
        }
        public FPrincipal()
        {
            InitializeComponent();
        }

        public FPrincipal(Personal personal) : this()
        {
            this.Personal = personal;
        }



    }
}
