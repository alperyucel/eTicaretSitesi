using System.ComponentModel.DataAnnotations;

namespace AlisverisLab.Entity.ViewModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Zorunlu!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre Zorunlu!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsRemember { get; set; }
    }
}
