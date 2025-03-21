﻿using CasaColombo.Domain.Interfaces.Repositories;
using CasaColombo.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {

        public virtual void Add(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(entity);
                dataContext.SaveChanges();
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public virtual List<TEntity> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().ToList();
            }
        }

        public virtual TEntity GetById(TKey id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().Find(id);
            }
        }

        public virtual void Adds(TEntity entity)
        {
            using (var dataContext = new DataContextSecundaria())
            {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public virtual void Updates(TEntity entity)
        {
            using (var dataContext = new DataContextSecundaria())
            {
                dataContext.Update(entity);
                dataContext.SaveChanges();
            }
        }

        public virtual void Deletes(TEntity entity)
        {
            using (var dataContext = new DataContextSecundaria())
            {
                dataContext.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public virtual List<TEntity> GetAlls()
        {
            using (var dataContext = new DataContextSecundaria())
            {
                return dataContext.Set<TEntity>().ToList();
            }
        }

        public virtual TEntity GetByIds(TKey id)
        {
            using (var dataContext = new DataContextSecundaria())
            {
                return dataContext.Set<TEntity>().Find(id);
            }
        }
    }
}
