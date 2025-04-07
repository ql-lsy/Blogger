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
    public class ApiBlogPLController : ApiController
    {
        public bool Get(int Bid,string text)
        {
            using (BoKeDBEntities db=new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                CommentsB c= new CommentsB();
                c.UserID = u.UserID;
                c.CommentsBContent = text;
                c.BolgID = Bid;
                db.CommentsB.Add(c);
                if (db.SaveChanges()>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
                //return 1;
            }
        }
    }
}
