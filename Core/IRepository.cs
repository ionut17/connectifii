using System.Linq;

namespace Core
{
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> GetAll();

        void Create(T entity);
    }
}