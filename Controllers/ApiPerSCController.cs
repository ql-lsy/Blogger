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
    public class ApiPerSCController : ApiController
    {
        public object Get()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Current.Session["User"] != null)//判断是否登录
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    var data = (from f in db.Favorite
                                join b in db.Blog on f.BlogID equals b.BlogID
                                where f.UserID == u.UserID
                                select new
                                {
                                    uid = f.UserID,
                                    title = b.BlogTitle,
                                    bid = b.BlogID
                                }).ToList();
                    return data;
                }
                else
                {
                    return "Login";
                }

            }
        }
    }
}
