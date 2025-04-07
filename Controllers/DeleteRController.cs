using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class DeleteRController : Controller
    {
        // GET: DeleteBlogR
        [HttpPost]
        public Object Blog(int Bid)
        {
            if (HttpContext.Session["User"] is UserInfo u)
            {
                using (BoKeDBEntities db = new BoKeDBEntities())
                {
                    var data = db.Blog.FirstOrDefault(p => p.BlogID == Bid);
                    if (data != null)
                    {
                        if (data.UserID == u.UserID)
                        {
                            db.Blog.Remove(data);
                            return db.SaveChanges() > 0 ? "删除成功" : "删除失败";
                        }
                        else
                        {
                            return "抱歉，您没有权限!";
                        }
                    }
                    else
                    {
                        return "抱歉，没有找到该博客!";
                    }
                }
            }
            else
            {
                return "抱歉，您没有权限!";
            }

        }


        [HttpPost]
        public Object Down(int Did)
        {
            if (HttpContext.Session["User"] is UserInfo u)
            {
                using (BoKeDBEntities db = new BoKeDBEntities())
                {
                    var data = db.Download.FirstOrDefault(p => p.DownloadID == Did);
                    if (data != null)
                    {
                        if (data.UserID == u.UserID)
                        {
                            db.Download.Remove(data);
                            return db.SaveChanges() > 0 ? "删除成功" : "删除失败";
                        }
                        else
                        {
                            return "抱歉，您没有权限!";
                        }
                    }
                    else
                    {
                        return "抱歉，没有找到该资源!";
                    }
                }
            }
            else
            {
                return "抱歉，您没有权限!";
            }

        }

        [HttpPost]
        public Object QA(int Qid)
        {
            if (HttpContext.Session["User"] is UserInfo u)
            {
                using (BoKeDBEntities db = new BoKeDBEntities())
                {
                    var data = db.Issue.FirstOrDefault(p => p.IssueID == Qid);
                    if (data != null)
                    {
                        if (data.UserID == u.UserID)
                        {
                            db.Issue.Remove(data);
                            return db.SaveChanges() > 0 ? "删除成功" : "删除失败";
                        }
                        else
                        {
                            return "抱歉，您没有权限!";
                        }
                    }
                    else
                    {
                        return "抱歉，没有找到该问题!";
                    }
                }
            }
            else
            {
                return "抱歉，您没有权限!";
            }

        }
        [HttpPost]
        public Object MyToComments(int? Cid)
        {
            if (HttpContext.Session["User"] is UserInfo u)
            {
                using (BoKeDBEntities db = new BoKeDBEntities())
                {
                    var data = db.CommentsB.FirstOrDefault(p => p.CommentsBID == Cid);
                    if (data != null)
                    {
                        if (data.UserID == u.UserID)
                        {
                            db.CommentsB.Remove(data);
                            return db.SaveChanges() > 0 ? "删除成功" : "删除失败";
                        }
                        else
                        {
                            return "抱歉，您没有权限!";
                        }
                    }
                    else
                    {
                        return "没有找到该评论!";
                    }

                }
            }
            else
            {
                return "抱歉，您没有权限!";
            }
        }
        [HttpPost]
        public Object ToMyComments(int? Cid)
        {
            if (HttpContext.Session["User"] is UserInfo u)
            {
                using (BoKeDBEntities db = new BoKeDBEntities())
                {
                    var data = db.CommentsB.FirstOrDefault(p => p.CommentsBID == Cid);
                    var blog = db.Blog.FirstOrDefault(p => p.BlogID == data.BolgID);
                    if (data != null)
                    {
                        if (blog != null)
                        {
                            if (data.UserID == u.UserID)
                            {
                                db.CommentsB.Remove(data);
                                return db.SaveChanges() > 0 ? "删除成功" : "删除失败";
                            }
                            else if (data.BolgID == blog.BlogID)
                            {
                                if (blog.UserID == u.UserID)
                                {
                                    db.CommentsB.Remove(data);
                                    return db.SaveChanges() > 0 ? "删除成功" : "删除失败";
                                }
                                else
                                {
                                    return "抱歉，您没有权限!";

                                }
                            }
                            else
                            {
                                return "抱歉，您没有权限!";
                            }
                        }
                        else
                        {
                            return "博客丢失了";
                        }

                    }
                    else
                    {
                        return "没有找到该评论!";
                    }

                }
            }
            else
            {
                return "抱歉，您没有权限!";
            }
        }
    }
}