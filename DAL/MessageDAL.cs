using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blogger.Models;

namespace Blogger.DAL
{
    public class MessageDAL
    {
        public static object PlDAL()
        {
            //join u1 in db.UserInfo on p1.BlogUserID equals u1.UserID
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                var data = (from p1 in db.CommentsB
                            join b1 in db.Blog on p1.BolgID equals b1.BlogID
                            join u2 in db.UserInfo on p1.UserID equals u2.UserID
                            where b1.UserID == u.UserID
                            select new
                            {
                                name = u2.UserName,
                                title = b1.BlogTitle,
                                nr = b1.BlogContent,
                                plnr=p1.CommentsBContent,
                                imag=u2.UserAvatarUrl
                            }).ToList();

                return data;
            }
        }

        public static object LikeDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                var data = (from p1 in db.BlogLike
                            join b1 in db.Blog on p1.BolgID equals b1.BlogID
                            join u2 in db.UserInfo on p1.UserID equals u2.UserID
                            where b1.UserID == u.UserID
                            select new
                            {
                                name = u2.UserName,
                                title = b1.BlogTitle,
                                imag = u2.UserAvatarUrl
                            }).ToList();

                return data;
            }
        }

        public static object FavoriteDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                var data = (from p1 in db.Favorite
                            join b1 in db.Blog on p1.BlogID equals b1.BlogID
                            join u2 in db.UserInfo on p1.UserID equals u2.UserID
                            where b1.UserID == u.UserID
                            select new
                            {
                                name = u2.UserName,
                                title = b1.BlogTitle,
                                imag = u2.UserAvatarUrl
                            }).ToList();

                return data;
            }
        }
    }
}