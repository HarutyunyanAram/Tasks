using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace VS.Task.Data.Common
{
    public abstract class CommonRepository<TKey, T> : ICommonRepository<TKey, T>
        where T : class, new()
    {
        protected readonly DbContext _appContext;
        public CommonRepository(DbContext appContext)
        {
            _appContext = appContext;
        }

        public async System.Threading.Tasks.Task<T> Add(T entity)
        {
            var result = _appContext.Set<T>().Add(entity);
            await _appContext.SaveChangesAsync();

            return result.Entity;
        }

        public async System.Threading.Tasks.Task Delete(T entity)
        {
            _appContext.Set<T>().Remove(entity);
            await _appContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(T entity)
        {
            var entities = await _appContext.Set<T>().ToListAsync();
            DetachEntities(entities);

            _appContext.Entry(entity).State = EntityState.Modified;

            await _appContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task<T> GetById(TKey id)
        {
            return await _appContext.Set<T>().FindAsync(id);
        }

        public async System.Threading.Tasks.Task<T> GetSingleBySpec(ISpecification<T> spec)
        {
            var result = await List(spec);
            return result.FirstOrDefault();
        }

        public async System.Threading.Tasks.Task<List<T>> List()
        {
            return await _appContext.Set<T>().ToListAsync();
        }

        public async System.Threading.Tasks.Task<List<T>> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes.Aggregate(_appContext.Set<T>().AsQueryable(), (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings.Aggregate(queryableResultWithIncludes, (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult.Where(spec.Criteria).ToListAsync();
        }

        #region Private Methods

        private List<T> DetachEntities(List<T> entities)
        {
            foreach (var entity in entities)
            {
                _appContext.Entry(entity).State = EntityState.Detached;
                if (entity.GetType().GetProperty("Id") != null)
                {
                    entity.GetType().GetProperty("Id").SetValue(entity, 0);
                }
            }
            return entities;
        }
        
        #endregion //Private Methods
    }
}
