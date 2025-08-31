using AlisverisLab.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Core.DataAccess
{
    public interface IRepository <TEntity> where TEntity : class,IBaseEntity,new()
    {
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity,bool>> expression = null,Sortable sortable = Sortable.ASC, params string[] includes);
        TEntity GetById(int id);
    }
}
