using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiGzZController : ApiController
    {
        public object Get(int uid)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                var data = db.Concern.FirstOrDefault(x => x.UserID == u.UserID && x.ConcernUserID == uid);
                var datt = db.Followers.FirstOrDefault(x => x.UserID == u.UserID && x.FollowersUserID == uid);
                if (data != null)
                {
                    db.Concern.Remove(data);
                    db.Followers.Remove(datt);
                    //db.SaveChanges();
                    return db.SaveChanges() > 0 ? "取消关注成功" : "取消关注失败";
                }
                else
                {
                    Concern c = new Concern();
                    Followers f = new Followers();
                    f.UserID = uid ;
                    f.FollowersUserID = u.UserID;
                    c.UserID = u.UserID;
                    c.ConcernUserID = uid ;
                    db.Concern.Add(c);
                    db.Followers.Add(f);
                    return db.SaveChanges() > 0 ? "关注成功" : "关注失败";
                }
            }
        }
    }
}
