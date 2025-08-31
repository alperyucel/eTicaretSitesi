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

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
    public class MediaManager : IMediaService
    {
        IMediaDAL MediaDal;
        ILogService logService;
        public MediaManager(IMediaDAL _MediaDal, ILogService logService)
        {
            MediaDal = _MediaDal;
            this.logService = logService;
        }
        public EntityResult Add(Media entity)
        {
            try
            {
                bool result = MediaDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Medya Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Medya Ekleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Medya Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Medya Ekleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Medya Ekleme İşlemi Başarısız, Medya Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Delete(Media entity)
        {
            try
            {
                bool result = MediaDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Medya Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Medya Silme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Medya Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Medya Silme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Medya Silme İşlemi Başarısız, Medya Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<Media, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<Media> result = MediaDal.GetAll(expression, sortable, includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Medya Verileri Alınma İşlemi Başarısız, Medya Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                Media result = MediaDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Medya Ekleme İşlemi Başarısız, Medya Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult MediaAdd(Media media)
        {
            try
            {
                int result = MediaDal.MediaAdd(media);
                if (result > 0)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Medya Eklendi!" });

                    return new EntityResult { Data = result, IsSuccess = true, Message = "Medya Ekleme İşlemi Başarılı" };
                }
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Medya Eklenemedi!" });

                    return new EntityResult { Data = result, IsSuccess = false, Message = "Medya Ekleme İşlemi Başarısız" };
                }
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });

                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Medya Ekleme İşlemi Başarısız, Medya Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(Media entity)
        {
            try
            {
                bool result = MediaDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Medya Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Medya Güncelleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Medya Güncellenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Medya Güncelleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Medya Güncelleme İşlemi Başarısız, Medya Güncellenirken Bir Hata Oluştu!" };
            }
        }
    }
}
