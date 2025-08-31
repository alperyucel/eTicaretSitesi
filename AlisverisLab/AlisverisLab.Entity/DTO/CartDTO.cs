using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Entity.DTO
{
    public class CartDTO
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ImagePath { get; set; }
        public double? Price { get; set; }
        public int Quantity { get; set; }
        public int AppUserId { get; set; }
        public double? TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}
