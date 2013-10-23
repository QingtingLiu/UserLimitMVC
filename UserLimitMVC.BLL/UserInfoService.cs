using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.DAL;
using UserLimitMVC.IDAL;
using UserLimitMVC.Model;

namespace UserLimitMVC.BLL
{
    /// <summary>
    /// UserInfo业务逻辑
    /// </summary>
    public class UserInfoService
    {
        //访问DAL实现CRUD
        private IUserInfoRepository _userInfoRepository = RepositoryFactory.UserInfoRepository;

        public UserInfo AddUserInfo(UserInfo userInfo)
        {
            return _userInfoRepository.AddEntity(userInfo);
        }

        public bool UpdateUserInfo(UserInfo userInfo)
        {
            return _userInfoRepository.UpdateEntity(userInfo);
        }
    }
}
