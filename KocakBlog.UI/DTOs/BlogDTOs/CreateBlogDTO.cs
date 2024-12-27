namespace KocakBlog.UI.DTOs.BlogDTOs
{
    public class CreateBlogDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile Image { get; set; }
        public DateTime CreatedAt { get; private set; }
        public int BlogCategoryId { get; set; }
        public int AuthorId { get; set; }

        public CreateBlogDTO()
        {
            CreatedAt = DateTime.Now;
        }
    }
}