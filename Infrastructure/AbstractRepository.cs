﻿using System;
using System.Linq;
using Core;

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

        public T GetById(string id)
        {
            return Context.Find<T>(id);
        }
        
        public void Create(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

    }
}