using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal ModelContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ModelContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = dbSet;            
            return query.ToList();
            
        }

        public virtual TEntity GetById(int Id)
        {
            return dbSet.Find(Id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
                
        public virtual void Delete (TEntity entityToDelete)
        {
            if(context.Entry(entityToDelete).State == EntityState.Detached)
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
