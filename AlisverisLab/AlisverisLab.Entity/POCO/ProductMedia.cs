using AlisverisLab.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Entity.POCO
{
    public class ProductMedia : IBaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MediaId { get; set; }

        public virtual Media Media { get; set; }
        public virtual Product Product { get; set; }
    }
}
