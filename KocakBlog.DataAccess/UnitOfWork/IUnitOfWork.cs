using KocakBlog.DataAccess.Repositories;

namespace KocakBlog.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;

        Task<int> SaveChangesAsync();
    }
}