using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost]
        public IActionResult CartAdd([FromBody] CartDTO cartDTO)
        {
            bool result = cartService.CartAdd(new Cart { AppUserId = cartDTO.AppUserId, ProductId = cartDTO.ProductId, Quantity = cartDTO.Quantity }).IsSuccess;

            if (result)
                return Ok();
            else
                return BadRequest();

        }
    }
}
