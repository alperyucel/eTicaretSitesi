using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using AlisverisLab.MVC.CustomAttributes;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlisverisLab.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [IsAdmin]
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        IMapper mapper;

        IValidator<CategoryDTO> validator;
        public CategoryController(ICategoryService categoryService, IMapper mapper, IValidator<CategoryDTO> validator)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetCategories()
        {

            return Json(new { data = mapper.Map<List<CategoryDTO>>(categoryService.GetAll(x => x.Active == true).Data) });
        }
        public JsonResult AddCategory(CategoryDTO kategori)
        {
            Category category = mapper.Map<Category>(kategori);


            if (!validator.Validate(kategori).IsValid)
                return Json(new { result = false, message = string.Join(", ", validator.Validate(kategori).Errors.Select(x => x.ErrorMessage).ToList()) });


            categoryService.Add(category);
            return Json(new { result = true, message = "Kategori Başarılı Bir Şekilde Eklendi" });
        }
        public JsonResult GetCategory(int id)
        {
            return Json(new { result = true, data = mapper.Map<CategoryDTO>(categoryService.GetById(id).Data) });
        }

        public JsonResult UpdateCategory(CategoryDTO category)
        {
            Category categoryMap = mapper.Map<Category>(category);

            if (!validator.Validate(category).IsValid)
                return Json(new { result = false, message = string.Join(", ", validator.Validate(category).Errors.Select(x => x.ErrorMessage).ToList()) });

            categoryService.Updatecategory(categoryMap);
            return Json(new { result = true, message = "Kategori Başarılı Bir Şekilde Güncellendi" });
        }
        public JsonResult DeleteCategory(int id)
        {
            Category category = (Category)categoryService.GetById(id).Data;
            category.Active = false;
            categoryService.Delete(category);
            return Json(new { result = true, message = "Kategori Başarılı Bir Şekilde Silindi" });
        }
    }
}
