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
    public class DapperCart : ICartDAL
    {
        public bool Add(Cart entity)
        {
            throw new NotImplementedException();
        }

        public bool CartAdd(Cart cart)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Cart entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCartById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cart> GetAll(Expression<Func<Cart, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Cart GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
