using AlisverisLab.BusinessLogic.Abstract;
using AlisverisLab.Core.BusinessLogic;
using AlisverisLab.Core.DataAccess;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace AlisverisLab.BusinessLogic.Concrete
{
    public class MenuManager : IMenuService
    {
        IMenuDAL MenuDal;
        ILogService logService;
        public MenuManager(IMenuDAL _MenuDAL, ILogService logService)
        {
            MenuDal = _MenuDAL;
            this.logService = logService;
        }
        public EntityResult Add(Menu entity)
        {
            try
            {
                bool result = MenuDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Menü eklendi!" });

                    return new EntityResult { Data = true, IsSuccess = true, Message = "Menü Ekleme İşlemi Başarılı" };
                }
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Menü eklenemedi!" });

                    return new EntityResult { Data = false, IsSuccess = false, Message = "Menü Ekleme İşlemi Başarısız" };
                }
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });

                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Menü Ekleme İşlemi Başarısız, Menü Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Delete(Menu entity)
        {
            try
            {
                bool result = MenuDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Menü silindi!" });

                    return new EntityResult { Data = true, IsSuccess = true, Message = "Menü Silme İşlemi Başarılı" };
                }
                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Menü silinemedi!" });

                    return new EntityResult { Data = false, IsSuccess = false, Message = "Menü Silme İşlemi Başarısız" };
                }
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });

                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Menü Silme İşlemi Başarısız, Menü Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<Menu, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<Menu> result = MenuDal.GetAll(expression, sortable, includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });

                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Menü Verileri Alınma İşlemi Başarısız, Menü Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                Menu result = MenuDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });


                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Menü çekme İşlemi Başarısız, Menü çekilirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(Menu entity)
        {
            try
            {
                bool result = MenuDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Menü güncellendi!" });

                    return new EntityResult { Data = true, IsSuccess = true, Message = "Menü Güncelleme İşlemi Başarılı" };
                }
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Menü Güncellenemedi!" });

                    return new EntityResult { Data = false, IsSuccess = false, Message = "Menü Güncelleme İşlemi Başarısız" };
                }
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });

                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Menü Güncelleme İşlemi Başarısız, Menü Güncellenirken Bir Hata Oluştu!" };
            }
        }

		public EntityResult UpdateMenu(Menu menu)
		{
			try
			{
				bool result = MenuDal.UpdateMenu(menu);
				if (result)
				{
					logService.Add(new Log { LogTypeId = 2, Message = $"Menü güncellendi!" });

					return new EntityResult { Data = true, IsSuccess = true, Message = "Menü Güncelleme İşlemi Başarılı" };
				}
				else
				{
					logService.Add(new Log { LogTypeId = 6, Message = $"Menü Güncellenemedi!" });

					return new EntityResult { Data = false, IsSuccess = false, Message = "Menü Güncelleme İşlemi Başarısız" };
				}
			}
			catch (Exception ex)
			{
				logService.Add(new Log { LogTypeId = 4, Message = ex.Message });

				return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Menü Güncelleme İşlemi Başarısız, Menü Güncellenirken Bir Hata Oluştu!" };
			}
		}
	}
}
