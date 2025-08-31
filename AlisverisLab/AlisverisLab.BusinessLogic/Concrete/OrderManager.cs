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
    public class OrderManager : IOrderService
    {
        IOrderDAL OrderDal;
        ILogService logService;
        public OrderManager(IOrderDAL _OrderDal, ILogService logService)
        {
            OrderDal = _OrderDal;
            this.logService = logService;
        }
        public EntityResult Add(Order entity)
        {
            try
            {
                bool result = OrderDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Sipariş Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Sipariş Ekleme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Sipariş Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Sipariş Ekleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Ekleme İşlemi Başarısız, Sipariş Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult CompleteOrder(int appUserId, string address, string cityName, string country, string postalCode)
        {
            try
            {
                OrderDal.CompleteOrder(appUserId, address, cityName, country, postalCode);
                logService.Add(new Log { LogTypeId = 1, Message = $"Sipariş Oluşturuldu!" });

                return new EntityResult { Data = true, IsSuccess = true, Message = "Sipariş Oluşturulamadı!" };

            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });

                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Oluşturma İşlemi Başarısız, Sipariş Oluşturulurken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Delete(Order entity)
        {
            try
            {
                bool result = OrderDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Sipariş Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Sipariş Silme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Sipariş Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Sipariş Silme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Silme İşlemi Başarısız, Sipariş Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<Order, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<Order> result = OrderDal.GetAll(expression, sortable, includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Verileri Alınma İşlemi Başarısız, Sipariş Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                Order result = OrderDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Ekleme İşlemi Başarısız, Sipariş Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult LatestOrder(int appUserId)
        {
            try
            {
                (string, double) result = OrderDal.LatestOrder(appUserId);
                if (result.Item1 != null && result.Item2 != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });

                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Verileri Alınma İşlemi Başarısız, Sipariş Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(Order entity)
        {
            try
            {
                bool result = OrderDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Sipariş Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Sepet Güncelleme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Sipariş Güncellenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Sepet Güncelleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Güncelleme İşlemi Başarısız, Sipariş Güncellenirken Bir Hata Oluştu!" };
            }
        }
    }
}
