using AlisverisLab.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Entity.POCO
{
    public class Order : BaseEntity
    {
        public int AppUserId { get; set; }
        public int EmployeeId { get; set; }
        public int ShipperId { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Shipper Shipper { get; set; }

    }
}
