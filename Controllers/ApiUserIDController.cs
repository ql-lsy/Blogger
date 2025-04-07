using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiUserIDController : ApiController
    {
        public object Get(int uid)
        {
            using (BoKeDBEntities db=new BoKeDBEntities())
            {
                var data=db.UserInfo.Where(p=>p.UserID==uid).ToList();
                return data;
            }
        }
    }
}
