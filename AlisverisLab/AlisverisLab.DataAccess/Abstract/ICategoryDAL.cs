using AlisverisLab.Core.DataAccess;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace AlisverisLab.DataAccess.Abstract
{
    public interface ICategoryDAL : IRepository<Category>
    {
		public bool Updatecategory(Category entity);

	}
}
