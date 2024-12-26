using KocakBlog.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KocakBlog.DataAccess.Context
{
    public class KocakBlogContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public KocakBlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
    }
}