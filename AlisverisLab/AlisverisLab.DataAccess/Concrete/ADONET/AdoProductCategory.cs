using AlisverisLab.Core.DataAccess;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.ADONET
{
    public class AdoProductCategory : IProductCategoryDAL
    {
        public bool Add(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAll(Expression<Func<ProductCategory, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
