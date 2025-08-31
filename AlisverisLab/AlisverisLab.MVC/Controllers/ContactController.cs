using Microsoft.AspNetCore.Mvc;

namespace AlisverisLab.MVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
