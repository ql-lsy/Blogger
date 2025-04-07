using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blogger.Models;

namespace Blogger.BLL
{
    public class FavoriteBLL
    {
        public static Object SelectFavoriteCountDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)//判断是否登录
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    var Blog = db.Blog.Where(p => p.UserID == u.UserID).ToList();
                    var Favorite = (from b in db.Blog join f in db.Favorite on b.BlogID equals f.BlogID select new { FavoriteCount = f.BlogID }).ToList();
                    if (Favorite.Count > 0)
                    {
                        return Favorite.Count;
                    }
                    else { return 0; }
                }
                else
                {
                    return "Login";
                }
            }
        }
    }
}