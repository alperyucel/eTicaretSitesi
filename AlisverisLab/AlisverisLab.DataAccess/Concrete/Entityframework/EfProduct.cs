using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
    public class EfProduct : EfRepository<Product>, IProductDAL
    {
		public bool AddProduct(Product product)
		{
			db.Add(product);
			return db.SaveChanges() > 0 ? true : false;
		}

		public bool UpdateProduct(Product product)
		{
			Product existingProduct = db.Products.Find(product.Id);
			if (existingProduct != null)
			{
				existingProduct.ProductName = product.ProductName;
				existingProduct.ProductDescription = product.ProductDescription;
				existingProduct.Stock = product.Stock;
				existingProduct.Price = product.Price;
				db.SaveChanges();
			}

			return true;

		}
	}
	
}
