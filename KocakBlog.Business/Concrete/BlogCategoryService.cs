using AutoMapper;
using AutoMapper.QueryableExtensions;
using KocakBlog.Business.Abstract;
using KocakBlog.Business.Responses;
using KocakBlog.DataAccess.UnitOfWork;
using KocakBlog.DTO.DTOs.BlogCategoryDTOs;
using KocakBlog.Entity.Entities;

namespace KocakBlog.Business.Concrete
{
    public class BlogCategoryService : IBlogCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlogCategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<bool>> CreateBlogCategoryAsync(CreateBlogCategoryDTO createBlogCategoryDTO)
        {
            var response = new ServiceResponse<bool>();

            if (createBlogCategoryDTO == null)
            {
                response.Success = false;
                response.Message = "Blog category creation failed: DTO is null";
                return response;
            }

            try
            {
                var mappedBlogCategory = _mapper.Map<BlogCategory>(createBlogCategoryDTO);
                await _unitOfWork.GetRepository<BlogCategory>().AddAsync(mappedBlogCategory);
                await _unitOfWork.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Blog category created successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while creating the blog category: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteBlogCategoryAsync(int id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var blogCategory = await _unitOfWork.GetRepository<BlogCategory>().GetByIdAsync(id);
                if (blogCategory == null)
                {
                    response.Success = false;
                    response.Message = "Blog category not found";
                    return response;
                }

                _unitOfWork.GetRepository<BlogCategory>().Delete(blogCategory);
                await _unitOfWork.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Blog category deleted successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while deleting the blog category: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<IQueryable<ResultBlogCategoryDTO>>> GetBlogCategoriesAsync()
        {
            var response = new ServiceResponse<IQueryable<ResultBlogCategoryDTO>>();

            try
            {
                var blogCategories = _unitOfWork.GetRepository<BlogCategory>().GetAllQuery().ProjectTo<ResultBlogCategoryDTO>(_mapper.ConfigurationProvider);

                response.Data = blogCategories;
                response.Success = true;
                response.Message = "Blog categories retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while retrieving blog categories: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<ResultBlogCategoryDTO>> GetBlogCategoryByIdAsync(int id)
        {
            var response = new ServiceResponse<ResultBlogCategoryDTO>();

            try
            {
                var blogCategory = await _unitOfWork.GetRepository<BlogCategory>().GetByIdAsync(id);
                if (blogCategory == null)
                {
                    response.Success = false;
                    response.Message = "Blog category not found";
                    return response;
                }

                var resultBlogCategoryDTO = _mapper.Map<ResultBlogCategoryDTO>(blogCategory);
                response.Data = resultBlogCategoryDTO;
                response.Success = true;
                response.Message = "Blog category retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while retrieving the blog category: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateBlogCategoryAsync(UpdateBlogCategoryDTO updateBlogCategoryDTO)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var blogCategory = await _unitOfWork.GetRepository<BlogCategory>().GetByIdAsync(updateBlogCategoryDTO.BlogCategoryId);
                if (blogCategory == null)
                {
                    response.Success = false;
                    response.Message = "Blog category not found";
                    return response;
                }

                _mapper.Map(updateBlogCategoryDTO, blogCategory);
                _unitOfWork.GetRepository<BlogCategory>().Update(blogCategory);
                await _unitOfWork.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Blog category updated successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while updating the blog category: {ex.Message}";
            }

            return response;
        }
    }
}