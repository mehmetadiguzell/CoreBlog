using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category boş bırakılamaz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Lütfen bir açıklama yazınız");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("En az iki karakter giriniz.");
        }
    }
}
