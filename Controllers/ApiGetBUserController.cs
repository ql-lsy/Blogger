using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiGetBUserController : ApiController
    {
        public object Get(int uid)
        {
            return DAL.UserInfoDAL.GetBUser(uid);
        }
    }
}
