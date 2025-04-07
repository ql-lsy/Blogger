using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.BLL
{
    public class InsertcommunityBLL
    {
        public static object Insertcommunity(string CommunityName)
        {
            return DAL.Insertcommunity.InsertcommunityDAL(CommunityName);
        }
    }
}