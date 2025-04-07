using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.BLL
{
    public class Seek_helpBLL
    {
        public static Object LoginBLL()
        {
            return DAL.Seek_helpDAL.LoginDAL();
        }
        public static Object NameBLL()
        {
            return DAL.Seek_helpDAL.NameDAL();
        }
        public static Object URLBLL()
        {
            return DAL.Seek_helpDAL.URLDAL();
        }
        public static Object MenberBLL()
        {
            return DAL.Seek_helpDAL.MemberDAL();
        }
    }
}