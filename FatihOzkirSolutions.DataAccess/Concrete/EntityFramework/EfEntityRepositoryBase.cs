using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using FatihOzkirSolutions.Core.DataAccess;

namespace FatihOzkirSolutions.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, new()
    {
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var dbContext = new ProjectContext())
            {
                return filter == null ? dbContext.Set<TEntity>().ToList() : dbContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetEntity(Expression<Func<TEntity, bool>> filter)
        {
            using (var dbContext = new ProjectContext())
            {
                return dbContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var dbContext = new ProjectContext())
            {
                var addedEntity = dbContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                dbContext.SaveChanges();
                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var dbContext = new ProjectContext())
            {
                var updatedEntity = dbContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                dbContext.SaveChanges();
                return entity;
            }
        }

        public int Delete(TEntity entity)
        {
            using (var dbContext = new ProjectContext())
            {
                var deletedEntity = dbContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                return dbContext.SaveChanges();
            }
        }
    }
}
