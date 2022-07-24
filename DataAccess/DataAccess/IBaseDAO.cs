namespace DataAccess
{
    public interface IBaseDAO<T> where T : class
    {
        public bool SaveEntity(T entity);
        public bool UpdateEntity(T entity);
        public bool DeleteEntity(T entity);
        public T GetEntityById(int? entityID);
        public IEnumerable<T> GetAllEntity();
    }
}
