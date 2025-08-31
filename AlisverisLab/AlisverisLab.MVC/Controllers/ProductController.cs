using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using AlisverisLab.MVC.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AlisverisLab.MVC.Controllers
{
	public class ProductController : Controller
	{
		IProductService productService;
		IMapper mapper;
        IMemoryCache memoryCache;

        public ProductController(IProductService productService, IMapper mapper, IMemoryCache memoryCache)
		{
			this.productService = productService;
			this.mapper = mapper;
			this.memoryCache = memoryCache;
			 
		}

        [ResponseCache(Duration = 60 * 20, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Index()
		{
            //List<ProductDTO> productDtoList = mapper.Map<List<ProductDTO>>(productService.GetAll(includes: "ProductMedias.Media").Data);
            List<ProductDTO> veri = memoryCache.GetCache<List<ProductDTO>>("productDtoList");

            if (veri == null)
            {
                List<ProductDTO> data = mapper.Map<List<ProductDTO>>(productService.GetAll(includes: "ProductMedias.Media").Data);

                memoryCache.SetCache("productDtoList", data, TimeSpan.FromHours(1));

                return View(data);
            }
            else
                return View(veri);

            //List<ProductDTO> productDtoList = memoryCache.GetCache<List<ProductDTO>>("productDtoList");
            //return View(productDtoList);
        }

        //[ResponseCache(Duration = 60 * 20, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Detail(int id)
		{
            //ProductDTO product = mapper.Map<ProductDTO>((Product)productService.GetById(id).Data);

            ProductDTO product = mapper.Map<ProductDTO>(((List<Product>)productService.GetAll(expression: x => x.Id == id, includes: "ProductMedias.Media").Data).FirstOrDefault());

            return View(product);

            //ProductDTO veri = memoryCache.GetCache<ProductDTO>("product");

            //if (veri == null)
            //{
            //    ProductDTO data = mapper.Map<ProductDTO>(((List<Product>)productService.GetAll(expression: x => x.Id == id, includes: "ProductMedias.Media").Data).FirstOrDefault());

            //    memoryCache.SetCache("product", data, TimeSpan.FromHours(1));
            //    return View(data);
            //}
            //else
            //    return View(veri);
        }

        //[ResponseCache(Duration = 60 * 20, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult ProductByCategory(int id)
		{
			List<ProductDTO> productDtoList = mapper.Map<List<ProductDTO>>(((List<Product>)productService.GetAll(includes: new string[] { "ProductMedias.Media", "ProductCategories" }).Data).Where(x => x.ProductCategories.Any(x => x.CategoryId == id)));
            return View(productDtoList);


            //List<ProductDTO> veri = memoryCache.GetCache<List<ProductDTO>>("productByCategoryList");
            //if (veri == null)
            //{
            //    List<ProductDTO> data = mapper.Map<List<ProductDTO>>(((List<Product>)productService.GetAll(includes: new string[] { "ProductMedias.Media", "ProductCategories" }).Data).Where(x => x.ProductCategories.Any(x => x.CategoryId == id)));

            //    memoryCache.SetCache("productByCategoryList", data, TimeSpan.FromHours(1));

            //    return View(data);
            //}
            //else
            //    return View(veri);

        }
	}
}
