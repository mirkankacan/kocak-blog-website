using AutoMapper;
using AutoMapper.QueryableExtensions;
using KocakBlog.Business.Abstract;
using KocakBlog.DataAccess.UnitOfWork;
using KocakBlog.DTO.DTOs.BlogDTOs;
using KocakBlog.Entity.Entities;

namespace KocakBlog.Business.Concrete
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlogService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<bool>> CreateBlogAsync(CreateBlogDTO createBlogDTO)
        {
            var response = new ServiceResponse<bool>();

            if (createBlogDTO == null)
            {
                response.Success = false;
                response.Message = "Blog creation failed: DTO is null";
                return response;
            }

            try
            {
                var mappedBlog = _mapper.Map<Blog>(createBlogDTO);
                await _unitOfWork.GetRepository<Blog>().AddAsync(mappedBlog);
                await _unitOfWork.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Blog created successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while creating the blog: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteBlogAsync(Guid id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var blog = await _unitOfWork.GetRepository<Blog>().GetByIdAsync(id);
                if (blog == null)
                {
                    response.Success = false;
                    response.Message = "Blog not found";
                    return response;
                }

                _unitOfWork.GetRepository<Blog>().Delete(blog);
                await _unitOfWork.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Blog deleted successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while deleting the blog: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<ResultBlogDTO>> GetBlogByIdAsync(Guid id)
        {
            var response = new ServiceResponse<ResultBlogDTO>();

            try
            {
                var blog = await _unitOfWork.GetRepository<Blog>().GetByIdAsync(id);
                if (blog == null)
                {
                    response.Success = false;
                    response.Message = "Blog not found";
                    return response;
                }

                var resultBlogDTO = _mapper.Map<ResultBlogDTO>(blog);
                response.Data = resultBlogDTO;
                response.Success = true;
                response.Message = "Blog retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while retrieving the blog: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<IQueryable<ResultBlogDTO>>> GetBlogsAsync()
        {
            var response = new ServiceResponse<IQueryable<ResultBlogDTO>>();

            try
            {
                var blogs = _unitOfWork.GetRepository<Blog>().GetAllQuery().ProjectTo<ResultBlogDTO>(_mapper.ConfigurationProvider);

                response.Data = blogs;
                response.Success = true;
                response.Message = "Blogs retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while retrieving blogs: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateBlogAsync(UpdateBlogDTO updateBlogDTO)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var blog = await _unitOfWork.GetRepository<Blog>().GetByIdAsync(updateBlogDTO.BlogId);
                if (blog == null)
                {
                    response.Success = false;
                    response.Message = "Blog not found";
                    return response;
                }

                _mapper.Map(updateBlogDTO, blog);
                _unitOfWork.GetRepository<Blog>().Update(blog);
                await _unitOfWork.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Blog updated successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while updating the blog: {ex.Message}";
            }

            return response;
        }
    }
}