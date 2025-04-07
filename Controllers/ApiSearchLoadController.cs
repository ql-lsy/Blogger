using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blogger.Models;


namespace Blogger.Controllers
{
    public class ApiSearchLoadController : ApiController
    {
        public object Get(string search)
        {
            using (BoKeDBEntities db=new BoKeDBEntities())
            {
                //var data = db.Download.Where(p => p.DownloadName.Contains(search)).ToList();
                var data = (from d in db.Download
                            join u in db.UserInfo on d.UserID equals u.UserID
                            join l in db.Label on d.LabelID equals l.LabelID
                            where d.UserID == u.UserID && d.DownloadName.Contains(search)
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
                                uid = u.UserID
                            }).ToList();
                if (data.Count > 0)
                {
                    return data;
                }
                else
                {
                    return "NO";
                }
            }
        }
    }
}
