using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace LogicaNegocio
{
    internal class LNPAdq : LNPersonal, ILNPAdq
    {
        public LNPAdq(PersonalAdquisiciones personal) : base(personal)
        {
        }
    }
}
