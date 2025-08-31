using AlisverisLab.Core.DataAccess;
using AlisverisLab.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Core.BusinessLogic
{
    public interface IGenericService <TEntity> where TEntity : class,IBaseEntity,new()
    {
        EntityResult Add(TEntity entity);
        EntityResult Update(TEntity entity);
        EntityResult Delete(TEntity entity);
        EntityResult GetAll(Expression<Func<TEntity,bool>> expression = null,Sortable sortable = Sortable.ASC, params string[] includes);
        EntityResult GetById(int id);
    }
}