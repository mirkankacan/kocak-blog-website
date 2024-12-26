using AutoMapper;
using KocakBlog.Business.Abstract;
using KocakBlog.DTO.DTOs.BlogDTOs;
using KocakBlog.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KocakBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IGenericService<Blog> _blogService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var values = await _blogService.TGetBlogsWithCategories();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var value = await _blogService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _blogService.TDeleteAsync(id);
            return Ok("Seçilen blog silindi.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBlogDTO createBlogDTO)
        {
            var newValue = _mapper.Map<Blog>(createBlogDTO);
            await _blogService.TCreateAsync(newValue);
            return Ok("Yeni blog oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBlogDTO updateBlogDTO)
        {
            var value = _mapper.Map<Blog>(updateBlogDTO);
            await _blogService.TUpdateAsync(value);
            return Ok("Seçilen blog güncellendi.");
        }
    }
}