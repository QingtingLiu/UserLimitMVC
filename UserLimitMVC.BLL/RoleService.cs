using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.DAL;
using UserLimitMVC.IBLL;
using UserLimitMVC.IDAL;
using UserLimitMVC.Model;

namespace UserLimitMVC.BLL
{
    class RoleService : BaseService<Role>,IRoleService
    {
        //重写抽象方法，设置当前仓库为Role
        public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.RoleRepository;
        }
    }
}
