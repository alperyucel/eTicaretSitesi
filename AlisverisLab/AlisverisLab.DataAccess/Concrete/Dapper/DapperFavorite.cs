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
    public class DapperFavorite : IFavoriteDAL
    {
        public bool Add(Favorite entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Favorite entity)
        {
            throw new NotImplementedException();
        }
 

        public IEnumerable<Favorite> GetAll(Expression<Func<Favorite, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Favorite GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Favorite entity)
        {
            throw new NotImplementedException();
        }
    }
}
