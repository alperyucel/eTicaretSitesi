using AlisverisLab.Core.BusinessLogic;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.BusinessLogic.Abstract
{
    public interface IMenuService : IGenericService<Menu>
    {
		public EntityResult UpdateMenu(Menu menu);

	}
}
