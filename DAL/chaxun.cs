using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.DAL
{
    public class chaxun
    {
        public static object chaxunDAL()
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var data = (from c in db.courseel
                            join u in db.UserInfo on c.UserID equals u.UserID
                            join m in db.course on c.courseId equals m.courseId
                            select new
                            {
                                userimg=u.UserAvatarUrl,
                                courseName = m.courseName,
                                UserName = u.UserName,
                                courseelpf = c.courseelpf,
                                courseelcontent = c.courseelcontent
                            }).ToList();
                return data;
            }
        }
    }
}