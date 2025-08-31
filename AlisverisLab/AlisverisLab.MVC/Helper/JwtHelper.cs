using AlisverisLab.Entity.ViewModel;
using AlisverisLab.MVC.Extensions;
using AlisverisLab.MVC.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace AlisverisLab.MVC.Services
{
	public class JwtHelper
	{
		IHttpContextAccessor httpContext;
		HttpClient client;
        public JwtHelper(IHttpContextAccessor httpContext, HttpClient client)
        {
			this.httpContext = httpContext;
			this.client = client;
        }
		public string GetToken()
		{
            //var loginModel = new { Username = model.UserName, Password = model.Password };

            var session = httpContext.HttpContext.Session;

            var model = session.GetSession<LoginModel>("user");
            if (model != null)
            {
                var token = session.GetSession<string>("token");

                if (string.IsNullOrEmpty(token) || IsTokenExpired(token))
                {
                    var response = client.PostAsJsonAsync(client.BaseAddress + "api/Auth/giris", model).Result;
                    response.EnsureSuccessStatusCode();

                    var result = response.Content.ReadAsStringAsync().Result;

                    session.SetSession("token", result);
                }
                return token;

            }
            httpContext.HttpContext.Response.Redirect("/Account/LoginRegister");
            return "";
        }
        bool IsTokenExpired(string token)
        {


            var handler = new JwtSecurityTokenHandler();

            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            return jwtToken.ValidTo < DateTime.Now;


        }
    }
}
