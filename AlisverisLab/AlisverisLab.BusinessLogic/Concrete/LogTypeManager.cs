using AlisverisLab.BusinessLogic.Abstract;
using AlisverisLab.Core.BusinessLogic;
using AlisverisLab.Core.DataAccess;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.POCO;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace AlisverisLab.BusinessLogic.Concrete
{
    public class LogTypeManager : ILogTypeService
    {
        ILogTypeDAL logTypeDal;
        ILogService logService;
        public LogTypeManager(ILogTypeDAL logTypeDal, ILogService logService)
        {
            this.logTypeDal = logTypeDal;
            this.logService = logService;
        }
        public EntityResult Add(LogType entity)
        {
            try
            {
                bool result = logTypeDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"{entity.LogTypeName} İsimli Log Türü Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Log Türü Eklendi" };
                }
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"{entity.LogTypeName} İsimli Log Türü Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Log Türü Eklenemedi" };
                }
            }
            catch(Exception e)
            {
                logService.Add(new Log { LogTypeId = 4, Message = e.Message });
                return new EntityResult { Data = false, IsSuccess = false, Message = "Log Türü Eklenemedi, Hata Oluştu!" };
            }
        }

        public EntityResult Delete(LogType entity)
        {
            try
            {
                bool result = logTypeDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"{entity.LogTypeName} İsimli Log Türü Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Log Türü Silindi." };
                }
                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"{entity.LogTypeName} İsimli Log Türü Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Log Türü Silinemedi." };
                }
            }
            catch (Exception e)
            {
                logService.Add(new Log { LogTypeId = 4, Message = e.Message });
                return new EntityResult { Data = false, IsSuccess = false, Message = "Log Türü Silinemedi, Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<LogType, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<LogType> data = logTypeDal.GetAll(expression,sortable,includes).ToList();
                if (data != null && data.Count>0)
                {
                     
                    return new EntityResult { Data = data, IsSuccess = true};
                }
                else
                {
                    
                    return new EntityResult { IsSuccess = false, Message = "Veri Bulunamadı." };
                }
            }
            catch (Exception e)
            {
                logService.Add(new Log { LogTypeId = 4, Message = e.Message });
                return new EntityResult { Data = false, IsSuccess = false, Message = "Veri Çekilirken Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                LogType data = logTypeDal.GetById(id);
                if (data != null)
                {

                    return new EntityResult { Data = data, IsSuccess = true };
                }
                else
                {

                    return new EntityResult { IsSuccess = false, Message = "Veri Bulunamadı." };
                }
            }
            catch (Exception e)
            {
                logService.Add(new Log { LogTypeId = 4, Message = e.Message });
                return new EntityResult { Data = false, IsSuccess = false, Message = "Veri Çekilirken Hata Oluştu!" };
            }
        }

        public EntityResult Update(LogType entity)
        {
            try
            {
                bool result = logTypeDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"{entity.LogTypeName} İsimli Log Türü Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true };
                }
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"{entity.LogTypeName} İsimli Log Türü Güncellenemedi." });
                    return new EntityResult { IsSuccess = false, Message = "Veri Validasyona Uygun Değildir." };
                }
            }
            catch (Exception e)
            {
                logService.Add(new Log { LogTypeId = 4, Message = e.Message });
                return new EntityResult { Data = false, IsSuccess = false, Message = "Veri Güncellenirken Bir Hata Oluştu!" };
            }
        }
    }
}
