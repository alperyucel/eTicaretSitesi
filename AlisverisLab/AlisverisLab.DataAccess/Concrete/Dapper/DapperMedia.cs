using AlisverisLab.Core.DataAccess;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.Dapper
{
    public class DapperMedia : IMediaDAL
    {
        public bool Add(Media entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Media entity)
        {
            throw new NotImplementedException();
        }
 

        public IEnumerable<Media> GetAll(Expression<Func<Media, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Media GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int MediaAdd(Media media)
        {
            throw new NotImplementedException();
        }

        public bool Update(Media entity)
        {
            throw new NotImplementedException();
        }
    }
}
