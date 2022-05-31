using System.ComponentModel.DataAnnotations;

namespace CoreBlog.Models
{
    public class UserSignInWM
    {
        [Required(ErrorMessage = "Kullanıcı adınızı giriniz")]
        public string username { get; set; }
        [Required(ErrorMessage = "Şifre zorunludur")]
        public string password { get; set; }
    }
}
