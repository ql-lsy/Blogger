using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiDLZYController : ApiController
    {
        public object Get(int uid)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                //UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                var data = (from d in db.Download
                            join u in db.UserInfo on d.UserID equals u.UserID
                join l in db.Label on d.LabelID equals l.LabelID
                            where d.UserID == u.UserID && d.UserID == uid
                            select new
                            {
                                name = d.DownloadName,
                                Des = d.DownloadDec,
                                KunCoin = d.DownloadKunCoin,
                                Time = d.DownloadTime,
                                Label = l.LabelText,
                                Url = d.DownloadPath,
                                uName = u.UserName,
                                suffix1 = d.suffix,
                                did = d.DownloadID,
                                uid = u.UserID
                            }).ToList();
                return data;
            }
        }
    }
}
