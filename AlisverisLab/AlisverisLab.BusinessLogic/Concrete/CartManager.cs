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
    public class CartManager : ICartService
    {
        ICartDAL cartDal;
        ILogService logService;
        public CartManager(ICartDAL _cartDal, ILogService logService)
        {
            cartDal = _cartDal;
            this.logService = logService;
        }
        public EntityResult Add(Cart entity)
        {
            try
            {
                bool result = cartDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Sepete Ürün Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Sepete Ekleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Sepete Ürün Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Sepete Ekleme İşlemi Başarısız" };
                }
                     
            }
            catch(Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sepete Ekleme İşlemi Başarısız, Sepete Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult CartAdd(Cart cart)
        {
            try
            {
                bool result = cartDal.CartAdd(cart);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Sepete Ürün Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Sepete Ekleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Sepete Ürün Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Sepete Ekleme İşlemi Başarısız" };
                }

            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sepete Ekleme İşlemi Başarısız, Sepete Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Delete(Cart entity)
        {
            try
            {
                bool result = cartDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Sepetten Ürün Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Sepetten Silme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Sepetten Ürün Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Sepetten Silme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sepetten Silme İşlemi Başarısız, Sepetten Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult DeleteCartById(int id)
        {
            try
            {
                bool result = cartDal.DeleteCartById(id);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Sepetten Ürün Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Sepetten Silme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Sepetten Ürün Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Sepetten Silme İşlemi Başarısız" };
                }

            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sepetten Silme İşlemi Başarısız, Sepetten Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<Cart,bool>> expression = null,Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<Cart> result = cartDal.GetAll(expression,sortable,includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sepete Verileri Alınma İşlemi Başarısız, Sepet Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                Cart result = cartDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sepete Ekleme İşlemi Başarısız, Sepete Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(Cart entity)
        {
            try
            {
                bool result = cartDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Sepetteki Ürün Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Sepet Güncelleme İşlemi Başarılı" };
                }

                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Sepetteki Ürün Güncellenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Sepet Güncelleme İşlemi Başarısız" };
                }
                    
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Sepet Güncelleme İşlemi Başarısız, Sepet Güncellenirken Bir Hata Oluştu!" };
            }
        }
    }
}
