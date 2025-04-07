using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.DAL
{
    public class Insertcommunity
    {
        public static object InsertcommunityDAL(string CommunityName)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                Models.Community c = new Models.Community();
                //获取社区名称
                c.CommunityName = CommunityName;
                var data = db.Community.Add(c);
                return db.SaveChanges() > 0;
            }
        }
    }
}