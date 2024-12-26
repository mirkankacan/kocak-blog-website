using System.Linq.Expressions;

namespace KocakBlog.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetListAsync();

        Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<int> CountAsync();

        Task<int> FilteredCountAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate);
    }
}