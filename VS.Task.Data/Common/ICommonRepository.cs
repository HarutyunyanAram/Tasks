using System.Collections.Generic;

namespace VS.Task.Data.Common
{
    public interface ICommonRepository<TKey, T> where T : class, new()
    {
        System.Threading.Tasks.Task<T> GetById(TKey id);
        System.Threading.Tasks.Task<T> GetSingleBySpec(ISpecification<T> spec);
        System.Threading.Tasks.Task<List<T>> List();
        System.Threading.Tasks.Task<List<T>> List(ISpecification<T> spec);
        System.Threading.Tasks.Task<T> Add(T entity);
        System.Threading.Tasks.Task Update(T entity);
        System.Threading.Tasks.Task Delete(T entity);
    }
}
