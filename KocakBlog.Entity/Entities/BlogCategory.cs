namespace KocakBlog.Entity.Entities
{
    public class BlogCategory
    {
        public Guid BlogCategoryId { get; set; }
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}