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
    public class DapperLogType : ILogTypeDAL
    {
        public bool Add(LogType entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(LogType entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogType> GetAll(Expression<Func<LogType, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public LogType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(LogType entity)
        {
            throw new NotImplementedException();
        }
    }
}
