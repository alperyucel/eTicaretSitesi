using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using AlisverisLab.Entity.ViewModel;
using AutoMapper;

namespace AlisverisLab.MVC.AutoMapperProfiler
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>().ForMember(des => des.Paths, op => op.MapFrom(x => x.ProductMedias.Select(s => s.Media.Path).ToList())).ForMember(des => des.GSelectedCategoryIds, op => op.MapFrom(x => x.ProductCategories.Select(s => s.CategoryId).ToArray())).ForMember(des => des.SelectedCategoryIds, op => op.MapFrom(x => x.ProductCategories.Select(s => s.CategoryId).ToArray())).ForMember(x => x.GProductName, op => op.MapFrom(x => x.ProductName)).ForMember(x => x.GProductDescription, op => op.MapFrom(x => x.ProductDescription)).ForMember(x => x.GPrice, op => op.MapFrom(x => x.Price)).ForMember(x => x.GStock, op => op.MapFrom(x => x.Stock)).ForMember(x => x.GId, op => op.MapFrom(x => x.Id)).ReverseMap();

            //Product Add İşlemi
            CreateMap<Product, AddProductDTO>().ForMember(des => des.Paths, op => op.MapFrom(x => x.ProductMedias.Select(s => s.Media.Path).ToList())).ForMember(des => des.SelectedCategoryIds, op => op.MapFrom(x => x.ProductCategories.Select(s => s.CategoryId).ToArray())).ForMember(des => des.Categories, op => op.MapFrom(x => x.ProductCategories.Select(s => s.Category).ToList())).ForMember(des=>des.CategoriesModel, op => op.MapFrom(x => x.ProductCategories.Select(s => s.Category).ToList())).ReverseMap();


			//CreateMap<ProductDTO, Product>().ForMember(des => des.ProductMedias, op => op.MapFrom(x => x.ProductMedias.Select(s => s.Media.Path).ToList()));

			//CreateMap<ProductDTO, Product>().ForMember(des => des.ProductMedias, op => op.MapFrom(x => x.Path.Select(s => s).ToList())).ReverseMap();


			CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>().ReverseMap();

            CreateMap<Cart, CartDTO>().ForMember(des => des.ImagePath, op => op.MapFrom(x => x.Product.ProductMedias.Select(s => s.Media.Path).FirstOrDefault())).ForMember(des => des.ProductName, op => op.MapFrom(x => x.Product.ProductName)).ForMember(des => des.Price, op => op.MapFrom(x => x.Product.Price));

            CreateMap<Favorite, FavoriteDTO>().ForMember(des => des.ImagePath, op => op.MapFrom(x => x.Product.ProductMedias.Select(s => s.Media.Path).FirstOrDefault())).ForMember(des => des.ProductName, op => op.MapFrom(x => x.Product.ProductName)).ForMember(des => des.Price, op => op.MapFrom(x => x.Product.Price));

            CreateMap<AppUser, ProfileModel>();
            CreateMap<ProfileModel, AppUser>().ReverseMap();

            CreateMap<Order, OrderDetailDTO>().ForMember(des => des.ImagePath, op => op.MapFrom(x => x.OrderDetails.Select(x => x.Product.ProductMedias.Select(s => s.Media.Path).FirstOrDefault()).FirstOrDefault())).ForMember(des => des.ProductName, op => op.MapFrom(x => x.OrderDetails.Select(s => s.Product.ProductName).FirstOrDefault())).ForMember(des => des.Price, op => op.MapFrom(x => x.OrderDetails.Select(s => s.Product.Price).FirstOrDefault())).ForMember(x => x.ProductId, op => op.MapFrom(x => x.OrderDetails.Select(x => x.ProductId).FirstOrDefault())).ReverseMap();

            CreateMap<Menu, MenuDTO>().ReverseMap();
        }
    }
}
