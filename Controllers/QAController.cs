using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogger.Controllers
{
    public class QAController : Controller
    {
        //问答
        // GET: QA
        BoKeDBEntities db = new BoKeDBEntities();
        //问答界面
        public ActionResult Seek_help()
        {
            ViewBag.userURL = Convert.ToString(BLL.Seek_helpBLL.URLBLL());
            var data = (from i in db.Issue
                        orderby i.IssueDateTime descending 
                        select i).ToList();
            ViewBag.QA = data;
            return View();
        }
        [HttpPost]
        //添加问题
        public object Seek_help(Issue i)
        {
            i.UserID = Convert.ToInt16(BLL.Seek_helpBLL.LoginBLL());
            i.IssueDateTime = DateTime.Now;
            i.IssueQuantity = 0;
            db.Issue.Add(i);
            db.SaveChanges();
            var data = (from a in db.Issue
                        orderby a.IssueDateTime descending
                        select a).ToList();
            ViewBag.QA = data;
            return View("/Views/QA/Seek_help.cshtml");
        }
        //回答界面
        public ActionResult index(Issue i)
        {
            ViewBag.time = i.IssueDateTime;
            ViewBag.content = i.IssueContent;
            ViewBag.Issuedetails = i.Issuedetails;
            var name = db.UserInfo.FirstOrDefault(x => x.UserID == i.UserID);
            ViewBag.userNAME = name.UserName;
            ViewBag.userURL = Convert.ToString(BLL.Seek_helpBLL.URLBLL());
            var data = (from r in db.Reply
                        orderby r.ReplyTime descending
                        select r).Where(p => p.IssueID == i.IssueID).ToList();
            var un = db.Issue.Where(p => p.IssueID == i.IssueID).FirstOrDefault();
            un.IssueQuantity = data.Count();
            ViewBag.num = i.IssueQuantity;
            ViewBag.RE = data;
            ViewData["re"] = data;
            return View();
        }
        [HttpPost]
        //添加回答
        public object index(Reply r, Issue i)
        {
            r.UserID = Convert.ToInt16(BLL.Seek_helpBLL.LoginBLL());
            r.ReplyTime = DateTime.Now;
            r.ReplyLike = 0;
            db.Reply.Add(r);
            var un = db.Issue.Where(p => p.IssueID == i.IssueID).FirstOrDefault();
            un.IssueQuantity = un.IssueQuantity + 1;
            db.SaveChanges();
            var data = (from n in db.Reply
                        orderby n.ReplyTime descending
                        select n).Where(p => p.IssueID == i.IssueID).ToList();
            un.IssueQuantity = data.Count();
            ViewBag.RE = data;
            ViewData["re"] = data;
            ViewBag.num = un.IssueQuantity;
            ViewBag.time = i.IssueDateTime;
            ViewBag.content = i.IssueContent;
            ViewBag.Issuedetails = i.Issuedetails;
            ViewBag.userNAME = Convert.ToString(BLL.Seek_helpBLL.NameBLL());
            ViewBag.userURL = Convert.ToString(BLL.Seek_helpBLL.URLBLL());
            return View("/Views/QA/index.cshtml");//刷新
        }
        //我的问题
        public ActionResult Mproblem()
        {
            int UserID = Convert.ToInt16(BLL.Seek_helpBLL.LoginBLL());
            if (UserID== 11111)
            {
                Response.Write("<script>alert('你还没有的登录，请登录！')");
                return View();
            }
            else
            {
                ViewBag.userURL = Convert.ToString(BLL.Seek_helpBLL.URLBLL());
                var data = (from i in db.Issue
                            orderby i.IssueDateTime descending
                            select i).Where(p => p.UserID == UserID).ToList();
                ViewBag.QA = data;
                return View();
            }
        }
        [HttpPost]

        public ActionResult Mproblem(Issue i)
        {
            ViewBag.time = i.IssueDateTime;
            ViewBag.content = i.IssueContent;
            ViewBag.Issuedetails = i.Issuedetails;
            ViewBag.userNAME = Convert.ToString(BLL.Seek_helpBLL.NameBLL());
            ViewBag.userURL = Convert.ToString(BLL.Seek_helpBLL.URLBLL());
            var data = (from n in db.Reply
                        orderby n.ReplyTime descending
                        select n).Where(p => p.IssueID == i.IssueID).ToList();
            var un = db.Issue.Where(p => p.IssueID == i.IssueID).FirstOrDefault();
            un.IssueQuantity = data.Count();
            ViewBag.num = i.IssueQuantity;
            ViewBag.RE = data;
            ViewData["re"] = data;
            return View();
        }

        //删除评论
        public ActionResult delete(int ReplyID, Issue i)
        {
            var datas = db.Reply.FirstOrDefault(p => p.ReplyID == ReplyID);
            db.Reply.Remove(datas);
            var un = db.Issue.Where(p => p.IssueID == i.IssueID).FirstOrDefault();
            un.IssueQuantity = un.IssueQuantity - 1;
            db.SaveChanges();
            var a = db.Issue.Where(p => p.IssueID == i.IssueID).FirstOrDefault();
            ViewBag.num = a.IssueQuantity;
            return RedirectToAction("Seek_help");

        }
    }
}