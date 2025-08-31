using AlisverisLab.Core.DataAccess;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Abstract
{
    public interface IOrderDAL : IRepository<Order>
    {
        void CompleteOrder(int appUserId, string address, string cityName, string country, string postalCode);

        (string, double) LatestOrder(int appUserId);
    }
}
