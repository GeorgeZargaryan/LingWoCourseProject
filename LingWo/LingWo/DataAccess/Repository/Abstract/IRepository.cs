namespace LingWo.DataAccess.Repository.Abstract
{
    public interface IRepository<T, TKey> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Edit(T entity);
        void Delete(TKey id);
        T GetById(TKey id);
    }
}