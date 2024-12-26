using KocakBlog.Business.Abstract;
using KocakBlog.DTO.DTOs.BlogDTOs;
using Microsoft.AspNetCore.Mvc;

namespace KocakBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _blogService.GetBlogsAsync();
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = await _blogService.GetBlogByIdAsync(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await _blogService.DeleteBlogAsync(id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBlogDTO createBlogDTO)
        {
            var response = await _blogService.CreateBlogAsync(createBlogDTO);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBlogDTO updateBlogDTO)
        {
            var response = await _blogService.UpdateBlogAsync(updateBlogDTO);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
    }
}