using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
    public class EfMedia : EfRepository<Media>, IMediaDAL
    {
        public int MediaAdd(Media media)
        {
            db.Add(media);
            db.SaveChanges();
            return media.Id;
        }
    }
}
