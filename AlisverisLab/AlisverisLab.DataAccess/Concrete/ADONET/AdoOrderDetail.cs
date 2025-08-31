using AlisverisLab.Core.DataAccess;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.ADONET
{
    public class AdoOrderDetail : IOrderDetailDAL
    {
        public bool Add(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
 
        public IEnumerable<OrderDetail> GetAll(Expression<Func<OrderDetail, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetailDTO> ListOrderDetail(int appUserId)
        {
            throw new NotImplementedException();
        }

        public bool Update(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
