using FluentValidation;
using KocakBlog.DTO.DTOs.BlogCategoryDTOs;

namespace KocakBlog.API.Validators
{
    public class CreateBlogCategoryDTOValidator : AbstractValidator<CreateBlogCategoryDTO>
    {
        public CreateBlogCategoryDTOValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Kategori adı boş geçilemez.")
             .Length(2, 50).WithMessage("Kategori adı 2 ile 50 karakter arasında olmalıdır.");
        }
    }
}