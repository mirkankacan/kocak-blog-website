using System.Linq.Expressions;

namespace KocakBlog.DataAccess.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        void Delete(T entity);

        Task DeleteAsync(Guid id);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        void DeleteRange(IEnumerable<T> entities);

        Task<List<T>> GetAllAsync();

        IQueryable<T> GetAllQuery();

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetByIdAsync(Guid id);

        Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task<bool> ContainsAsync(T entity);
    }
}