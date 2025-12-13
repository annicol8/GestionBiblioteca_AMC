using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace LogicaNegocio
{
    public interface ILNLogin
    {
        Personal BuscarPersonalPorNombreYTipo(string nombre, TipoPersonal tipo)
       }
}
