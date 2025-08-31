using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
	public class EfMenu : EfRepository<Menu>, IMenuDAL
	{
		public bool UpdateMenu(Menu menu)
		{
			var existingMenu = db.Menus.Find(menu.Id);
			if (existingMenu != null)
			{
				existingMenu.Title = menu.Title;
				existingMenu.Icon = menu.Icon;
				existingMenu.AreaName = menu.AreaName;
				existingMenu.ControllerName = menu.ControllerName;
				existingMenu.ActionName = menu.ActionName;
				existingMenu.OrderNumber = menu.OrderNumber;
				db.SaveChanges();
			}

			return true;
		}
	}
}
