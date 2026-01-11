namespace ConsoleApp.Repository
{
    public abstract class BaseMemoryRepository <T>
    {
        protected List<T> _data = new List<T>();

        public virtual List<T> GetAll()
        {
            return _data;
        }

        public virtual void Save(T entity)
        {
            _data.Add(entity);
        }
    }
}
