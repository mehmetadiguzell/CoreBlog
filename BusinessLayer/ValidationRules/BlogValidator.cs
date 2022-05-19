using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş bırakılamaz");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Lütfen bir resim seçiniz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş bırakılamaz");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog içeriği boş bırakılamaz");
        }
    }
}
