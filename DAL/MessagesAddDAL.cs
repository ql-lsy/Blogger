using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Blogger.DAL
{
    public class MessagesAddDAL
    {

        public static object AddDAL([FromBody] Messages m)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                m.FromUserID = u.UserID;
                m.MessagesTime = DateTime.Now;
                db.Messages.Add(m);
                return db.SaveChanges() > 0;
            }
        }
    }
}