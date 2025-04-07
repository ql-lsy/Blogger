using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.DAL
{
    public class Seek_helpDAL
    {
        //获取登录的id
        public static Object LoginDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    return u.UserID;
                }
                else
                {
                    return 11111;
                }

            }
        }
        //获取登录的name
        public static Object NameDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    return u.UserName;
                }
                else
                {
                    return 10;
                }

            }
        }
        //获取登录的账号的头像
        public static Object URLDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    return u.UserAvatarUrl;
                }
                else
                {
                    return 10;
                }

            }
        }
        public static Object MemberDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    return u.UserVIP;
                }
                else
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    return 0;
                }

            }
        }
    }
}