using AlisverisLab.Entity.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.BusinessLogic.ValidationRules
{
    public class LoginModelValidationRule : AbstractValidator<LoginModel>
    {
        public LoginModelValidationRule()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez!");
            RuleFor(x => x.Password).NotNull().WithMessage("Şifre Boş Geçilemez!");
        }
    }
}
