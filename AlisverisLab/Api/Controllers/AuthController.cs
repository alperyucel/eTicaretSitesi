using AlisverisLab.Entity.POCO;
using Api.Services;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		IConfiguration configuration;
		UserManager<AppUser> userManager;
        public AuthController(IConfiguration configuration, UserManager<AppUser> userManager)
        {
			this.configuration = configuration;
			this.userManager = userManager;
		}

		[HttpPost("giris")]
		public IActionResult Login([FromBody] LoginModel loginModel)
		{

			AppUser user = userManager.FindByNameAsync(loginModel.Username).Result;
			if (user == null)
				return Unauthorized();

			bool result = userManager.CheckPasswordAsync(user, loginModel.Password).Result;
			if (!result)
				return Unauthorized();

			string token = JwtHelper.GenerateJwtToken(loginModel.Username);

            return Ok(token);

        }
	}
}
