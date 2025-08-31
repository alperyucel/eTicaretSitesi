using System.ComponentModel.DataAnnotations;

namespace AlisverisLab.MVC.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Parolalar Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }
    }
}
