using System;
using System.Linq;

namespace Core
{
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> GetAll();

        T GetById(Guid id);

        void Create(T entity);
    }
}