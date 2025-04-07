using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Blogger.Controllers
{
    //Home控制器
    public class HomeController : Controller
    {
        /*首页视图*/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        /*博客视图*/
        public ActionResult Blogger()
        {
            return View();
        }
        /*下载视图*/
        public ActionResult Download()
        {
            return View();
        }
        /*学习视图*/
        public ActionResult Learn()
        {
            return View();
        }
        /*社区视图*/
        public ActionResult Community()
        {
            return View();
        }
        /*求助视图*/
        public ActionResult Seek_help()
        {
            return View();
        }
        /*会员视图*/
        public ActionResult Member()
        {
            return View();
        }
        /*创作中心视图*/
        public ActionResult Creation()
        {
            return View();
        }
        /*消息视图*/
        public ActionResult Message()
        {
            return View();
        }
        /*个人资料视图*/
        public ActionResult Personal_Data()
        {
            return View();
        }
        public ActionResult Personal_zhuye()
        {
            return View();
        }
    }
}
