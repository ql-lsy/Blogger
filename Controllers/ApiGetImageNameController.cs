using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiGetImageNameController : ApiController
    {
        public Object Get()
        {
            if (HttpContext.Current.Session["ImageName"] == null)
            {
                return "";
            }
            return HttpContext.Current.Session["ImageName"].ToString();
        }
    }
}
