using AlisverisLab.BusinessLogic.Abstract;
using AlisverisLab.Core.BusinessLogic;
using AlisverisLab.Core.DataAccess;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
    public class MediaTypeManager : IMediaTypeService
    {
        IMediaTypeDAL MediaTypeDal;
        ILogService logService;
        public MediaTypeManager(IMediaTypeDAL _MediaTypeDal, ILogService logService)
        {
            MediaTypeDal = _MediaTypeDal;
            this.logService = logService;
        }
        public EntityResult Add(MediaType entity)
        {
            try
            {
                bool result = MediaTypeDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Medya Türü Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Medya Türü Ekleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Medya Türü Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Medya Türü Ekleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Medya Türü Ekleme İşlemi Başarısız, Medya Türü Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Delete(MediaType entity)
        {
            try
            {
                bool result = MediaTypeDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Medya Türü Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Medya Türü Silme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Medya Türü Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Medya Türü Silme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Medya Türü Silme İşlemi Başarısız, Medya Türü Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<MediaType, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<MediaType> result = MediaTypeDal.GetAll(expression, sortable, includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Medya Türü Verileri Alınma İşlemi Başarısız, Medya Türü Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                MediaType result = MediaTypeDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Medya Türü Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(MediaType entity)
        {
            try
            {
                bool result = MediaTypeDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Medya Türü Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Medya Türü Güncelleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Medya Türü Güncellenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Medya Türü Güncelleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sepet Güncelleme İşlemi Başarısız, Sepet Güncellenirken Bir Hata Oluştu!" };
            }
        }
    }
}
