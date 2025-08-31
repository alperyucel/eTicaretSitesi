using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
    public class EfProductMedia : EfRepository<ProductMedia>, IProductMediaDAL
    {
        public void DeleteMedia(int productId)
        {
            db.ProductMedias.RemoveRange(db.ProductMedias.Where(x => x.ProductId == productId).ToList());
            db.SaveChanges();
        }
    }
}
