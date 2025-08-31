using AlisverisLab.BusinessLogic.Abstract;
using AlisverisLab.Core.BusinessLogic;
using AlisverisLab.Core.DataAccess;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.Entity.DTO;
using AlisverisLab.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.Concrete.Entityframework
{
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDAL OrderDetailDal;
        ILogService logService;
        public OrderDetailManager(IOrderDetailDAL _OrderDetailDal, ILogService logService)
        {
            OrderDetailDal = _OrderDetailDal;
            this.logService = logService;
        }
        public EntityResult Add(OrderDetail entity)
        {
            try
            {
                bool result = OrderDetailDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Sipariş Detayı Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Sipariş Detayı Ekleme İşlemi Başarılı" };
                }
                    
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Sipariş Detayı Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Sipariş Detayı Ekleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Detayı Ekleme İşlemi Başarısız, Sipariş Detayı Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Delete(OrderDetail entity)
        {
            try
            {
                bool result = OrderDetailDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Sipariş Detayı Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Sipariş Detayı Silme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Sipariş Detayı Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Sipariş Detayı Silme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Detayı Silme İşlemi Başarısız, Sipariş Detayı Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<OrderDetail, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<OrderDetail> result = OrderDetailDal.GetAll(expression, sortable, includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Detayı Verileri Alınma İşlemi Başarısız, Sipariş Detayı Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                OrderDetail result = OrderDetailDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Detayı Ekleme İşlemi Başarısız, Sipariş Detayı Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult ListOrderDetail(int appUserId)
        {
            try
            {
                List<OrderDetailDTO> result = OrderDetailDal.ListOrderDetail(appUserId).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });

                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Detayı Verileri Alınma İşlemi Başarısız, Sipariş Detayı Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(OrderDetail entity)
        {
            try
            {
                bool result = OrderDetailDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Sipariş Detayı Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Sipariş Detayı Güncelleme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Sipariş Detayı Güncellenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Sipariş Detayı Güncelleme İşlemi Başarısız" };
                }
                    
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sipariş Detayı Güncelleme İşlemi Başarısız, Sipariş Detayı Güncellenirken Bir Hata Oluştu!" };
            }
        }
    }
}
