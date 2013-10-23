using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLimitMVC.BLL
{
    public abstract class BaseService<T> where T : class,new()
    {
        public IDAL.IBaseRepository<T> CurrentRepository { get; set; }

        public BaseService() 
        {
            SetCurrentRepository();
        }

        public abstract SetCurrentRepository();

        public T AddEntity(T entity)
        {
            return CurrentRepository.AddEntity(entity);
        }
    }
}
