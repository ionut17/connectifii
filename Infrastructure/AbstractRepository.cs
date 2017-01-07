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

        public void Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }

        public void Create(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public void DeleteAll()
        {
            var data = Context.Set<T>();
            if (data == null)
                return;
            foreach (var p in data)
                Context.Entry(p).State = EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}