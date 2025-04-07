using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiInsertcommunityController : ApiController
    {
        public Object Get(string CommunityName)
        {
            try
            {
                BLL.InsertcommunityBLL.Insertcommunity(CommunityName);
                return Redirect("Community/Index");
            }
            catch (Exception)
            {

                return false;

            }
        }
    }
}
