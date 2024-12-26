using KocakBlog.Business.Abstract;
using KocakBlog.DTO.DTOs.BlogCategoryDTOs;
using Microsoft.AspNetCore.Mvc;

namespace KocakBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController : ControllerBase
    {
        private readonly IBlogCategoryService _blogCategoryService;

        public BlogCategoriesController(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _blogCategoryService.GetBlogCategoriesAsync();
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _blogCategoryService.GetBlogCategoryByIdAsync(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _blogCategoryService.DeleteBlogCategoryAsync(id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBlogCategoryDTO createBlogCategoryDTO)
        {
            var response = await _blogCategoryService.CreateBlogCategoryAsync(createBlogCategoryDTO);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBlogCategoryDTO updateBlogCategoryDTO)
        {
            var response = await _blogCategoryService.UpdateBlogCategoryAsync(updateBlogCategoryDTO);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
    }
}