using AutoMapper;
using KocakBlog.DTO.DTOs.BlogCategoryDTOs;
using KocakBlog.Entity.Entities;

namespace KocakBlog.Business.MappingProfiles
{
    public class BlogCategoryProfile : Profile
    {
        public BlogCategoryProfile()
        {
            CreateMap<BlogCategory, ResultBlogCategoryDTO>();
            CreateMap<CreateBlogCategoryDTO, BlogCategory>();
            CreateMap<UpdateBlogCategoryDTO, BlogCategory>();
        }
    }
}