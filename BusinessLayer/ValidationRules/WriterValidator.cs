using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad soyad boş bırakılamaz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Email boş bırakılamaz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş bırakılamaz");


            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az iki karakter giriniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("İsim 50 karakterden fazla olamaz");
        }
    }
}
