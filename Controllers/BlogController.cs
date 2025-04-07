using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult detail(int Bid)
        {
            //BoKeDBEntities db=new BoKeDBEntities();
            //{
            //    IEnumerable<Blog> plist=db.Blog.Where(p=>p.BlogID==Bid).ToList();
            //    return View(plist);
            //}
            return View();
        }
    }
}