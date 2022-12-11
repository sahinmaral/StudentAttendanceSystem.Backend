using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using StudentAttendanceSystem.Core.Entities.Abstract;

using System.Linq.Expressions;

namespace StudentAttendanceSystem.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> 
        where TEntity : class, IEntity, new() 
        where TContext : DbContext, new()
    {
        
        public List<TEntity> Get()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public async Task<List<TEntity>> GetAsync()
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }

        public List<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(predicate).ToList();
            }
        }

        public async Task<List<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().Where(predicate).ToListAsync();
            }
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(predicate).SingleOrDefault();
            }
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().Where(predicate).SingleOrDefaultAsync(predicate);
            }
        }

        public TEntity GetById(Guid id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public virtual void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

    }
}
