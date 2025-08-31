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
    public class FavoriteManager : IFavoriteService
    {
        IFavoriteDAL FavoriteDal;
        ILogService logService;
        public FavoriteManager(IFavoriteDAL _FavoriteDal, ILogService logService)
        {
            FavoriteDal = _FavoriteDal;
            this.logService = logService;
        }
        public EntityResult Add(Favorite entity)
        {
            try
            {
                bool result = FavoriteDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Favori Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Favori Ekleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Favori Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Favori Ekleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sepete Ekleme İşlemi Başarısız, Sepete Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Delete(Favorite entity)
        {
            try
            {
                bool result = FavoriteDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Favori Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Favori Silme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Favori Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Favori Silme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Favori Silme İşlemi Başarısız, Favori Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<Favorite, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<Favorite> result = FavoriteDal.GetAll(expression, sortable, includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Favori Verileri Alınma İşlemi Başarısız, Favori Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                Favorite result = FavoriteDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Favori Çekme İşlemi Başarısız, Favori Çekilirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(Favorite entity)
        {
            try
            {
                bool result = FavoriteDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Favori Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Favori Güncelleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Favori Güncellenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Favori Güncelleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Favori Güncelleme İşlemi Başarısız, Favori Güncellenirken Bir Hata Oluştu!" };
            }
        }
    }
}
