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
	public class OrderController : Controller
	{
		IMapper mapper;
		IOrderService orderService;
		UserManager<AppUser> userManager;
		IOrderDetailService orderDetailService;
		IMemoryCache memoryCache;
		public OrderController(IOrderService orderService, IMapper mapper, UserManager<AppUser> userManager,IOrderDetailService orderDetailService, IMemoryCache memoryCache)
		{
			this.orderService = orderService;
			this.mapper = mapper;
			this.userManager = userManager;
			this.orderDetailService = orderDetailService;
			this.memoryCache = memoryCache;
		}

		[ActiveUser]
        //[ResponseCache(Duration = 60 * 20, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Index()
		{
            AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

            //List<OrderDetailDTO> orders = (List<OrderDetailDTO>)orderDetailService.ListOrderDetail(user.Id).Data;

            List<OrderDetailDTO> veri = memoryCache.GetCache<List<OrderDetailDTO>>("Order:Index");

            if (veri == null)
            {
                List<OrderDetailDTO> data = (List<OrderDetailDTO>)orderDetailService.ListOrderDetail(user.Id).Data;

                memoryCache.SetCache("Order:Index", data, TimeSpan.FromMinutes(2));
                return View(data);
            }
            else
                return View(veri);
        }
	}
}
