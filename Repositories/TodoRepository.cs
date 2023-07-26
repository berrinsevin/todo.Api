using toddo.Api.Context;
using todo.Api.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace todo.Api.Repositories
{
    public class TodoRepository<T> : ITodoRepository<T> where T : BaseEntity
    {
        private readonly TodoContext _dbContext;
        private DbSet<T> _dbSet;

        public TodoRepository(TodoContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public async Task<bool> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<T> GetById(long id)
        {
            var data = _dbSet.FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                return data;
            }

            return null;
        }
        public async Task<IQueryable<T>> GetAll()
        {
            return _dbSet;
        }
        public async Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}