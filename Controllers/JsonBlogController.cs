using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class JsonBlogController : Controller
    {
        // GET: JsonBlog
        [HttpPost]
        public ActionResult GetBlog(int curr, int nums)
        {

            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Session["User"] is UserInfo u)
                {
                    var data = db.Blog.Where(p => p.UserID == u.UserID).ToList();
                    int index = data.Count();
                    data.RemoveRange(0, ((curr - 1) * nums));
                    if (data.Count - nums > 0)
                    {
                        data.RemoveRange(nums, data.Count - nums);
                    }
                    return Json(new { data, count = index, code = 0 });
                }
                else
                {
                    return Json(new { error = "账号登录异常", code = 0 });
                }

            }
        }
        [HttpPost]
        public ActionResult GetDown(int curr, int nums)
        {

            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Session["User"] is UserInfo u)
                {
                    var data = db.Download.Where(p => p.UserID == u.UserID).ToList();
                    int index = data.Count();
                    data.RemoveRange(0, ((curr - 1) * nums));
                    if (data.Count - nums > 0)
                    {
                        data.RemoveRange(nums, data.Count - nums);
                    }
                    return Json(new { data, count = index, code = 0 });
                }
                else
                {
                    return Json(new { error = "账号登录异常", code = 0 });
                }

            }
        }
        [HttpPost]
        public ActionResult GetQA(int curr, int nums)
        {

            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Session["User"] is UserInfo u)
                {
                    var data = db.Issue.Where(p => p.UserID == u.UserID).ToList();
                    int index = data.Count();
                    data.RemoveRange(0, ((curr - 1) * nums));
                    if (data.Count - nums > 0)
                    {
                        data.RemoveRange(nums, data.Count - nums);
                    }
                    return Json(new { data, count = index, code = 0 });
                }
                else
                {
                    return Json(new { error = "账号登录异常", code = 0 });
                }

            }
        }


        [HttpPost]
        public ActionResult GetCommentsMyTo(int curr, int nums)/*我的评论*/
        {

            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Session["User"] is UserInfo u)
                {
                    var data = (from c in db.CommentsB
                                join b in db.Blog on c.BolgID equals b.BlogID
                                select new
                                {
                                    c.UserID,
                                    c.CommentsBContent,
                                    c.CommentsBID,
                                    c.CommentsBLike,
                                    b.BlogTitle,
                                    b.BlogDec,
                                    b.BlogID
                                }).Where(p => p.UserID == u.UserID).ToList();
                    //var data = db.CommentsB.Where(p => p.UserID == u.UserID).ToList();
                    int index = data.Count();
                    data.RemoveRange(0, ((curr - 1) * nums));
                    if (data.Count - nums > 0)
                    {
                        data.RemoveRange(nums, data.Count - nums);
                    }
                    return Json(new { data, count = index, code = 0 });
                }
                else
                {
                    return Json(new { error = "账号登录异常", code = 0 });
                }

            }
        }

        [HttpPost]
        public ActionResult GetCommentsToMy(int curr, int nums)
        {

            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                if (HttpContext.Session["User"] is UserInfo u)
                {
                    var data = (from c in db.CommentsB
                                join b in db.Blog on c.BolgID equals b.BlogID join cu in db.UserInfo on c.UserID equals cu.UserID
                                select new
                                {
                                    myUserID = b.UserID,
                                    c.UserID,
                                    cu.UserName,/*评论人的userName*/
                                    c.CommentsBContent,
                                    c.CommentsBID,
                                    c.CommentsBLike,
                                    b.BlogTitle,
                                    b.BlogDec
                                }).Where(p => p.myUserID == u.UserID).ToList();
                    int index = data.Count();
                    data.RemoveRange(0, ((curr - 1) * nums));
                    if (data.Count - nums > 0)
                    {
                        data.RemoveRange(nums, data.Count - nums);
                    }
                    return Json(new { data, count = index, code = 0 });
                }
                else
                {
                    return Json(new { error = "账号登录异常", code = 0 });
                }

            }
        }

    }
}