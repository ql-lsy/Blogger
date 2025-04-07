using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.DAL
{
    public class MessagesSiXinDAL
    {
        public static object SelectDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                var data = (from f in db.Followers
                            join c in db.Concern on f.FollowersUserID equals c.ConcernUserID
                            join u1 in db.UserInfo on f.FollowersUserID equals u1.UserID
                            where f.UserID == u.UserID
                            select new
                            {
                                uname = u.UserName,
                                uid = u.UserID,
                                uimg = u.UserAvatarUrl,
                                himg = u1.UserAvatarUrl,
                                hname = u1.UserName,
                                hid = u1.UserID,
                                
                            }).Distinct().ToList();
                return data;
            }
        }

        public static object SelectXinXIDAL(int friendId)
        {
            //join u1 in db.UserInfo on m.ToUserID equals u1.UserID
            //select new { uname = u.UserName, huame = u1.UserName, Text = m.MessagesText, uimg = u.UserAvatarUrl, himg = u1.UserAvatarUrl, time = m.MessagesTime, uid = u.UserID, hid = u1.UserID }).ToList();
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                var data = (from m in db.Messages
                            join uf in db.UserInfo on m.FromUserID equals uf.UserID
                            join ut in db.UserInfo on m.ToUserID equals ut.UserID
                            where (m.FromUserID == u.UserID && m.ToUserID == friendId) || (m.FromUserID == friendId && m.ToUserID == u.UserID)
                            select new 
                            {
                                MessagesText=m.MessagesText,
                                FromUserID=m.FromUserID,
                                himg=uf.UserAvatarUrl,
                                uimg=ut.UserAvatarUrl

                            }).ToList();
                return data;

            }
        }
    }
}