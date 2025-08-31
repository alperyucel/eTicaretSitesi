using AlisverisLab.Entity.POCO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.DbContext
{
    public class AlisverisLabDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=AlisverisLabDB;Trusted_Connection=True;TrustServerCertificate=True;");

		
			base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new AppRole
                {
                    Id = 2,
                    Name = "UserApp",
                    NormalizedName = "USERAPP",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });

            builder.Entity<Menu>().HasData(
                new Menu { Id = 1, Title = "Dashboard", Icon = "nav-icon fas fa-tachometer-alt", AreaName = "admin", ControllerName = "Home", ActionName = "Index", OrderNumber = 1 },

                new Menu { Id = 2, Title = "Products", Icon = "nav-icon fas fa-th", AreaName = "admin", ControllerName = "Product", ActionName = "Index", OrderNumber = 2 },

                new Menu { Id = 3, Title = "Categories", Icon = "nav-icon fas fa-th", AreaName = "admin", ControllerName = "Category", ActionName = "Index", OrderNumber = 3 },

                new Menu { Id = 4, Title = "Menu Management", Icon = "nav-icon fas fa-th", AreaName = "admin", ControllerName = "Menu", ActionName = "Index", OrderNumber = 4 }
                );

            base.OnModelCreating(builder);
        }


        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductMedia> ProductMedias { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}
