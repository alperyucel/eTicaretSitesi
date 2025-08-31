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
    public class DapperShipper : IShipperDAL
    {
        public bool Add(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipper> GetAll(Expression<Func<Shipper, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Shipper GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shipper entity)
        {
            throw new NotImplementedException();
        }
    }
}
