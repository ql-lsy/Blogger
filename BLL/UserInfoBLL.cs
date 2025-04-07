using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.BLL
{
    public class UserInfoBLL
    {
        public static Object SignInBLL()
        {
            return DAL.UserInfoDAL.SingInDAL();
        }
        public static Object LoginBLL()
        {
            return DAL.UserInfoDAL.LoginDAL();
        }
        public static Object LoginBLL(string zcsjh)
        {
            return DAL.UserInfoDAL.LoginDAL(zcsjh);
        }
        public static Object SelectALLUserInfoBLL()
        {
            return DAL.UserInfoDAL.SelectALLUserInfoDAL();
        }
    }
}