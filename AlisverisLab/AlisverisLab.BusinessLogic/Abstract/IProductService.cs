using AlisverisLab.Core.BusinessLogic;
using AlisverisLab.Core.DataAccess;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
		public EntityResult AddProduct(Product product);
		public EntityResult UpdateProduct(Product product);

	}
}
