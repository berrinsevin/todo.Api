using System.Linq.Expressions;

namespace todo.Api.Repositories
{
    public interface ITodoRepository<T>
    {
        Task<bool> AddAsync(T entitiy);
        Task<bool> UpdateAsync(T entitiy);
        Task<bool> DeleteAsync(T entitiy);
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(long id);
        Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}