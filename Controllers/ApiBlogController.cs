using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class ApiBlogController : ApiController
    {
        public Object Post([FromBody] Blog b)/*发布博客*/
        {
            if (HttpContext.Current.Session["User"] is UserInfo u)
            {
                b.UserID = u.UserID;
                b.BlogTime = DateTime.Now;
                return BLL.BlogBLL.AddBlogBLL(b);
            }
            return "Login";

        }
        public Object Get()
        {
            if (HttpContext.Current.Session["User"] is UserInfo u)
            {
                return BLL.BlogBLL.GetBlogDAL(u.UserID);
            }
            return "Login";
        }
        public Object Get(int BlogID)
        {
           
            return DAL.BlogDAL.GetBlogInfoDAL(BlogID);
        }
    }
}
