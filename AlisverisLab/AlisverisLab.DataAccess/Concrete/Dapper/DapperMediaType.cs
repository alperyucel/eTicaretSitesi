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
    public class DapperMediaType : IMediaTypeDAL
    {
        public bool Add(MediaType entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(MediaType entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MediaType> GetAll(Expression<Func<MediaType, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public MediaType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(MediaType entity)
        {
            throw new NotImplementedException();
        }
    }
}
