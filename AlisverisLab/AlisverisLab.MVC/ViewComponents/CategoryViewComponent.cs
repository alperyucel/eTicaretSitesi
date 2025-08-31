using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.MVC.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlisverisLab.MVC.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        ICategoryService categoryService;
        IMapper mapper;
        IHttpContextAccessor httpContextAccessor;
        ApiService apiService;
        public CategoryViewComponent(ICategoryService categoryService, IMapper mapper, IHttpContextAccessor httpContextAccessor ,ApiService apiService)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.apiService = apiService;
        }
        public IViewComponentResult Invoke()
        {
            List<CategoryDTO> categories = mapper.Map<List<CategoryDTO>>(categoryService.GetAll(x => x.Active ).Data);
            //string token = HttpContext.Session.GetString("token");

            //if(token == null)
            //{

            //     HttpContext.Response.Redirect("/Account/LoginRegister");
            //    return Content("");
            //}

            #region Web Api kullanılarak get işlemi
            //HttpClient httpClient = new HttpClient();
            //string token = HttpContext.Session.GetSession<string>("token");
            //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            //List<CategoryDTO> categories = JsonConvert.DeserializeObject<List<CategoryDTO>>(httpClient.GetStringAsync("https://http://localhost:5240/api/Category").Result); 
            #endregion
            return View(categories);
        }
    }
}
