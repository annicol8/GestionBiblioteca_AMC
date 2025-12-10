using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Entity<T>
    {
        private T clave;

        public  Entity (T clave){
            this.clave = clave;
        }
        public T Clave
        {
            get
            {
                return this.clave;
            }
        }

        /*
        public bool Equals(Entity<T> e)
        {
            if (e == null) return this == null ;
            else
            {
                return this.clave.Equals(e.Clave) ;
            }
        }
        */
    }
    
}
