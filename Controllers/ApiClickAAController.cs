using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiClickAAController : ApiController
    {
        public object Get(int Bid)
        {
            using (BoKeDBEntities db=new BoKeDBEntities())
            {
                var data = db.Blog.FirstOrDefault(p => p.BlogID == Bid);
                if (data != null)
                {
                    data.BlogClicks += 1;
                    db.SaveChanges();
                    return data.BlogClicks;
                }
                else
                {
                    return "NO";
                }
            }
        }
    }
}
