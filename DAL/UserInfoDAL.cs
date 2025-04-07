using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blogger.Models;

namespace Blogger.DAL
{
    public class UserInfoDAL
    {
        /*签到*/
        public static Object SingInDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)//判断是否登录
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    var data = db.UserInfo.FirstOrDefault(p => p.UserID == u.UserID);//从数据库找到和当前用户登录信息ID一样的数据
                    string d = DateTime.Now.ToShortDateString();//获取电脑上的当前日期
                    string n = ((DateTime)data.UserlastLoginTime).ToShortDateString();//获取用户最后登录的时间

                    if (Convert.ToDateTime(d) > Convert.ToDateTime(n))
                    {
                        if (Convert.ToDateTime(d) != null)
                        {
                            data.UserlastLoginTime = Convert.ToDateTime(d);//设置最后登录时间
                            data.UserKunCoin += 2;  //签到成功增加2币
                            data.UserExperience += 10;//签到后加10经验
                            data.FavoriteCount = 0;
                            var Followers = db.Followers.Where(p => p.UserID == u.UserID).ToList();
                            if (Followers.Count > 0)
                            {
                                data.FollowersCount = Followers.Count;//粉丝量
                            }

                            data.DownloadKunCoinObtainCount = 0;//收到币数量
                            var Download = db.Download.Where(p => p.UserID == u.UserID).ToList();
                            if (Download.Count > 0)
                            {
                                for (int i = 0; i < Download.Count; i++)
                                {
                                    data.DownloadKunCoinObtainCount += Download[i].DownloadKunCoinObtain;//收到币数量
                                }
                            }

                            var Blog = db.Blog.Where(p => p.UserID == u.UserID).ToList();
                            var Favorite = (from b in db.Blog join f in db.Favorite on b.BlogID equals f.BlogID select new { FavoriteCount = f.BlogID }).ToList();
                            if (Favorite.Count > 0)
                            {
                                data.FavoriteCount += Favorite.Count;//收藏量
                            }
                            if (Blog.Count > 0)
                            {
                                for (int i = 0; i < Blog.Count; i++)
                                {
                                    Blog[i].LastTime = Convert.ToDateTime(d);
                                    Blog[i].LastClicks = Blog[i].BlogClicks;//将今日的统计更换为现在的浏览数量


                                }
                            }
                            if (db.SaveChanges() > 0)
                            {
                                return u.UserName;//签到成功
                            }
                        }
                    }
                }
                return "NO";
            }
        }
        /*验证登录*/
        public static Object LoginDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;

                    return u.UserName;
                }

                return "NO";

            }
        }
        /*登录*/
        public static Object LoginDAL(string zcsjh)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var data = db.UserInfo.FirstOrDefault(x => x.UserPhone == zcsjh);
                if (data != null)
                {

                    if (HttpContext.Current.Session["User"] != null)
                    {
                        HttpContext.Current.Session["User"] = null;
                    }
                    HttpContext.Current.Session["User"] = data;
                    return "OK";
                }
                return "NO";
            }
        }

        public static Object SelectALLUserInfoDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)//判断是否登录
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    var data=db.UserInfo.FirstOrDefault(p => p.UserID == u.UserID);
                    if(data != null)
                    {
                        return data;
                    }
                    else
                    {
                        return "Login";
                    }
                }
                else
                {
                    return "Login";
                }
            }

        }


        public static Object GetName(int uid)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var data = db.UserInfo.FirstOrDefault(u => u.UserID == uid);
                return data != null ? data.UserName : "NO";
            }

        }


        public static Object GetBUser(int uid)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var data = db.UserInfo.FirstOrDefault(u => u.UserID == uid);
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

        public static Object UserIDDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    var data = db.UserInfo.FirstOrDefault(p => p.UserID == u.UserID);
                    return data;
                }

                return "NO";

            }
        }
    }
}