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
    public partial class FPAdq : Form
    {
        //private ILNPAdq lnAdq;

        public FPAdq(Personal p)//: base(p)
        {
            //this.lnAdq = new ILNPAdq(p);
            InitializeComponent();
        }
    }
}
