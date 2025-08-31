using AlisverisLab.Entity.ViewModel;
using AlisverisLab.MVC.Extensions;
using System.IdentityModel.Tokens.Jwt;

namespace AlisverisLab.MVC.Services
{
    public class ApiService
    {
        HttpClient _httpClient;

        IHttpContextAccessor contextAccessor;

        public ApiService(IHttpContextAccessor contextAccessor, HttpClient httpClient)
        {
            this.contextAccessor = contextAccessor;
            _httpClient = httpClient;
        }


        public string MakeApiRequest(string endpoint)
        {
            string token = GetToken();

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


            var response = _httpClient.GetAsync(_httpClient.BaseAddress + endpoint).Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStringAsync().Result;
        }


        public string GetToken()
        {
            //var loginModel = new { Username = model.UserName, Password = model.Password };
            var session = contextAccessor.HttpContext.Session;

            var model = session.GetSession<LoginModel>("user");


            if (model != null)
            {



                var token = session.GetSession<string>("token");

                if (string.IsNullOrEmpty(token) || IsTokenExpired(token))
                {
                    var response = _httpClient.PostAsJsonAsync(_httpClient.BaseAddress + "api/Auth/giris", model).Result;
                    response.EnsureSuccessStatusCode();

                    var result = response.Content.ReadAsStringAsync().Result;

                    session.SetSession("token", result);
                }
                return token;

            }
            contextAccessor.HttpContext.Response.Redirect("/Account/LoginRegister");
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
