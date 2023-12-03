namespace LingWo.Services.Abstract
{
    public interface IService<T, Tkey> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Edit(T entity);
        void Remove(Tkey id);
        T GetById(Tkey id);
    }
}