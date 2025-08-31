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
    public class ProductCategoryManager : IProductCategoryService
    {
        IProductCategoryDAL ProductCategoryDal;
        ILogService logService;
        public ProductCategoryManager(IProductCategoryDAL _ProductCategoryDal,ILogService logService)
        {
            ProductCategoryDal = _ProductCategoryDal;
            this.logService = logService;
        }
        public EntityResult Add(ProductCategory entity)
        {
            try
            {
                bool result = ProductCategoryDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Ürün Kategori Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Kategori Ekleme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Ürün Kategori Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Ürün Kategori Ekleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Kategori Ekleme İşlemi Başarısız, Ürün Kategori Eklenirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Delete(ProductCategory entity)
        {
            try
            {
                bool result = ProductCategoryDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Ürün Kategori Silimdi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Kategori Silme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Ürün Kategori Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Ürün Kategori Silme İşlemi Başarısız" };
                }
                    
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Kategori Silme İşlemi Başarısız, Ürün Kategori Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult DeleteCategory(int productId)
        {
            try
            {
                ProductCategoryDal.DeleteCategory(productId);

                logService.Add(new Log { LogTypeId = 3, Message = $"Ürün Kategori Silindi!" });

                return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Kategori Silme İşlemi Başarılı" };

            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });

                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Kategori Silme İşlemi Başarısız, Ürün Kategori Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<ProductCategory, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<ProductCategory> result = ProductCategoryDal.GetAll(expression, sortable, includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Kategori Verileri Alınma İşlemi Başarısız, Ürün Kategori Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                ProductCategory result = ProductCategoryDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Kategori Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(ProductCategory entity)
        {
            try
            {
                bool result = ProductCategoryDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Ürün Kategori Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Kategori Güncelleme İşlemi Başarılı" };
                }
                
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Ürün Kategori Güncellenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Ürün Kategori Güncelleme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Kategori Güncelleme İşlemi Başarısız, Ürün Kategori Güncellenirken Bir Hata Oluştu!" };
            }
        }
    }
}
