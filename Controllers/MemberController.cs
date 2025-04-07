using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogger.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            ViewBag.userNAME = Convert.ToString(BLL.Seek_helpBLL.NameBLL());
            ViewBag.userURL = Convert.ToString(BLL.Seek_helpBLL.URLBLL());
            int data = Convert.ToInt32(BLL.Seek_helpBLL.MenberBLL());
            if (data == 0)
            {
                ViewBag.userVIP = "您还不是会员,请充值！";
            }
            else
            {
                ViewBag.userVIP = "您已经是会员！";
            }
            return View();
        }
    }
}