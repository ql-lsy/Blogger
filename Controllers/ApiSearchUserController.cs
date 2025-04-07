using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiSearchUserController : ApiController
    {
        public object Get(string search)
        {
            using (BoKeDBEntities db=new BoKeDBEntities())
            {
                var data=db.UserInfo.Where(u=>u.UserName.Contains(search)).ToList();
                return data;
            }
        }
    }
}
