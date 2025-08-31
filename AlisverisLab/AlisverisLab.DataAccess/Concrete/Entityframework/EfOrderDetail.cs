using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
    public class EfOrderDetail : EfRepository<OrderDetail>, IOrderDetailDAL
    {
        public List<OrderDetailDTO> ListOrderDetail(int appUserId)
        {
            return (from od in db.OrderDetails
                    join o in db.Orders
                    on od.OrderId equals o.Id
                    join p in db.Products
                    on od.ProductId equals p.Id
                    where od.Active == true && o.Active == true && p.Active == true && o.AppUserId == appUserId
                    select new OrderDetailDTO
                    {
                        Id = od.Id,
                        ImagePath = db.ProductMedias.Include("Media").Where(x => x.ProductId == p.Id).Select(x => x.Media.Path).FirstOrDefault(),
                        ProductId = p.Id,
                        Price = od.Price,
                        ProductName = p.ProductName,
                        Quantity = od.Quantity
                    }).ToList();
        }
    }
}
