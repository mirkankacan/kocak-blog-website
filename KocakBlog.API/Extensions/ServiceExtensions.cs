using AspNetCoreRateLimit;
using KocakBlog.Business.Abstract;
using KocakBlog.Business.Concrete;
using KocakBlog.Business.MappingProfiles;
using KocakBlog.DataAccess.Repositories;
using KocakBlog.DataAccess.UnitOfWork;

namespace KocakBlog.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this WebApplicationBuilder builder)
        {
            var services = builder.Services;

            #region AutoMapper

            services.AddAutoMapper(typeof(BlogProfile).Assembly);
            services.AddAutoMapper(typeof(BlogCategoryProfile).Assembly);

            #endregion AutoMapper

            #region Services

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IBlogService), typeof(BlogService));
            services.AddScoped(typeof(IBlogCategoryService), typeof(BlogCategoryService));

            #endregion Services

            #region RateLimiting

            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();

            #endregion RateLimiting
        }
    }
}