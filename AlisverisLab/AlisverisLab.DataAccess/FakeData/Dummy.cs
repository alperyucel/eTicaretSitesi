using AlisverisLab.DataAccess.DbContext;
using AlisverisLab.Entity.POCO;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.FakeData
{
    public class Dummy
    {
        static AlisverisLabDbContext db = new AlisverisLabDbContext();
        static void CategoryAdd(int count = 10)
        {
            //List<Category> categories = new List<Category>() {

            // new Category { CategoryName = "Teknoloji", CategoryDescription = "Teknoloji ürünleri categorisi" },
            // new Category { CategoryName = "Eğitim", CategoryDescription = "Eğitim ürünleri categorisi" },
            // new Category { CategoryName = "Sağlık", CategoryDescription = "Sağlık ürünleri categorisi" },
            //};

            ////db.Categories.AddRange(categories);
            //for (int i = 0; i < categories.Count; i++)
            //{
            //    db.Categories.Add(categories[i]);
            //}
            //db.SaveChanges();


            var categoryFaker = new Faker<Category>("tr").RuleFor(x => x.CategoryName, b => b.Commerce.Categories(1)[0]).RuleFor(x => x.CategoryDescription, g => g.Lorem.Paragraph(1));


            List<Category> categories = categoryFaker.Generate(count);

            db.Categories.AddRange(categories);
            db.SaveChanges();
        }

        static void EmployeeAdd(int count = 10)
        {
            var employeFaker = new Faker<Employee>("tr").RuleFor(x => x.FirstName, c => c.Person.FirstName).RuleFor(x => x.LastName, f => f.Person.LastName).RuleFor(x => x.Address, g => g.Address.FullAddress()).RuleFor(v => v.BirthDate, x => x.Person.DateOfBirth).RuleFor(v => v.HireDate, b => b.Person.DateOfBirth.Date.AddYears(15)).RuleFor(b => b.City, v => v.Person.Address.City).RuleFor(b => b.Country, n => n.Address.Country()).RuleFor(f => f.Title, v => v.Name.JobTitle());

            List<Employee> employes = employeFaker.Generate(count);



            db.Employees.AddRange(employes);
            db.SaveChanges();
        }
        static void ProductAdd(int count = 12)
        {
            var productFaker = new Faker<Product>().RuleFor(p => p.ProductName, f => f.Commerce.ProductName()).RuleFor(X => X.ProductDescription, v => v.Commerce.ProductDescription()).RuleFor(c => c.Price, b => Convert.ToDouble(b.Commerce.Price())).RuleFor(x => x.Stock, v => v.Random.Byte());

            var categoryFaker = new Faker<Category>("tr").RuleFor(x => x.CategoryName, b => b.Commerce.Categories(1)[0]).RuleFor(x => x.CategoryDescription, g => g.Lorem.Paragraph(1));

            var products = productFaker.Generate(count);
            db.Products.AddRange(products);
            db.SaveChanges();

            var mediaFaker = new Faker<Media>("tr").RuleFor(x => x.Path, v => v.Image.PicsumUrl()).RuleFor(c => c.MediaTypeId, 1);

            List<Category> categories = categoryFaker.Generate(10);

            db.Categories.AddRange(categories);
            db.SaveChanges();

            Random r = new Random();

            for (int i = 0; i < products.Count; i++)
            {

                List<Media> mediaList = mediaFaker.Generate(3);
                db.Medias.AddRange(mediaList);
                db.SaveChanges();
                for (int k = 0; k < 3; k++)
                {
                    db.ProductCategories.Add(new ProductCategory { ProductId = products[i].Id, CategoryId = categories[r.Next(0,10)].Id });

                    db.ProductMedias.Add(new ProductMedia { ProductId = products[i].Id, MediaId = mediaList[k].Id });
                }
            }

            db.SaveChanges();
        }
        static void MediaTypeAdd()
        {
            List<MediaType> mediaTypes = new List<MediaType>() {

             new MediaType { Name="image/jpeg",SupportedFileExtensions=".jpeg" },
             new MediaType { Name="image/png",SupportedFileExtensions=".png" },
             new MediaType { Name="image/jpg",SupportedFileExtensions=".jpg" },
             new MediaType { Name="video/mp4",SupportedFileExtensions=".mp4" },
             new MediaType { Name="audio/mp3",SupportedFileExtensions=".mp3" },
             new MediaType { Name="audio/wav",SupportedFileExtensions=".wav" },
            };

            for (int i = 0; i < mediaTypes.Count; i++)
            {
                db.MediaTypes.Add(mediaTypes[i]);
            }
            db.SaveChanges();
        }
        static void ShipperAdd(int count = 10)
        {
            var shipperFaker = new Faker<Shipper>("tr").RuleFor(x => x.CompanyName, c => c.Company.CompanyName()).RuleFor(x => x.Phone, v => v.Phone.PhoneNumber());
            List<Shipper> shippers = shipperFaker.Generate(count);

            db.Shippers.AddRange(shippers);
            db.SaveChanges();
        }
        public static void DataAdd()
        {
            MediaTypeAdd();
            EmployeeAdd();
            ProductAdd();
            ShipperAdd();

        }
    }
}
