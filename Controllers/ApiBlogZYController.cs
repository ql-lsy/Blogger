using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiBlogZYController : ApiController
    {
        public Object Get(int uid)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var data = db.Blog.Where(b=>b.UserID==uid).ToList();
                if (data.Count > 0)
                {
                    return data;
                }
                else
                {
                    return "NO";
                }
            }
        }
    }
}
