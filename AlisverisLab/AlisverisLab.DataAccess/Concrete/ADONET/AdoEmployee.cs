using AlisverisLab.Core.DataAccess;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.ADONET
{
    public class AdoEmployee : IEmployeeDAL
    {
        public bool Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Employee entity)
        {
            throw new NotImplementedException();
        }
 
        public IEnumerable<Employee> GetAll(Expression<Func<Employee, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
