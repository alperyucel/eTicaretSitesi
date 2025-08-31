using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using AlisverisLab.MVC.CustomAttributes;
using AlisverisLab.MVC.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AlisverisLab.MVC.Controllers
{
    public class FavoriteController : Controller
    {
        IMapper mapper;
        IFavoriteService favoriteService;
        UserManager<AppUser> userManager;
        IMemoryCache memoryCache;

        public FavoriteController(IMapper mapper, IFavoriteService favoriteService, UserManager<AppUser> userManager, IMemoryCache memoryCache)
        {
            this.mapper = mapper;
            this.favoriteService = favoriteService;
            this.userManager = userManager;
            this.memoryCache = memoryCache;
        }

        [ActiveUser]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

                //List<FavoriteDTO> favorites = mapper.Map<List<FavoriteDTO>>(favoriteService.GetAll(x => x.AppUserId == user.Id && x.Active == true, includes: "Product.ProductMedias.Media").Data);

                List<FavoriteDTO> veri = memoryCache.GetCache<List<FavoriteDTO>>("Favorite:Index");

                if (veri == null)
                {
                    List<FavoriteDTO> data = mapper.Map<List<FavoriteDTO>>(favoriteService.GetAll(x => x.AppUserId == user.Id && x.Active == true, includes: "Product.ProductMedias.Media").Data);
                    memoryCache.SetCache("Favorite:Index", data, TimeSpan.FromMinutes(2));

                    return View(data);
                }
                else
                    return View(veri);
            }
            return View();
        }

        public IActionResult FavoriteAdd(int id)
        {
            if (User.Identity.IsAuthenticated)
            {

                AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
                favoriteService.Add(new Favorite { AppUserId = user.Id, ProductId = id });

            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteFavorite(int id)
        {
            Favorite favorite = (Favorite)favoriteService.GetById(id).Data;
            favorite.Active = false;
            favoriteService.Delete(favorite);
            memoryCache.Remove("Favorite:Index");
            return RedirectToAction("Index");
        }
    }
}
