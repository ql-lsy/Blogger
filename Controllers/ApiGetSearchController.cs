using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class ApiGetSearchController : ApiController
    {
        public Object Get(string Name)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                return db.Search.Where(p=>p.SearchName.Contains(Name)).ToList();
            }
        }
    }
}
