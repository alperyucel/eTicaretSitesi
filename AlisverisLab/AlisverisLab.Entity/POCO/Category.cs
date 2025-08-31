using AlisverisLab.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Entity.POCO
{
    public class Category : BaseEntity, IDisposable
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        public void Dispose() => GC.SuppressFinalize(this);        
    }
}
