using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blogger.Models;

namespace Blogger.DAL
{
    public class BlogDAL
    {
        public static Object AddBlogDAL(Blog b)
        {
            if (b == null)
            {
                return "No";
            }
            Blog blog = b;
            if (blog.BlogTitle.Length < 1 || blog.BlogContent.Length < 10 || blog.BlogDec.Length < 1 || blog.BlogDec.Length > 100 || blog.BlogContent.Length > 4000 || blog.BlogTitle.Length > 16)
            {
                return "No";
            }
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                b.BlogClicks = 0;
                b.LastClicks = 0;
                b.BlogLike = 0;
                b.LastTime = DateTime.Now;
                b.BlogForword = 0;
                db.Blog.Add(b);
                if (db.SaveChanges() > 0)
                {
                    return "Yes";
                }
                return "No";

            }

        }


        public static Object GetBlogDAL(int b)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var data = db.Blog.Where(p => p.UserID == b).ToList();
                return data;
            }
        }
        public static Object GetBlogInfoDAL(int BlogID)
        {
            if (HttpContext.Current.Session["User"] is UserInfo u)
            {
                using (BoKeDBEntities db = new BoKeDBEntities())
                {

                    var Favorite = (from b in db.Blog join f in db.Favorite on b.BlogID equals f.BlogID select new { b.BlogID, FavoriteCount = f.BlogID }).Where(p => p.BlogID == BlogID).ToList();/*收藏数量*/
                    var CommentsB = db.CommentsB.Where(p => p.BolgID == BlogID).ToList();
                    int CommentsBCount = 0;
                    if (CommentsB.Count > 0)
                    {
                        CommentsBCount = CommentsB.Count;
                    }
                    int FavoriteCount = 0;
                    if (Favorite.Count > 0)
                    {
                        FavoriteCount = Favorite.Count;
                    }
                    var data = (from b in db.Blog select new { b.BlogID, b.BlogClicks, b.LastClicks, b.BlogContent, b.BlogDec, b.UserID, b.BlogForword, b.BlogImageUrl, b.BlogLike, b.BlogTime, b.BlogTitle, FavoriteCount = Favorite.Count, CommentsBCount }).ToList();

                    return data;
                }
            }
            else
            {
                return "Login";
            }

        }

        //public static Object GetBlogLineTime()
        //{
        //    if (HttpContext.Current.Session["User"] is UserInfo u)
        //    {
        //        using (BoKeDBEntities db = new BoKeDBEntities())
        //        {

        //        }
        //    }
        //    else
        //    {
        //        return "Login";
        //    }



        //}
        public static Object SelectALLBlogDAL(string sea)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var data = db.Blog.Where(p => p.BlogTitle.Contains(sea)).ToList();
           
                var ss = db.Search.FirstOrDefault(p=>p.SearchName==sea);
                if (ss != null) {
                    ss.SearchCount++;
                }
                else
                {
                    Search s = new Search();
                    s.SearchName = sea;
                    s.SearchCount = 1;
                    db.Search.Add(s);
                }
                db.SaveChanges();
                if (data.Count > 0)
                {
                    return data;
                }
                else
                {
                    return "NO";
                }
            }

        }
        public static Object BlogALLDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var data = db.Blog.ToList();
                if (data.Count > 0)
                {
                    return data;
                }
                else
                {
                    return "NO";
                }
            }
        }

        public static Object BlogdetailDAL(int Bid)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var data = db.Blog.FirstOrDefault(p => p.BlogID == Bid);
                if (data != null)
                {
                    return data;
                }
                else
                {
                    return "NO";
                }
            }
        }


        public static Object BlogdzDAL(int Bid)
        {
            if (HttpContext.Current.Session["User"] != null)//判断是否登录
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                using (BoKeDBEntities db = new BoKeDBEntities())
                {
                    var data = db.Blog.FirstOrDefault(p => p.BlogID == Bid);
                    if (data != null)
                    {
                        data.BlogLike += 1;
                        db.SaveChanges();
                        return data.BlogLike;
                    }
                    else
                    {
                        return "NO";
                    }
                }
            }
            else
            {
                return "Login";
            }
        }

        public static Object BlogxdzDAL(int Bid)
        {
            if (HttpContext.Current.Session["User"] != null)//判断是否登录
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                using (BoKeDBEntities db = new BoKeDBEntities())
                {
                    var data = db.Blog.FirstOrDefault(p => p.BlogID == Bid);
                    if (data != null)
                    {
                        data.BlogLike -= 1;
                        db.SaveChanges();
                        return data.BlogLike;
                    }
                    else
                    {
                        return "NO";
                    }
                }
            }
            else
            {
                return "Login";
            }
        }


        public static Object BlogscDAL(int Bid)
        {
            if (HttpContext.Current.Session["User"] != null)//判断是否登录
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                using (BoKeDBEntities db = new BoKeDBEntities())
                {

                    var data = db.Blog.FirstOrDefault(p => p.BlogID == Bid);
                    if (data != null)
                    {

                        Favorite f = new Favorite();
                        f.BlogID = Bid;
                        f.UserID = u.UserID;
                        var xsc = db.Favorite.FirstOrDefault(p => p.BlogID == f.BlogID && p.UserID == f.UserID);
                        if (xsc != null)
                        {
                            db.Favorite.Remove(xsc);
                            return db.SaveChanges() > 0 ? "xsc" : "NO";
                        }
                        else
                        {
                            db.Favorite.Add(f);
                            return db.SaveChanges() > 0 ? "sc" : "NO";
                        }

                    }
                    else
                    {
                        return "NO";
                    }
                }
            }
            else
            {
                return "Login";
            }
        }

        public static Object SelectuserDAL(string sea)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var data = db.UserInfo.Where(p => p.UserName.Contains(sea)).ToList();
                if (data.Count > 0)
                {
                    Blog b = new Blog();

                    return data;
                }
                else
                {
                    return "NO";
                }
            }
        }
    }
}