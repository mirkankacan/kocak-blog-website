using AutoMapper;
using KocakBlog.Business.Abstract;
using KocakBlog.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KocakBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController(IGenericService<BlogCategory> _blogCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var values = await _blogCategoryService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var value = await _blogCategoryService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _blogCategoryService.TDeleteAsync(id);
            return Ok("Blog category record deleted");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var newValue = _mapper.Map<BlogCategory>(createBlogCategoryDto);
            await _blogCategoryService.TCreateAsync(newValue);
            return Ok("New blog category record created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            var value = _mapper.Map<BlogCategory>(updateBlogCategoryDto);
            await _blogCategoryService.TUpdateAsync(value);
            return Ok("Blog category record updated");
        }
    }
}