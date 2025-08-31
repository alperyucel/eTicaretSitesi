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
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDAL EmployeeDal;
        ILogService logService;
        public EmployeeManager(IEmployeeDAL _EmployeeDal,ILogService logService)
        {
            EmployeeDal = _EmployeeDal;
            this.logService = logService;
        }
        public EntityResult Add(Employee entity)
        {
            try
            {
                bool result = EmployeeDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Personel Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Personel Ekleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Personel Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Personel Ekleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Personel Ekleme İşlemi Başarısız, Personel Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Delete(Employee entity)
        {
            try
            {
                bool result = EmployeeDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Personel Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Personel Silme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Personel Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Personel Silme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Personel Silme İşlemi Başarısız, Personel Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<Employee, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<Employee> result = EmployeeDal.GetAll(expression, sortable, includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Personel Verileri Alma İşlemi Başarısız, Personel Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                Employee result = EmployeeDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Personel Ekleme İşlemi Başarısız, Personel Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(Employee entity)
        {
            try
            {
                bool result = EmployeeDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Personel Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Personel Güncelleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Personel Güncellenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Personel Güncelleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Personel Güncelleme İşlemi Başarısız, Sepet Güncellenirken Bir Hata Oluştu!" };
            }
        }
    }
}
