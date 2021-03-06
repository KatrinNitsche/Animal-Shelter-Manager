﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASM.DAL.Repositories
{
    public abstract class BaseRepository<TEntity>
           where TEntity : class
    {
        protected DataContext Context = null;

        public BaseRepository(DataContext context)
        {
            Context = context;
        }

        public abstract TEntity GetById(Guid id);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract IQueryable<TEntity> GetAll(bool asyn = true);
        public abstract TEntity ToggleActive(Guid id);

        public TEntity Add(TEntity entry)
        {
            Context.Set<TEntity>().Add(entry);
            Commit();
            return entry;
        }

        public void Remove(Guid id)
        {
            var set = Context.Set<TEntity>();
            var entity = set.Find(id);
            Context.Remove(entity);
            Commit();
        }

        public TEntity Update(TEntity entry)
        {
            Context.Entry(entry).State = EntityState.Modified;
            return entry;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}