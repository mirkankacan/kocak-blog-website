using AutoMapper;
using KocakBlog.DTO.DTOs.BlogCategoryDTOs;
using KocakBlog.Entity.Entities;

namespace KocakBlog.API.Mappings
{
    public class BlogCategoryMapping : Profile
    {
        public BlogCategoryMapping()
        {
            CreateMap<CreateBlogCategoryDTO, BlogCategory>().ReverseMap();
            CreateMap<UpdateBlogCategoryDTO, BlogCategory>().ReverseMap();
            CreateMap<ResultBlogCategoryDTO, BlogCategory>().ReverseMap();
        }
    }
}