using System.ComponentModel.DataAnnotations;

namespace AlisverisLab.Entity.ViewModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Zorunlu!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-Posta Zorunlu!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Zorunlu!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Tekrar Şifre Zorunlu!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolalar Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
    }
}
