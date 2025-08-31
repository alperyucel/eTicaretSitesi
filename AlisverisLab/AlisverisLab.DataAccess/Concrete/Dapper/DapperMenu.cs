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
    public class DapperMenu : IMenuDAL
    {
        public bool Add(Menu entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Menu entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> GetAll(Expression<Func<Menu, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Menu GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Menu entity)
        {
            throw new NotImplementedException();
        }

		public bool UpdateMenu(Menu menu)
		{
			throw new NotImplementedException();
		}
	}
}
