using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiSearchController : ApiController
    {
        public  object Get() {
            return "搜索全站";
        }
        public object Get(string search,string n)
        {
            if (n == "1")
            {
                return DAL.BlogDAL.SelectALLBlogDAL(search);
            }
            else if (n == "2")
            {
                return "搜索xx"+ search;
            }
            return "搜索全站" + search;

        }
    }
}
