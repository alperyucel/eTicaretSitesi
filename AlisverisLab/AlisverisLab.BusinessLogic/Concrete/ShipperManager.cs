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
    public class ShipperManager : IShipperService
    {
        IShipperDAL ShipperDal;
        ILogService logService;
        public ShipperManager(IShipperDAL _ShipperDal,ILogService logService)
        {
            ShipperDal = _ShipperDal;
            this.logService = logService;
        }
        public EntityResult Add(Shipper entity)
        {
            try
            {
                bool result = ShipperDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Gönderici Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Gönderici Ekleme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Gönderici Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Gönderici Ekleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Gönderici Ekleme İşlemi Başarısız, Gönderici Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Delete(Shipper entity)
        {
            try
            {
                bool result = ShipperDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Gönderici Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Gönderici Silme İşlemi Başarılı" };
                }
                    
                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Gönderici Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Gönderici Silme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Gönderici Silme İşlemi Başarısız, Gönderici Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<Shipper, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<Shipper> result = ShipperDal.GetAll(expression, sortable, includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Gönderici Verileri Alma İşlemi Başarısız, Gönderici Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                Shipper result = ShipperDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Gönderici Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(Shipper entity)
        {
            try
            {
                bool result = ShipperDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Gönderici Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Gönderici Güncelleme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Gönderici Güncellenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Gönderici Güncelleme İşlemi Başarısız" };
                }
                    
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Gönderici Güncelleme İşlemi Başarısız, Gönderici Güncellenirken Bir Hata Oluştu!" };
            }
        }
    }
}
