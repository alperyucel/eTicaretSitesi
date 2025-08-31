using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
    public class EfProductCategory : EfRepository<ProductCategory>, IProductCategoryDAL
    {
        public void DeleteCategory(int productId)
        {
            db.ProductCategories.RemoveRange(db.ProductCategories.Where(x => x.ProductId == productId).ToList());
            db.SaveChanges();
        }
    }
}
