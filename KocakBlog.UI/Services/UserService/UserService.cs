using KocakBlog.Entity.Entities;
using KocakBlog.UI.DTOs.AppUserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KocakBlog.UI.Services.UserService
{
    public class UserService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<AppRole> _roleManager) : IUserService
    {
        public async Task<bool> AssignRoleAsync(List<AssignRoleDTO> assignRoleDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateRoleAsync(RoleAppUserDTO roleAppUserDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterAppUserDTO registerAppUserDTO)
        {
            var user = new AppUser
            {
                FirstName = registerAppUserDTO.FirstName,
                LastName = registerAppUserDTO.LastName,
                Email = registerAppUserDTO.Email,
                UserName = registerAppUserDTO.UserName,
            };
            if (registerAppUserDTO.Password != registerAppUserDTO.ConfirmPassword)
            {
                return new IdentityResult();
            }
            var result = await _userManager.CreateAsync(user, registerAppUserDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
            }
            return result;
        }

        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<string?> LoginAsync(LoginAppUserDTO loginAppUserDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginAppUserDTO.Email);
            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginAppUserDTO.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }

            var roles = new[] { "Admin", "Author" };

            foreach (var role in roles)
            {
                if (await _userManager.IsInRoleAsync(user, role))
                {
                    return role;
                }
            }

            return null;
        }

        public async Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}