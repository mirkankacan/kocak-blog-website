using KocakBlog.Entity.Entities;
using KocakBlog.UI.DTOs.AppUserDTOs;
using Microsoft.AspNetCore.Identity;

namespace KocakBlog.UI.Services.UserService
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(RegisterAppUserDTO registerAppUserDTO);

        Task<string?> LoginAsync(LoginAppUserDTO loginAppUserDTO);

        Task<bool> LogoutAsync();

        Task<bool> CreateRoleAsync(RoleAppUserDTO roleAppUserDTO);

        Task<bool> AssignRoleAsync(List<AssignRoleDTO> assignRoleDTO);

        Task<List<AppUser>> GetAllUsersAsync();

        Task<AppUser> GetUserByIdAsync(int id);
    }
}