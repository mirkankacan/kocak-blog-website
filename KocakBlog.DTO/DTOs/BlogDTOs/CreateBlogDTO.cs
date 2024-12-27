using Microsoft.AspNetCore.Http;

namespace KocakBlog.DTO.DTOs.BlogDTOs
{
    public class CreateBlogDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BlogCategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}