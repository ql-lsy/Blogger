using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiCommunityController : ApiController
    {
        public Object Get()
        {
            try
            {
                return BLL.Community.CommunityBLL();
            }
            catch (Exception)
            {

                return false;

            }
        }
    }
}
