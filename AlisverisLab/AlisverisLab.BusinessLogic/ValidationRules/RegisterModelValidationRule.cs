using AlisverisLab.Entity.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.BusinessLogic.ValidationRules
{
    public class RegisterModelValidationRule : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidationRule()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("E-Posta Boş Geçilemez!");
            RuleFor(x => x.UserName).NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez!");
            RuleFor(x => x.Password).NotNull().WithMessage("Şifre Boş Geçilemez!");
            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("Şifre Tekrar Alanı Boş Geçilemez!");
        }
    }
}
