using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.DAL
{
    public class Community
    {
        public static object CommunityDAL()
        {
                using (BoKeDBEntities db = new BoKeDBEntities())
                {
                    UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                    //var da=(from c in db.Community where c.UserID== u.UserID select c).ToList();
                    var da1 = (from c in db.Community
                               join m in db.Communitymember on c.CommunityID equals m.CommunityID
                               join s in db.UserInfo on m.UserID equals s.UserID
                               where m.UserID == u.UserID
                               select new
                               {
                                   UserName = u.UserName,
                                   CommunityID = c.CommunityID,
                                   hid = u.UserID,
                                   CommunityName1 = c.CommunityName
                               }).ToList();
                    //if (data != null)
                    //{
                    return da1;
                    //}
                    //else { return false; }
                }
            }
        }
    }

