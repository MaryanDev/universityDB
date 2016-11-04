using PFMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMS.Repositories.Abstract
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected PintingFactoryDBEntities context;

        public BaseRepository(PintingFactoryDBEntities context)
        {
            this.context = context;
        }

        public virtual void Delete(TEntity entity) 
        {
            //context.Set<TEntity>().Remove(context.Set<TEntity>().SingleOrDefault<TEntity>(criteria));
            context.Set<TEntity>().Remove(entity);
        }

        public virtual IEnumerable<TEntity> Get(Func<TEntity, bool> criteria = null)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            //query = IncludePaths(paths, query);

            if (criteria != null)
            {
                query = query.Where(criteria).AsQueryable();
            }
            return query.ToList();
        }

        public virtual TEntity GetSingle(Func<TEntity, bool> criteria = null) 
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            //query = IncludePaths(paths, query);

            if (criteria != null)
            {
                query = query.Where(criteria).AsQueryable();
            }
            return query.SingleOrDefault();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            TEntity insertedEntity = null;
            insertedEntity = context.Set<TEntity>().Add(entity);
            return insertedEntity;

        }

        public virtual TEntity Update(TEntity entity)
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public virtual int GetCountOfRecords(Func<TEntity, bool> criteria = null)
        {
            int count;
            if(criteria != null)
            {
                count = context.Set<TEntity>().Where(criteria).Count();
            }
            else
            {
                count = context.Set<TEntity>().Count();
            }
            return count;
        }

        //public BaseRepository(string connectionString)
        //{
        //    this.context = new PintingFactoryDBEntities(connectionString);
        //}
    }
}
