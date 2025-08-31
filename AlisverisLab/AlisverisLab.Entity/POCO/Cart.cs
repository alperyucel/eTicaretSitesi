using AlisverisLab.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Entity.POCO
{
    public class Cart : BaseEntity
    {
        public int AppUserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }


        public virtual AppUser AppUser { get; set; }
        public virtual Product Product { get; set; }
    }
}
