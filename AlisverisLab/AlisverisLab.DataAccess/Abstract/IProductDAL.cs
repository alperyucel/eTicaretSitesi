using AlisverisLab.Core.DataAccess;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Abstract
{
    public interface IProductDAL : IRepository<Product>
    {
		public bool AddProduct(Product product);
		public bool UpdateProduct(Product product);

	}
}
