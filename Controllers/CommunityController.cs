using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class CommunityController : Controller
    {
        // GET: Community
        public ActionResult Index()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var data = db.Community.ToList();
                ViewData["Community"] = data;
            }
            return View();
        }
    }
}