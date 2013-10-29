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
    /// <summary>
    /// UserInfo业务逻辑
    /// </summary>
    public class UserInfoService : BaseService<UserInfo>,IUserInfoService
    {
        //重写抽象方法，设置当前仓库为User
        public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.UserInfoRepository;
        }

        ////访问DAL实现CRUD
        //private IUserInfoRepository _userInfoRepository = RepositoryFactory.UserInfoRepository;

        //public UserInfo AddUserInfo(UserInfo userInfo)
        //{
        //    return _userInfoRepository.AddEntity(userInfo);
        //}

        //public bool UpdateUserInfo(UserInfo userInfo)
        //{
        //    return _userInfoRepository.UpdateEntity(userInfo);
        //}
        
    }
}
