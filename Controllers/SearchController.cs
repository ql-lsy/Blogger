using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search

        public ActionResult Index()
        {

            return View();
        }

        /*搜索全站视图*/
        public ActionResult Search_All()
        {
            return View();
        }
    }
}