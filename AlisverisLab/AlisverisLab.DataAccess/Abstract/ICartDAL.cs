using AlisverisLab.Core.DataAccess;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Abstract
{
    public interface ICartDAL : IRepository<Cart>
    {
        //void AktifKullaniciSepetBosalt(AppUser user);

        bool CartAdd(Cart cart);

        bool DeleteCartById(int id);
    }
}
