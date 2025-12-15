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
    public partial class FPSala : FPersonal
    {
        private ILNPSala lnSala;
        public FPSala()
        {
            InitializeComponent();
        }
        

        public FPSala(ILNPSala lnSala) : base(lnSala)
        {
            InitializeComponent();
            this.lnSala = lnSala;
        }
    }
}
