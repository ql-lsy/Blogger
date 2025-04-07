using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.BLL
{
    public class Community
    {
        public static object CommunityBLL()
        {
            return DAL.Community.CommunityDAL();
        }
    }
}