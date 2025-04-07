using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blogger.Models;

namespace Blogger.DAL
{
    public class FollowersDAL
    {
        public static Object SelectCountFollowersDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)//判断是否登录
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    var data = db.Followers.Where(p=>p.UserID==u.UserID).ToList();
                    if (data.Count > 0)
                    {
                        return data.Count;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return "Login";
                }
            }
        }
    }
}