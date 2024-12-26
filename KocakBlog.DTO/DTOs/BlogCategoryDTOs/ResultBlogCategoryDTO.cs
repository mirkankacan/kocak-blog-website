using KocakBlog.DTO.DTOs.BlogDTOs;

namespace KocakBlog.DTO.DTOs.BlogCategoryDTOs
{
    public class ResultBlogCategoryDTO
    {
        public Guid BlogCategoryId { get; set; }
        public string Name { get; set; }
        public List<ResultBlogDTO> Blogs { get; set; }
    }
}