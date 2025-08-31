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

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL CategoryDal;
        ILogService logService;
        public CategoryManager(ICategoryDAL _CategoryDal, ILogService logService)
        {
            CategoryDal = _CategoryDal;
            this.logService = logService;
        }
        public EntityResult Add(Category entity)
        {
            try
            {
                bool result = CategoryDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Kategori Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Kategori Ekleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Kategori Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Kategori Ekleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Kategori Ekleme İşlemi Başarısız, Sepete Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Delete(Category entity)
        {
            try
            {
                bool result = CategoryDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Kategori Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Kategori Silme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Kategori Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Kategori Silme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Kategori Silme İşlemi Başarısız, Kategori Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<Category, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<Category> result = CategoryDal.GetAll(expression, sortable, includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Kategori Verileri Alınma İşlemi Başarısız, Kategori Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                Category result = CategoryDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 3, Message = ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Kategori Ekleme İşlemi Başarısız, Kategori Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(Category entity)
        {
            try
            {
                bool result = CategoryDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Kategori Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Kategori Güncelleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Kategori Güncellenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Kategori Güncelleme İşlemi Başarısız" };
                }
                    
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Kategori Güncelleme İşlemi Başarısız, Kategori Güncellenirken Bir Hata Oluştu!" };
            }
        }

		public EntityResult Updatecategory(Category entity)
		{
			try
			{
				bool result = CategoryDal.Updatecategory(entity);
				if (result)
				{
					logService.Add(new Log { LogTypeId = 2, Message = $"Kategori Güncellendi." });
					return new EntityResult { Data = true, IsSuccess = true, Message = "Kategori Güncelleme İşlemi Başarılı" };
				}

				else
				{
					logService.Add(new Log { LogTypeId = 6, Message = $"Kategori Güncellenemedi." });
					return new EntityResult { Data = false, IsSuccess = false, Message = "Kategori Güncelleme İşlemi Başarısız" };
				}

			}
			catch (Exception ex)
			{
				logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
				return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Kategori Güncelleme İşlemi Başarısız, Kategori Güncellenirken Bir Hata Oluştu!" };
			}
		}
	}
}
