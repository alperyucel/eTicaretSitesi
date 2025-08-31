using AlisverisLab.Core.DataAccess;
using AlisverisLab.Core.Entity;
using AlisverisLab.DataAccess.DbContext;
using AlisverisLab.Entity.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class,IBaseEntity,new()
        
    {
        protected readonly AlisverisLabDbContext db = new AlisverisLabDbContext();

        public bool Add(TEntity entity)
        {
            db.Add(entity);
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(TEntity entity)
        {
            db.Update(entity);
            return db.SaveChanges() > 0 ? true: false;
        }


		public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
		{
			IQueryable<TEntity> entityQuery = db.Set<TEntity>();


			if (expression != null)
				entityQuery = db.Set<TEntity>().Where(expression);


			for (int i = 0; i < includes.Length; i++)
			{
				entityQuery = entityQuery.Include(includes[i]);
			}

			if (sortable == Sortable.ASC)
				entityQuery = entityQuery.OrderBy(x => x.Id);
			else
				entityQuery = entityQuery.OrderByDescending(x => x.Id);

			return entityQuery.ToList();
		}

		public TEntity GetById(int id)
        {

            var a = GetAll();
            return db.Set<TEntity>().Find(id);
        }

		public bool Update(TEntity entity)
		{
			db.Update(entity);
			return db.SaveChanges() > 0 ? true : false;
		}


	}
}
