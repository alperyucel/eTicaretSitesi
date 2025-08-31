using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using AlisverisLab.MVC.CustomAttributes;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlisverisLab.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [IsAdmin]
    public class ProductController : Controller
    {
        IMapper mapper;
        IProductService productService;
        ICategoryService categoryService;
        IProductCategoryService productCategoryService;
        IProductMediaService productMediaService;
        IMediaService mediaService;
        public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService, IProductCategoryService productCategoryService, IProductMediaService productMediaService, IMediaService mediaService)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.productCategoryService = productCategoryService;
            this.productMediaService = productMediaService;
            this.mediaService = mediaService;
        }

        public IActionResult Index()
        {
            ProductDTO product = new ProductDTO();
            product.Categories = mapper.Map<List<CategoryDTO>>(categoryService.GetAll(x => x.Active == true).Data).Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.CategoryName, Value = x.Id.ToString() }).ToList();
            return View(product);
        }

        public JsonResult GetProducts()
        {
            return Json(new { data = mapper.Map<List<ProductDTO>>(productService.GetAll(x => x.Active == true, includes: "ProductMedias.Media").Data) });
        }

        public JsonResult AddProduct(AddProductDTO productDto, List<IFormFile> files)
        {
            Product product = mapper.Map<Product>(productDto);

            productService.AddProduct(product);

            Product saveProduct = ((List<Product>)productService.GetAll(x => x.ProductName == productDto.ProductName && x.Active == true).Data).FirstOrDefault();

            for (int i = 0; i < productDto.SelectedCategoryIds.Length; i++)
            {
                productCategoryService.Add(new ProductCategory { ProductId = saveProduct.Id, CategoryId = productDto.SelectedCategoryIds[i] });
            }

            for (int i = 0; i < files.Count; i++)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "medias", files[i].FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    files[i].CopyTo(stream);
                    int mediaId = (int)mediaService.MediaAdd(new Media { Path = Path.Combine("/medias", files[i].FileName), MediaTypeId = 1 }).Data;

                    productMediaService.Add(new ProductMedia { MediaId = mediaId, ProductId = saveProduct.Id });

                }
            }
            return Json(new { result = true, message = "Ürün Başarılı Bir Şekilde Eklendi" });


        }




        public JsonResult GetProduct(int id)
        {
            return Json(new
            {
                result = true,
                data = mapper.Map<ProductDTO>(((List<Product>)productService.GetAll(x => x.Id == id && x.Active == true, includes:
            new string[] { "ProductCategories", "ProductMedias.Media" }).Data).FirstOrDefault())
            });
        }
        public JsonResult DeleteProduct(int id)
        {
            Product product = (Product)productService.GetById(id).Data;
            product.Active = false;
            productService.Delete(product);
            return Json(new { result = true, message = "Ürün Başarılı Bir Şekilde Silindi" });
        }

        public JsonResult UpdateProduct(ProductDTO productDto, List<IFormFile> files)
        {
            Product product = mapper.Map<Product>(productDto);

            productService.UpdateProduct(product);

            productCategoryService.DeleteCategory(product.Id);

            for (int i = 0; i < productDto.GSelectedCategoryIds.Length; i++)
            {

                productCategoryService.Add(new ProductCategory { ProductId = product.Id, CategoryId = productDto.GSelectedCategoryIds[i] });
            }

            productMediaService.DeleteMedia(product.Id);
            for (int i = 0; i < files.Count; i++)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "medias", files[i].FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    files[i].CopyTo(stream);
                    int mediaId = (int)mediaService.MediaAdd(new Media { Path = Path.Combine("/medias", files[i].FileName), MediaTypeId = 1 }).Data;

                    productMediaService.Add(new ProductMedia { MediaId = mediaId, ProductId = product.Id });

                }
            }
            return Json(new { result = true, message = "Ürün Başarılı Bir Şekilde Güncellendi" });
        }
    }    
}
