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
    public class ProductMediaManager : IProductMediaService
    {
        IProductMediaDAL ProductMediaDal;
        ILogService logService;
        public ProductMediaManager(IProductMediaDAL _ProductMediaDal,ILogService logService)
        {
            ProductMediaDal = _ProductMediaDal;
            this.logService = logService;
        }
        public EntityResult Add(ProductMedia entity)
        {
            try
            {
                bool result = ProductMediaDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Ürün Medyası Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Medyası Ekleme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Ürün Medyası Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Ürün Medyası Ekleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Medyası Ekleme İşlemi Başarısız, Ürün Medyası Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Delete(ProductMedia entity)
        {
            try
            {
                bool result = ProductMediaDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Ürün Medyas Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Medyas Silme İşlemi Başarılı" };
                }
                    
                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Ürün Medyası Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Ürün Medya Silme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Medya Silme İşlemi Başarısız, Ürün Medya Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult DeleteMedia(int productId)
        {
            try
            {
                ProductMediaDal.DeleteMedia(productId);

                logService.Add(new Log { LogTypeId = 3, Message = $"Ürün  Medya Silindi!" });

                return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Medya Silme İşlemi Başarılı" };

            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });

                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Medya Silme İşlemi Başarısız, Ürün Medya Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<ProductMedia, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<ProductMedia> result = ProductMediaDal.GetAll(expression, sortable, includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Medya Verileri Alınma İşlemi Başarısız, Ürün Medya Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                ProductMedia result = ProductMediaDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Medya Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(ProductMedia entity)
        {
            try
            {
                bool result = ProductMediaDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Ürün Medyas Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Medya Güncelleme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Ürün Medyas Güncellenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Ürün Medya Güncelleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Medya Güncelleme İşlemi Başarısız, Ürün Medya Güncellenirken Bir Hata Oluştu!" };
            }
        }
    }
}
