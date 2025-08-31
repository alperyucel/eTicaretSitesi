using Microsoft.AspNetCore.Mvc;

namespace AlisverisLab.MVC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogDetails()
        {
            return View();
        }
    }
}
