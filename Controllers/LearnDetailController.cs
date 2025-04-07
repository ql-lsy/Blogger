using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class LearnDetailController : Controller
    {
        // GET: LearnDetail
        public ActionResult Index(int id)
        {

            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                ViewData["el"] = db.courseel.ToList();
                ViewData["cc"] = (from p in db.course where p.courseId == id select p).ToList();

            }

            return View("Index");
        }
    }
}