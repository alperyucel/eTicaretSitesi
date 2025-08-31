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
    public class DapperProductMedia : IProductMediaDAL
    {
        public bool Add(ProductMedia entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ProductMedia entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteMedia(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductMedia> GetAll(Expression<Func<ProductMedia, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public ProductMedia GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductMedia entity)
        {
            throw new NotImplementedException();
        }
    }
}
