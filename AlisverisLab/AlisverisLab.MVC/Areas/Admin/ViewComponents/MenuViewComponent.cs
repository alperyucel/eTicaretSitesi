using AlisverisLab.BusinessLogic.Abstract;
using AlisverisLab.Entity.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlisverisLab.MVC.Areas.Admin.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        IMapper mapper;
        IMenuService menuService;
        public MenuViewComponent(IMenuService menuService, IMapper mapper)
        {
            this.menuService = menuService;
            this.mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            return View((mapper.Map<List<MenuDTO>>(menuService.GetAll(x => x.Active == true).Data)).OrderBy(x => x.OrderNumber).ToList());
        }
    }
}
