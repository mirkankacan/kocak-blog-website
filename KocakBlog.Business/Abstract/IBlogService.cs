using KocakBlog.Business.Concrete;
using KocakBlog.DTO.DTOs.BlogDTOs;

namespace KocakBlog.Business.Abstract
{
    public interface IBlogService
    {
        Task<ServiceResponse<IQueryable<ResultBlogDTO>>> GetBlogsAsync();

        Task<ServiceResponse<ResultBlogDTO>> GetBlogByIdAsync(Guid id);

        Task<ServiceResponse<bool>> CreateBlogAsync(CreateBlogDTO createBlogDTO);

        Task<ServiceResponse<bool>> UpdateBlogAsync(UpdateBlogDTO updateBlogDTO);

        Task<ServiceResponse<bool>> DeleteBlogAsync(Guid id);
    }
}