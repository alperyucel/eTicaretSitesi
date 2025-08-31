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
    public class DapperLog : ILogDAL
    {
        public bool Add(Log entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Log entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Log> GetAll(Expression<Func<Log, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Log GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
