using AlisverisLab.BusinessLogic.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using AlisverisLab.MVC.CustomAttributes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlisverisLab.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [IsAdmin]
    public class MenuController : Controller
    {
        IMapper mapper;
        IMenuService menuService;
        public MenuController(IMenuService menuService, IMapper mapper)
        {
            this.menuService = menuService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetMenus()
        {
            return Json(new { result = true, data = (mapper.Map<List<MenuDTO>>(menuService.GetAll(x => x.Active == true).Data)).OrderBy(x => x.OrderNumber).ToList() });
        }
        public JsonResult AddMenu(MenuDTO model)
        {
            Menu menu = mapper.Map<Menu>(model);

            menu.Active = true;
            menu.CreatedTime = DateTime.Now;            
            menuService.Add(menu);
            return Json(new { result = true, message = "Menü Başarılı Bir Şekilde Eklendi" });
        }
        public JsonResult DeleteMenu(int id)
        {
            Menu menu = (Menu)menuService.GetById(id).Data;
            menu.Active = false;
            menuService.Delete(menu);
            return Json(new { result = true, message = "Menü Başarılı Bir Şekilde Silindi" });
        }
        public JsonResult GetMenu(int id)
        {
            return Json(new { result = true, data = mapper.Map<MenuDTO>(menuService.GetById(id).Data) });
        }
        public JsonResult UpdateMenu(MenuDTO menu)
        {

            Menu menuMap = mapper.Map<Menu>(menu);
            //menuMap.Active = true;
            //if (!validator.Validate(category).IsValid)
            //    return Json(new { result = false, message = string.Join(", ", validator.Validate(category).Errors.Select(x => x.ErrorMessage).ToList()) });

            menuService.UpdateMenu(menuMap);
            return Json(new { result = true, message = "Menü Başarılı Bir Şekilde Güncellendi" });
        }
    }
}
