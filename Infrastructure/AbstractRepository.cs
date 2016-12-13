using System;
using System.Linq;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected AbstractRepository()
        {
            Context = Activator.CreateInstance<BaseContext>();
        }

        public BaseContext Context { get; set; }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T GetById(Guid id)
        {
            return Context.Find<T>(id);
        }

        public void Create(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public void DeleteAll()
        {
            foreach (var p in Context.Set<T>())
            {
                Context.Entry(p).State = EntityState.Deleted;
            }
           // Context.SaveChanges();
        }
    }
}