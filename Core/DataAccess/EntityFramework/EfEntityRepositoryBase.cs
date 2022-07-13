using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext rentACarContext = new TContext())
            {
                var addedEntity = rentACarContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                rentACarContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext rentACarContext = new TContext())
            {
                var deletedEntity = rentACarContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                rentACarContext.SaveChanges();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext rentACarContext = new TContext())
            {
                return rentACarContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext rentACarContext = new TContext())
            {
                return filter == null ? rentACarContext.Set<TEntity>().ToList() : rentACarContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext rentACarContext = new TContext())
            {
                var updatedEntity = rentACarContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                rentACarContext.SaveChanges();
            }
        }
    }
}
