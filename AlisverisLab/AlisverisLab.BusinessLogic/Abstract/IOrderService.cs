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
    public interface IOrderService : IGenericService<Order>
    {
        EntityResult CompleteOrder(int appUserId, string address, string cityName, string country, string postalCode);

        EntityResult LatestOrder(int appUserId);
    }
}
