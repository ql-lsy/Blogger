using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.DAL
{
    public class Communitya
    {
        public static object CommunityaDAL(int CommunityID)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {

                var data = (from b in db.Blog
                            join m in db.Communitymember on b.UserID equals m.UserID
                            join s in db.UserInfo on m.UserID equals s.UserID
                            join u in db.UserInfo on b.UserID equals u.UserID
                            where m.CommunityID == CommunityID
                            select new
                            {
                                UserName = u.UserName,
                                LastTime = b.LastTime,
                                UserAccount = s.UserAccount,
                                UserID = b.UserID,
                                BlogContent = b.BlogContent

                            }).Distinct().ToList();
                return data;
            }
        }
    }
}