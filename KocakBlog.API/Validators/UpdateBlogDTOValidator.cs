using FluentValidation;
using KocakBlog.DTO.DTOs.BlogDTOs;

namespace KocakBlog.API.Validators
{
    public class UpdateBlogDTOValidator : AbstractValidator<UpdateBlogDTO>
    {
        public UpdateBlogDTOValidator()
        {
            RuleFor(x => x.BlogId)
         .GreaterThan(0).WithMessage("Blog id'si 0 dan büyük olmalıdır.");

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