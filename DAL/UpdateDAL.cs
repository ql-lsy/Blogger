using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;
using Blogger.Models;

namespace Blogger.DAL
{
    public class UpdateDAL
    {
        public static object AddDAL([FromBody] Download d)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                
                d.UserID = u.UserID;
                d.frequency = 0;
                d.DownloadKunCoinObtain = 0;
                d.DownloadTime = DateTime.Now.Date.ToString("yyyy-MM-dd");
                d.suffix= Path.GetExtension(d.DownloadPath);
                db.Download.Add(d);
                //d.DownloadPath

                return db.SaveChanges() > 0;
            }
        }
    }
}