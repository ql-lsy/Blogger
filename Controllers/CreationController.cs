using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogger.Controllers
{
    public class CreationController : Controller
    {
        // GET: Creation
        public ActionResult Content()/*内容管理*/
        {
            return View();
        }
        public ActionResult Comments()/*评论管理*/
        {
            return View();
        }
        public ActionResult Opus()/*作品数据*/
        {
            return View();
        }
        public ActionResult Earnings()/*收益数据*/
        {
            return View();
        }
        public ActionResult Followers()/*粉丝数据*/
        {
            return View();
        }
    }
}