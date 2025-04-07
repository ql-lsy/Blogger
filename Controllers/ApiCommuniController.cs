using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiCommuniController : ApiController
    {
        public Object GET(int CommunityID)
        {
            try
            {
                return BLL.CommunityaBLL.CommunityBLL(CommunityID);
            }
            catch (Exception)
            {

                return false;

            }
        }
    }
}
