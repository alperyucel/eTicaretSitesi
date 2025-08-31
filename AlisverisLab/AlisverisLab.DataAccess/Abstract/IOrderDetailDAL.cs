using AlisverisLab.Core.DataAccess;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Abstract
{
    public interface IOrderDetailDAL : IRepository<OrderDetail>
    {
        List<OrderDetailDTO> ListOrderDetail(int appUserId);
    }
}
