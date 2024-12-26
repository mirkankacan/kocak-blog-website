using KocakBlog.Business.Abstract;
using KocakBlog.DataAccess.Abstract;
using System.Linq.Expressions;

namespace KocakBlog.Business.Concrete
{
    public class GenericManager<T>(IRepository<T> _repository) : IGenericService<T> where T : class
    {
        public async Task<int> TCountAsync()
        {
            return await _repository.CountAsync();
        }

        public async Task TCreateAsync(T entity)
        {
            await _repository.CreateAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<int> TFilteredCountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FilteredCountAsync(predicate);
        }

        public async Task<T> TGetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetByFilterAsync(predicate);
        }

        public async Task<T> TGetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<T>> TGetFilteredListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetFilteredListAsync(predicate);
        }

        public async Task<List<T>> TGetListAsync()
        {
            return await _repository.GetListAsync();
        }

        public async Task TUpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}