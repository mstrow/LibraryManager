namespace DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
        void Add(T instance);
        void Delete(int id);
        void Delete(T instance);
        T Get(int id);
        IEnumerable<T> List();
        void Update(T instance);
    }
}