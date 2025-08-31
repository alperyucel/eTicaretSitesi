using AlisverisLab.Core.DataAccess;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using AlisverisLab.MVC.CustomAttributes;
using AlisverisLab.MVC.Extensions;
using AutoMapper;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AlisverisLab.MVC.Controllers
{
    public class CartController : Controller
    {
        IMapper mapper;
        ICartService cartService;
        UserManager<AppUser> userManager;
        IMemoryCache memoryCache;

        public CartController(ICartService cartService, IMapper mapper, UserManager<AppUser> userManager, IMemoryCache memoryCache)
        {
            this.cartService = cartService;
            this.mapper = mapper;
            this.userManager = userManager;
            this.memoryCache = memoryCache;
        }

        [ActiveUser]
        //[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

                List<CartDTO> carts = mapper.Map<List<CartDTO>>(cartService.GetAll(x => x.AppUserId == user.Id && x.Active == true,includes:"Product.ProductMedias.Media").Data);
				return View(carts);

				//List<CartDTO> veri = memoryCache.GetCache<List<CartDTO>>("Cart:Index");
				//if (veri == null)
				//{
				//    List<CartDTO> data = mapper.Map<List<CartDTO>>(cartService.GetAll(x => x.AppUserId == user.Id && x.Active == true, includes: "Product.ProductMedias.Media").Data);

				//    memoryCache.SetCache("Cart:Index", data, TimeSpan.FromMinutes(2));

				//    return View(data);
				//}
				//else
				//    return View(veri);
			}
            return View();
        }
        public IActionResult CartAdd(int id, int quantity)
        {
            if (User.Identity.IsAuthenticated && quantity > 0)
            {
                AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

                //HttpClient client = new HttpClient();

                //CartDTO cartDTO = new CartDTO { AppUserId = user.Id, ProductId = id, Quantity = quantity };

                //string json = JsonConvert.SerializeObject(cartDTO);

                //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                //var result = client.PostAsync("https://localhost:7062/api/Cart", content).Result;

                cartService.CartAdd(new Cart { AppUserId = user.Id, ProductId = id, Quantity = quantity });

                memoryCache.Remove("Cart:Index");
            }

            return RedirectToAction("Index", "Cart");
        }

        public IActionResult DeleteCart(int id)
        {
            cartService.DeleteCartById(id);
            memoryCache.Remove("Cart:Index");
            return RedirectToAction("Index");
        }
    }
}
