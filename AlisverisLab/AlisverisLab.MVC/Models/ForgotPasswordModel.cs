using System.ComponentModel.DataAnnotations;

namespace AlisverisLab.MVC.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
