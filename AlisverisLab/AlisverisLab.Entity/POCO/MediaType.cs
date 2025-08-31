using AlisverisLab.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Entity.POCO
{
    public class MediaType : BaseEntity
    {
        public string Name { get; set; }
        public string SupportedFileExtensions { get; set; }

        public virtual ICollection<Media> Medias { get; set; }
    }
}
