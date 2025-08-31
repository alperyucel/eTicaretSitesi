using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
	public class EfOrder : EfRepository<Order>, IOrderDAL
	{
        public void CompleteOrder(int appUserId, string address, string cityName, string country, string postalCode)
        {
            var cartList = db.Carts.Include("Product").Where(x => x.AppUserId == appUserId && x.Active == true).ToList();

            if (cartList.Count > 0)
            {
                var order = db.Orders.Add(new Order { AppUserId = appUserId, Address = address, CityName = cityName, Country = country, PostalCode = postalCode, ShipperId = 1, EmployeeId = 1 });
                db.SaveChanges();

                for (int i = 0; i < cartList.Count; i++)
                {
                    db.OrderDetails.Add(new OrderDetail { OrderId = order.Entity.Id, Discount = 0, Price = cartList[i].Product.Price, ProductId = cartList[i].ProductId, Quantity = cartList[i].Quantity });
                }
                if (db.SaveChanges() > 0)
                {
                    for (int i = 0; i < cartList.Count; i++)
                    {
                        cartList[i].Active = false;
                    }

                    db.Carts.UpdateRange(cartList);
                    db.SaveChanges();
                }

            }
        }

        public (string, double) LatestOrder(int appUserId)
        {
            var order = (from od in db.OrderDetails
                         join o in db.Orders
                         on od.OrderId equals o.Id
                         where o.AppUserId == appUserId && o.Active == true && o.Id == db.Orders.Where(x => x.AppUserId == appUserId).Select(x => x.Id).Max()
                         select od
                        ).ToList();


            return (order.FirstOrDefault().OrderId.ToString(), order.Sum(x => x.Price * x.Quantity));
        }
    }
}
