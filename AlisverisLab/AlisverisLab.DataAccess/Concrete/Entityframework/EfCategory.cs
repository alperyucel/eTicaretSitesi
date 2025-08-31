using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
	public class EfCategory : EfRepository<Category>, ICategoryDAL
	{
		public bool Updatecategory(Category entity)
		{
			var existingCategory = db.Categories.Find(entity.Id);
			if (existingCategory != null)
			{
				existingCategory.CategoryName = entity.CategoryName;
				existingCategory.CategoryDescription = entity.CategoryDescription;
				db.SaveChanges();
			}

			return true;
		}
	}
}
