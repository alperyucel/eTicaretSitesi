using AlisverisLab.MVC.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlisverisLab.MVC.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        [IsAdmin]
        //[Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
