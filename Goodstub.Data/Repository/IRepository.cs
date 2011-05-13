
namespace Goodstub.Data.Repository
{
    public interface IRepository<T>
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(long id);
    }
}
