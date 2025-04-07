using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blogger.Models;

namespace Blogger.DAL
{
    public class DownloadDAL
    {
        public static Object SelectMyAllDownLoadDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)//判断是否登录
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    return db.Download.Where(p=>p.UserID==u.UserID).ToList();
                }
                else
                {
                    return "Login";
                }
            }
                }
        public static Object SelectCountDownloadKunCoinObtainDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)//判断是否登录
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    var data = db.Download.Where(p => p.UserID == u.UserID).ToList();

                    if (data.Count > 0)
                    {
                        int sum = 0;
                        for (int i = 0; i < data.Count; i++)
                        {
                            sum += Convert.ToInt32(data[i].DownloadKunCoinObtain);
                        }
                        return sum;
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

        public static object PlDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                //UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                var data = (from d in db.Download
                            join u in db.UserInfo on d.UserID equals u.UserID
                            join l in db.Label on d.LabelID equals l.LabelID
                            where d.UserID == u.UserID
                            select new
                            {
                                name = d.DownloadName,
                                Des = d.DownloadDec,
                                KunCoin = d.DownloadKunCoin,
                                Time = d.DownloadTime,
                                Label = l.LabelText,
                                Url = d.DownloadPath,
                                uName = u.UserName,
                                suffix1 = d.suffix,
                                did=d.DownloadID,
                                uid = u.UserID
                            }).ToList();
                return data;
            }

        }

        public static object KuncoinDAL(int UserKunCoin)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                var user = db.UserInfo.FirstOrDefault(x => x.UserID == u.UserID);
                if (user != null)
                {
                    if (user.UserKunCoin >= UserKunCoin)
                    {
                        user.UserKunCoin -= UserKunCoin;
                        // 减少币数量
                        db.SaveChanges(); // 保存更改到数据库
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static object AddKuncoinDAL(int uploaderid, int kuncoin,int did)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                var user = db.UserInfo.FirstOrDefault(x => x.UserID == uploaderid);
                var up = db.Download.FirstOrDefault(x => x.DownloadID == did);
                if (user != null)
                {
                    up.DownloadKunCoinObtain += kuncoin;
                    user.UserKunCoin += kuncoin; // 减少币数量

                    db.SaveChanges(); // 保存更改到数据库
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}