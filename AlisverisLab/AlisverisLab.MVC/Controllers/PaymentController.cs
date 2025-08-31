using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using AlisverisLab.Entity.ViewModel;
using AlisverisLab.MVC.CustomAttributes;
using AlisverisLab.MVC.Extensions;
using AlisverisLab.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace AlisverisLab.MVC.Controllers
{
    public class PaymentController : Controller
    {
        ICartService cartService;
        IMapper mapper;
		UserManager<AppUser> userManager;
		IOrderService orderService;
		IMemoryCache memoryCache;
        IConnection connection;
        IChannel channel;
        public PaymentController(ICartService cartService, IMapper mapper, UserManager<AppUser> userManager, IOrderService orderService, IMemoryCache memoryCache)
        {
            this.cartService = cartService;
            this.mapper = mapper;
			this.userManager = userManager;
			this.orderService = orderService;
			this.memoryCache = memoryCache;

            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnectionAsync().Result;

            this.channel = connection.CreateChannelAsync().Result;
            channel.QueueDeclareAsync(queue: "orders", durable: false,
                exclusive: false, autoDelete: false, arguments: null);
        }

        [ActiveUser]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Checkout()
        {
            List<CartDTO> veri = memoryCache.GetCache<List<CartDTO>>("Payment:Checkout");
            if (veri == null)
            {
                AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
                List<CartDTO> data = mapper.Map<List<CartDTO>>(cartService.GetAll(x => x.Active == true && x.AppUserId ==user.Id, includes: "Product.ProductMedias.Media").Data);

                memoryCache.SetCache("Payment:Checkout", data, TimeSpan.FromMinutes(2));

                return View(data);
            }
            else
                return View(veri);
        }
		public IActionResult CartAdd(int id, int quantity)
		{
			if (User.Identity.IsAuthenticated && quantity > 0)
			{
				AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

				#region Web API Kullanılarak Post İşlemi Örneği
				//HttpClient client = new HttpClient();

				//CartDTO cartDTO = new CartDTO { AppUserId = user.Id, ProductId = id, Quantity = quantity };

				//string json = JsonConvert.SerializeObject(cartDTO);

				//StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

				//var result = client.PostAsync("https://localhost:7270/api/Cart", content).Result;
				#endregion


				cartService.CartAdd(new Cart { AppUserId = user.Id, ProductId = id, Quantity = quantity });
			}

			return RedirectToAction("Checkout", "Payment");

		}

		public IActionResult DeleteCart(int id)
		{
			cartService.DeleteCartById(id);
			return RedirectToAction("Checkout");
		}

		[HttpPost]
        [ActiveUser]
        public IActionResult CompleteOrder(OrderViewModel model)
        {
            AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
            orderService.CompleteOrder(user.Id, model.Address, model.CityName, model.Country, model.PostalCode);

            (string, double) result = ((string, double))orderService.LatestOrder(user.Id).Data;

            OrderInvoiceModel orderInvoiceModel = new OrderInvoiceModel { CustomerName = user.UserName, Email = user.Email, OrderId = result.Item1, TotalAmount = result.Item2 };

            string data = JsonConvert.SerializeObject(orderInvoiceModel);

            var body = Encoding.UTF8.GetBytes(data);

            channel.BasicPublishAsync("", routingKey: "orders", body);

            return Ok();
        }
        public IActionResult PaymentMethods()
        {
            return View();
        }
    }
}
