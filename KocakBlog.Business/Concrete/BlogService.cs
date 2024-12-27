using AutoMapper;
using AutoMapper.QueryableExtensions;
using KocakBlog.Business.Abstract;
using KocakBlog.Business.Responses;
using KocakBlog.DataAccess.UnitOfWork;
using KocakBlog.DTO.DTOs.BlogDTOs;
using KocakBlog.Entity.Entities;

namespace KocakBlog.Business.Concrete
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const string imageBaseUrl = "..\\KocakBlog.UI\\wwwroot";

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
                response.Message = "Blog oluþturulamadý: Gerekli parametreler boþ.";
                return response;
            }

            try
            {
                var mappedBlog = _mapper.Map<Blog>(createBlogDTO);
                await _unitOfWork.GetRepository<Blog>().AddAsync(mappedBlog);
                await _unitOfWork.SaveChangesAsync();

                string blogDirectory = Path.Combine(imageBaseUrl, "images", mappedBlog.BlogId.ToString());
                Directory.CreateDirectory(blogDirectory);

                string filePath = Path.Combine(blogDirectory, createBlogDTO.Image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createBlogDTO.Image.CopyToAsync(stream);
                }

                mappedBlog.ImageUrl = Path.Combine("images", mappedBlog.BlogId.ToString(), createBlogDTO.Image.FileName);
                _unitOfWork.GetRepository<Blog>().Update(mappedBlog);
                await _unitOfWork.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Blog baþarýlý bir þekilde oluþturuldu.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Blog oluþturulurken bir hata oluþtu: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteBlogAsync(int id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var blog = await _unitOfWork.GetRepository<Blog>().GetByIdAsync(id);
                if (blog == null)
                {
                    response.Success = false;
                    response.Message = "Blog bulunamadý.";
                    return response;
                }
                if (!string.IsNullOrEmpty(blog.ImageUrl) && File.Exists(blog.ImageUrl))
                {
                    File.Delete(blog.ImageUrl);
                }
                _unitOfWork.GetRepository<Blog>().Delete(blog);
                await _unitOfWork.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Blog baþarýlý bir þekilde silindi.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Blog silinirken bir hata oluþtu: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<ResultBlogDTO>> GetBlogByIdAsync(int id)
        {
            var response = new ServiceResponse<ResultBlogDTO>();

            try
            {
                var blog = await _unitOfWork.GetRepository<Blog>().GetByIdAsync(id);
                if (blog == null)
                {
                    response.Success = false;
                    response.Message = "Blog bulunamadý.";
                    return response;
                }

                var resultBlogDTO = _mapper.Map<ResultBlogDTO>(blog);
                response.Data = resultBlogDTO;
                response.Success = true;
                response.Message = "Blog baþarýlý bir þekilde getirildi.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Blog getirilirken bir hata oluþtu: {ex.Message}";
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
                response.Message = "Bloglar baþarýlý bir þekilde getirildi.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Bloglar getirilirken bir hata oluþtu: {ex.Message}";
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
                    response.Message = "Blog bulunamadý.";
                    return response;
                }

                if (updateBlogDTO.Image != null)
                {
                    string blogDirectory = Path.Combine(imageBaseUrl, "images", blog.BlogId.ToString());
                    Directory.CreateDirectory(blogDirectory);

                    string filePath = Path.Combine(blogDirectory, updateBlogDTO.Image.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updateBlogDTO.Image.CopyToAsync(stream);
                    }

                    blog.ImageUrl = Path.Combine("images", blog.BlogId.ToString(), updateBlogDTO.Image.FileName);
                }
                _mapper.Map(updateBlogDTO, blog);
                _unitOfWork.GetRepository<Blog>().Update(blog);
                await _unitOfWork.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Blog baþarýlý bir þekilde güncellendi.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Blog güncellenirken bir hata oluþtu: {ex.Message}";
            }

            return response;
        }
    }
}