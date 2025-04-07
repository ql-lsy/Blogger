using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogger.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        public ActionResult Account()
        {
            return View();
        }
        public ActionResult Collect()
        {
            return View();
        }
        public ActionResult History()
        {
            return View();
        }

        public ActionResult UserCenter()
        {
            return View();
        }
    }
}