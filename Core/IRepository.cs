using System;
using System.Linq;

namespace Core
{
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> GetAll();

        T GetById(Guid id);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteAll();
    }
}