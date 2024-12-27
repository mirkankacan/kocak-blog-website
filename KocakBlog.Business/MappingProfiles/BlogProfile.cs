using AutoMapper;
using KocakBlog.DTO.DTOs.BlogDTOs;
using KocakBlog.Entity.Entities;

namespace KocakBlog.Business.MappingProfiles
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog, ResultBlogDTO>()
                .ForMember(dest => dest.BlogCategory, opt => opt.MapFrom(src => src.BlogCategory))
                .ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser));
            CreateMap<CreateBlogDTO, Blog>();
            CreateMap<UpdateBlogDTO, Blog>();
        }
    }
}