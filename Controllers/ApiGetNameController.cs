using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiGetNameController : ApiController
    {
        public Object Get(int uid)
        {
            return DAL.UserInfoDAL.GetName(uid);
        }
    }
}
