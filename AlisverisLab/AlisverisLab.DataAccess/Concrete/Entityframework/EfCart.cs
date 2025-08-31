using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
    public class EfCart : EfRepository<Cart>, ICartDAL
    {
        public bool CartAdd(Cart cart)
        {
            Cart result = GetAll(x => x.AppUserId == cart.AppUserId && x.Active == true && x.ProductId == cart.ProductId).FirstOrDefault();

            if (result != null)
            {
                result.Quantity = cart.Quantity;
                return Update(result);
            }
            else
                return Add(cart);
        }

        public bool DeleteCartById(int id)
        {
            Cart cart = GetById(id);
            if (cart != null)
            {
                cart.Active = false;
                return Delete(cart);
            }
            return false;
        }
    }
}
