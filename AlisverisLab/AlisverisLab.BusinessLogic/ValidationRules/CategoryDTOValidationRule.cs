using AlisverisLab.DataAccess.DbContext;
using AlisverisLab.Entity.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.BusinessLogic.ValidationRules
{
    public class CategoryDTOValidationRule : AbstractValidator<CategoryDTO>
    {
        public CategoryDTOValidationRule()
        {
            RuleFor(x => x.CategoryName).NotNull().NotEmpty().WithMessage("Kategori Adı Boş Olamaz!");

            RuleFor(x => x.CategoryName).Length(3, 150).WithMessage("Kategori Adı 3-150 Karakter Aralığında Olmalıdır!");

            RuleFor(x => x.CategoryDescription).NotNull().NotEmpty().WithMessage("Kategori Açıklaması Boş Geçilemez!");

            RuleFor(x => x.CategoryDescription).MaximumLength(200).WithMessage("Kategori Açıklaması Maksimum 200 Karakter Olmalıdır!");


           // RuleFor(x => x.CategoryName).Must(CheckCategoryName).WithMessage("Bu Kategori Zaten Kayıtlı!");
            RuleFor(x => x.CategoryDescription).Must(CheckCategoryName).WithMessage("Bu Kategori Zaten Kayıtlı!");



        }

        bool CheckCategoryName(string categoryName)
        {
            using AlisverisLabDbContext db = new AlisverisLabDbContext();
            if (db.Categories.FirstOrDefault(x => x.CategoryDescription != x.CategoryDescription) == null)
                return true;
            else
                return false;

        }
    }
}
