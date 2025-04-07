using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogger.Models;


namespace Blogger.Controllers
{
    public class LearnController : Controller
    {
        // GET: Learn
        public ActionResult Index()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var data = db.course.ToList();
                ViewData["a"] = data;
            }
            return View();
        }
    }
}