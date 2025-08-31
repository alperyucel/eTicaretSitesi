using AlisverisLab.BusinessLogic.Abstract;
using AlisverisLab.BusinessLogic.Concrete;
using AlisverisLab.Core.Utility;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.DataAccess.Concrete.Entityframework;
using AlisverisLab.DataAccess.DbContext;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.BusinessLogic.DependencyResolver
{
    public static class DependencyService
    {
        public static IServiceCollection AddBussinessService(this IServiceCollection services)
        {
            services.AddSingleton<ICartDAL, EfCart>();
            services.AddSingleton<ICategoryDAL, EfCategory>();
            services.AddSingleton<IEmployeeDAL, EfEmployee>();
            services.AddSingleton<IFavoriteDAL, EfFavorite>();
            services.AddSingleton<ILogDAL, EfLog>();
            services.AddSingleton<ILogTypeDAL, EfLogType>();
            services.AddSingleton<IMediaDAL, EfMedia>();
            services.AddSingleton<IMediaTypeDAL, EfMediaType>();
            services.AddSingleton<IOrderDAL, EfOrder>();
            services.AddSingleton<IOrderDetailDAL, EfOrderDetail>();
            services.AddSingleton<IProductDAL, EfProduct>();
            services.AddSingleton<IProductCategoryDAL, EfProductCategory>();
            services.AddSingleton<IProductMediaDAL, EfProductMedia>();
            services.AddSingleton<IShipperDAL, EfShipper>();
            services.AddSingleton<IMenuDAL, EfMenu>();


            services.AddSingleton<ILogService, LogManager>();
            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<IEmployeeService, EmployeeManager>();
            services.AddSingleton<IFavoriteService, FavoriteManager>();
            services.AddSingleton<ICartService, CartManager>();
            services.AddSingleton<ILogTypeService, LogTypeManager>();
            services.AddSingleton<IMediaService, MediaManager>();
            services.AddSingleton<IMediaTypeService, MediaTypeManager>();
            services.AddSingleton<IOrderService, OrderManager>();
            services.AddSingleton<IOrderDetailService, OrderDetailManager>();
            services.AddSingleton<IProductService, ProductManager>();
            services.AddSingleton<IProductCategoryService, ProductCategoryManager>();
            services.AddSingleton<IProductMediaService, ProductMediaManager>();
            services.AddSingleton<IShipperService, ShipperManager>();
            services.AddSingleton<IMenuService, MenuManager>();

            services.AddDbContext<AlisverisLabDbContext>();

            services.AddSingleton<EmailService>();
            return services;
        }
    }
}
