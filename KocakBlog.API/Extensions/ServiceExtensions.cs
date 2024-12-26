using AspNetCoreRateLimit;
using FluentValidation;
using FluentValidation.AspNetCore;
using KocakBlog.Business.Abstract;
using KocakBlog.Business.Concrete;
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

            #region Validators

            builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();

            #endregion Validators
        }
    }
}