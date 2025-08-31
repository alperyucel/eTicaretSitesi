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

namespace AlisverisLab.BusinessLogic.Concrete
{
    public class LogManager : ILogService
    {
        ILogDAL logDAL;
        public LogManager(ILogDAL logDAL)
        {
            this.logDAL = logDAL;
        }
        public EntityResult Add(Log entity)
        {
            try
            {
                bool result = logDAL.Add(entity);
                if (result)
                    return new EntityResult { Data = result, IsSuccess = result };
                else
                    return new EntityResult { Data = result, IsSuccess = result };
            }
            catch(Exception ex)
            {
                return new EntityResult { Data = false, IsSuccess = false, ErrorMessage= ex.Message};

            }
        }

        public EntityResult Delete(Log entity)
        {
            try
            {
                bool result = logDAL.Delete(entity);
                if (result)
                    return new EntityResult { Data = result, IsSuccess = result };
                else
                    return new EntityResult { Data = result, IsSuccess = result };
            }
            catch (Exception ex)
            {
                return new EntityResult { Data = false, IsSuccess = false, ErrorMessage = ex.Message };

            }
        }

        public EntityResult GetAll(Expression<Func<Log, bool>> expression = null, Sortable sortable = Sortable.ASC, params string[] includes)
        {
            try
            {
                List<Log> result = logDAL.GetAll(expression,sortable,includes).ToList();
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message };

            }
        }

        public EntityResult GetById(int id)
        {
            try
            {
                Log result = logDAL.GetById(id);
                if (result != null)
                    return new EntityResult { Data = result, IsSuccess = true };
                else
                    return new EntityResult { IsSuccess = false };
            }
            catch (Exception ex)
            {
                return new EntityResult { IsSuccess = false, ErrorMessage = ex.Message };

            }
        }

        public EntityResult Update(Log entity)
        {
            try
            {
                bool result = logDAL.Update(entity);
                if (result)
                    return new EntityResult { Data = result, IsSuccess = result };
                else
                    return new EntityResult { Data = result, IsSuccess = result };
            }
            catch (Exception ex)
            {
                return new EntityResult { Data = false, IsSuccess = false, ErrorMessage = ex.Message };

            }
        }
    }
}
