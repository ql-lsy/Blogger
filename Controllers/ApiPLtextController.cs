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
    public class ApiPLtextController : ApiController
    {
        public object Get(int Bid)
        {
            using (BoKeDBEntities db=new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                var data=(from c in db.CommentsB join u1 in db.UserInfo on c.UserID equals u1.UserID where c.BolgID==Bid
                          select new 
                          { 
                                uimg=u1.UserAvatarUrl,
                                uname=u1.UserName,
                                ctext=c.CommentsBContent
                          }).ToList();
                return data;
            }
        }
    }
}
