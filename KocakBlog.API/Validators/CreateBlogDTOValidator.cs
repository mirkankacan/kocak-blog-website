using FluentValidation;
using KocakBlog.DTO.DTOs.BlogDTOs;

namespace KocakBlog.API.Validators
{
    public class CreateBlogDTOValidator : AbstractValidator<CreateBlogDTO>
    {
        public CreateBlogDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş geçilemez.")
                .Length(2, 100).WithMessage("Başlık 2 ile 100 karakter arasında olmalıdır.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("İçerik boş geçilemez.");

            RuleFor(x => x.BlogCategoryId)
                .GreaterThan(0).WithMessage("Blog kategori id'si 0'dan büyük olmalıdır.");
        }
    }
}