using Mvc4App.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Mvc4App.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal AppDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }        
        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }                
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }        
    }
}
