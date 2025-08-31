using AlisverisLab.Entity.POCO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.BusinessLogic.ValidationRules
{
    public class ProductValidationRule : AbstractValidator<Product>
    {
        public ProductValidationRule()
        {
            RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("Ürün Adı Boş Olamaz!");

            RuleFor(x => x.ProductName).Length(3,150).WithMessage("Ürün Adı 3-150 Karakter Aralığında Olmalıdır.");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Ürün Fiyatı 0'dan Büyük Olmalıdır.");

            RuleFor(x => x.Stock).GreaterThan(0).WithMessage("Stok Miktarı 0'dan Büyük Olmalıdır.");
        }
    }
}
