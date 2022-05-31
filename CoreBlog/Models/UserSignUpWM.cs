using System.ComponentModel.DataAnnotations;

namespace CoreBlog.Models
{
    public class UserSignUpWM
    {
        [Required(ErrorMessage = "Ad soyad zorunludur")]
        [Display(Name = "Ad Soyad")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Şifre")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Mail giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adınızı giriniz")]
        public string UserName { get; set; }

    }
}
