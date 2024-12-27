using Microsoft.AspNetCore.Identity;

namespace KocakBlog.Entity.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsPermGranted { get; set; }
        public List<Blog> Blogs { get; set; }

    }
}