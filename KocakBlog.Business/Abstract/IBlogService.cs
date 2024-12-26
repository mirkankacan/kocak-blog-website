using KocakBlog.Business.Responses;
using KocakBlog.DTO.DTOs.BlogDTOs;

namespace KocakBlog.Business.Abstract
{
    public interface IBlogService
    {
        Task<ServiceResponse<IQueryable<ResultBlogDTO>>> GetBlogsAsync();

        Task<ServiceResponse<ResultBlogDTO>> GetBlogByIdAsync(int id);

        Task<ServiceResponse<bool>> CreateBlogAsync(CreateBlogDTO createBlogDTO);

        Task<ServiceResponse<bool>> UpdateBlogAsync(UpdateBlogDTO updateBlogDTO);

        Task<ServiceResponse<bool>> DeleteBlogAsync(int id);
    }
}