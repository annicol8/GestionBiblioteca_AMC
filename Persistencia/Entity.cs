namespace Persistencia
{
    public class Entity<T>
    {
        private T clave;

        public Entity(T clave)
        {
            this.clave = clave;
        }
        public T Clave
        {
            get
            {
                return this.clave;
            }
        }
    }

}
