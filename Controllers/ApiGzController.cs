using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiGzController : ApiController
    {
        public bool Get(int uid)
        {
            using (BoKeDBEntities db = new BoKeDBEntities()) 
            {
                UserInfo u = HttpContext.Current.Session["User"] as UserInfo;
                var data = db.Concern.FirstOrDefault(x => x.UserID == u.UserID && x.ConcernUserID == uid);
                if (data != null) 
                {
                    return true;
                }else { return false; }
            }
        }
     
        
    }
}
