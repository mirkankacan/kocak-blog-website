using FluentValidation;
using KocakBlog.DTO.DTOs.BlogCategoryDTOs;

namespace KocakBlog.API.Validators
{
    public class UpdateBlogCategoryDTOValidator : AbstractValidator<UpdateBlogCategoryDTO>
    {
        public UpdateBlogCategoryDTOValidator()
        {
            RuleFor(x => x.BlogCategoryId)
            .GreaterThan(0).WithMessage("Blog kategori id'si 0'dan büyük olmalı.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı boş geçilemez.")
                .Length(2, 50).WithMessage("Kategori adı 2 ile 50 karakter arasında olmalıdır.");
        }
    }
}