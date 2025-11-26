using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Tabla<T,U> : KeyedCollection<T, U> where U: Entity<T>
    {
        protected override T GetKeyForItem(U u)
        {
            return u.Clave;
        }
    }
}
