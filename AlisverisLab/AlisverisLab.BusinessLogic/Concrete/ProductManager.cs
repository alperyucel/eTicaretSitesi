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
    public class ProductManager : IProductService
    {
        IProductDAL ProductDal;
        ILogService logService;
        public ProductManager(IProductDAL _ProductDal,ILogService logService)
        {
            ProductDal = _ProductDal;
            this.logService = logService;
        }
        public EntityResult Add(Product entity)
        {
            try
            {
                bool result = ProductDal.Add(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 1, Message = $"Ürün Eklendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Ekleme İşlemi Başarılı" };
                }
                    
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Ürün Eklenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Ürün Ekleme İşlemi Başarısız" };
                }
                    
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Ekleme İşlemi Başarısız, Ürün Eklenirken Bir Hata Oluştu!" };
            }
        }

		public EntityResult AddProduct(Product product)
		{
			try
			{
				bool result = ProductDal.AddProduct(product);
				if (result)
				{
					logService.Add(new Log { LogTypeId = 1, Message = $"Ürün Eklendi." });
					return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Ekleme İşlemi Başarılı" };
				}

				else
				{
					logService.Add(new Log { LogTypeId = 6, Message = $"Ürün Eklenemedi." });
					return new EntityResult { Data = false, IsSuccess = false, Message = "Ürün Ekleme İşlemi Başarısız" };
				}

			}
			catch (Exception ex)
			{
				logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
				return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Ekleme İşlemi Başarısız, Ürün Eklenirken Bir Hata Oluştu!" };
			}
		}

		public EntityResult Delete(Product entity)
        {
            try
            {
                bool result = ProductDal.Delete(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 3, Message = $"Ürün Silindi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Silme İşlemi Başarılı" };
                }
                    
                else
                {
                    logService.Add(new Log { LogTypeId = 7, Message = $"Ürün Silinemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Ürün Silme İşlemi Başarısız" };
                }
                     
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Silme İşlemi Başarısız, Ürün Silinirken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetAll(Expression<Func<Product, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<Product> result = ProductDal.GetAll(expression, sortable, includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message});
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Verileri Alma İşlemi Başarısız, Ürün Verileri Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                Product result = ProductDal.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Alınırken Bir Hata Oluştu!" };
            }
        }

        public EntityResult Update(Product entity)
        {
            try
            {
                bool result = ProductDal.Update(entity);
                if (result)
                {
                    logService.Add(new Log { LogTypeId = 2, Message = $"Ürün Güncellendi." });
                    return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Güncelleme İşlemi Başarılı" };
                }
                     
                else
                {
                    logService.Add(new Log { LogTypeId = 6, Message = $"Ürün Güncellenemedi." });
                    return new EntityResult { Data = false, IsSuccess = false, Message = "Ürün Güncelleme İşlemi Başarısız" };
                }
                    
            }
            catch (Exception ex)
            {
                logService.Add(new Log { LogTypeId = 4, Message =  ex.Message });
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Güncelleme İşlemi Başarısız, Ürün Güncellenirken Bir Hata Oluştu!" };
            }
        }

		public EntityResult UpdateProduct(Product product)
		{
			try
			{
				bool result = ProductDal.UpdateProduct(product);
				if (result)
				{
					logService.Add(new Log { LogTypeId = 2, Message = $"Ürün Güncellendi." });
					return new EntityResult { Data = true, IsSuccess = true, Message = "Ürün Güncelleme İşlemi Başarılı" };
				}

				else
				{
					logService.Add(new Log { LogTypeId = 6, Message = $"Ürün Güncellenemedi." });
					return new EntityResult { Data = false, IsSuccess = false, Message = "Ürün Güncelleme İşlemi Başarısız" };
				}

			}
			catch (Exception ex)
			{
				logService.Add(new Log { LogTypeId = 4, Message = ex.Message });
				return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message, Message = "Ürün Güncelleme İşlemi Başarısız, Ürün Güncellenirken Bir Hata Oluştu!" };
			}
		}
	}
}
