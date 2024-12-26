using KocakBlog.Business.Responses;
using KocakBlog.DTO.DTOs.BlogCategoryDTOs;

namespace KocakBlog.Business.Abstract
{
    public interface IBlogCategoryService
    {
        Task<ServiceResponse<IQueryable<ResultBlogCategoryDTO>>> GetBlogCategoriesAsync();

        Task<ServiceResponse<ResultBlogCategoryDTO>> GetBlogCategoryByIdAsync(int id);

        Task<ServiceResponse<bool>> CreateBlogCategoryAsync(CreateBlogCategoryDTO createBlogCategoryDTO);

        Task<ServiceResponse<bool>> UpdateBlogCategoryAsync(UpdateBlogCategoryDTO updateBlogCategoryDTO);

        Task<ServiceResponse<bool>> DeleteBlogCategoryAsync(int id);
    }
}