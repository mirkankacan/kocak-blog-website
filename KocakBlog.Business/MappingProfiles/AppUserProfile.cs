using AutoMapper;
using KocakBlog.DTO.DTOs.AppUserDTOs;
using KocakBlog.Entity.Entities;

namespace KocakBlog.Business.MappingProfiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, ResultAppUser>();
        }
    }
}
