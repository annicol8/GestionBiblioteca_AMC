using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace LogicaNegocio
{
    public static class LNLogin
    {
        public static Personal BuscarPersonalPorNombreYTipo(string nombre, TipoPersonal tipo)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return null;

            List<Personal> todosPersonales = Persistencia.Persistencia.GetPersonales();

            return todosPersonales.FirstOrDefault(p =>
                p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                p.Tipo == tipo);
        }
    }
}
