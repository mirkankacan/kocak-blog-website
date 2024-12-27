using System.ComponentModel.DataAnnotations;

namespace KocakBlog.UI.DTOs.AppUserDTOs
{
    public class RegisterAppUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; private set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsPermGranted { get; private set; }

        [Compare("Password", ErrorMessage = "Şifreler birbiriyle uyumlu değil.")]
        public string ConfirmPassword { get; set; }

        public RegisterAppUserDTO()
        {
            UserName = Email;
            IsPermGranted = false;
        }
    }
}