using System.Linq.Expressions;

namespace KocakBlog.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<List<T>> TGetListAsync();

        Task<T> TGetByFilterAsync(Expression<Func<T, bool>> predicate);

        Task<T> TGetByIdAsync(int id);

        Task TCreateAsync(T entity);

        Task TUpdateAsync(T entity);

        Task TDeleteAsync(int id);

        Task<int> TCountAsync();

        Task<int> TFilteredCountAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> TGetFilteredListAsync(Expression<Func<T, bool>> predicate);
    }
}