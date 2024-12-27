namespace KocakBlog.UI.DTOs.BlogDTOs
{
    public class UpdateBlogDTO
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime UpdatedAt { get; private set; }
        public IFormFile? Image { get; set; }
        public int BlogCategoryId { get; set; }

        public UpdateBlogDTO()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}