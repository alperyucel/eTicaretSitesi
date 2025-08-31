using AlisverisLab.Core.DataAccess;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.Dapper
{
    public class DapperProduct : IProductDAL
    {
        public bool Add(Product entity)
        {
            throw new NotImplementedException();
        }
        

		public bool AddProduct(Product product)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Product entity)
        {
            throw new NotImplementedException();
        }
 
        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            throw new NotImplementedException();
        }

		public bool UpdateProduct(Product product)
		{
			throw new NotImplementedException();
		}
	}
}
