using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.DAL
{
    public class classpf
    {
        public static object classpfDAL(int courseelpf, string courseelcontent, int courseId)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                Models.courseel c = new Models.courseel();
                c.courseelpf = courseelpf;
                c.courseelcontent = courseelcontent;
                c.courseId = courseId;
                c.UserID = u.UserID;
                var da1 = db.courseel.Add(c);
                //if (data != null)
                //{
                return db.SaveChanges() > 0;
                //}
                //else { return false; }
            }
        }
    }
}