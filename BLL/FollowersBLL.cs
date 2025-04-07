using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.BLL
{
    public class FollowersBLL
    {
        public static Object SelectCountFollowersDAL()
        {
            return DAL.FollowersDAL.SelectCountFollowersDAL();
        }
    }
}