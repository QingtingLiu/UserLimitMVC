﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.IDAL;

namespace UserLimitMVC.DAL
{
    public static class RepositoryFactory
    {
        public static IUserInfoRepository UserInfoRepository
        {
            get { return new UserInfoRepository(); }
        }
    }
}
