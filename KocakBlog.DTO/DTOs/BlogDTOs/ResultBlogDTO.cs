using KocakBlog.DTO.DTOs.BlogCategoryDTOs;

namespace KocakBlog.DTO.DTOs.BlogDTOs
{
    public class ResultBlogDTO
    {
        public Guid BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public int BlogCategoryId { get; set; }
        public ResultBlogCategoryDTO BlogCategory { get; set; }
    }
}