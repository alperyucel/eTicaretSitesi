using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using AlisverisLab.MVC.Extensions;
using AlisverisLab.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System.Diagnostics;

namespace AlisverisLab.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IProductService productService;
        IMapper mapper;
        IMemoryCache memoryCache;
         
        public HomeController(ILogger<HomeController> logger, IProductService productService,IMapper mapper, IMemoryCache memoryCache)
        {
            _logger = logger;
            this.productService = productService;
            this.mapper = mapper;
            this.memoryCache = memoryCache;
             
        }

        [ResponseCache(Duration = 60 * 20, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Index()
        {
            //var products = (List<Product>)productService.GetAll(includes: "ProductMedias.Media").Data;

            //List<ProductDTO> productDtoList = mapper.Map<List<ProductDTO>>(products);            

            List<ProductDTO> veri = memoryCache.GetCache<List<ProductDTO>>("productDtoList");

            if (veri == null)
            {
                List<ProductDTO> data = mapper.Map<List<ProductDTO>>((List<Product>)productService.GetAll(includes: "ProductMedias.Media").Data).Take(8).ToList();

                memoryCache.SetCache("productDtoList", data, TimeSpan.FromHours(1));
                return View(data);
            }
            else
                return View(veri);

        }
		public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult TermsOfService()
        {
            return View();
        }
        public IActionResult Questions()
        {
            return View();
        }
        public IActionResult ReturnDelivery()
        {
            return View();
        }
        public IActionResult Shipping()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
