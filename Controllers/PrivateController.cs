using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogger.Controllers
{
    public class PrivateController : Controller
    {
        // GET: Private
        public ActionResult Messages()
        {
            return View();
        }
    }
}