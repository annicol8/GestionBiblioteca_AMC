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
    public partial class FPAdq : FPersonal
    {
        private ILNPAdq lnAdq;

        public FPAdq(ILNPAdq lnpa): base(lnpa)
        {
            this.lnAdq = lnpa;
            InitializeComponent();
        }

        public FPAdq()
        {
            InitializeComponent();
        }
    }
}
