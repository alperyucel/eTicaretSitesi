using AlisverisLab.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Entity.POCO
{
    public class Media : BaseEntity
    {
        public string Path { get; set; }
        public double? Size { get; set; }
        public int MediaTypeId { get; set; }

        public virtual MediaType MediaType { get; set; }
        public virtual ICollection<ProductMedia> ProductMedias { get; set; }
    }
}
