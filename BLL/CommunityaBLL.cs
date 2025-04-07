using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.BLL
{
    public class CommunityaBLL
    {
        public static object CommunityBLL(int CommunityID)
        {
            return DAL.Communitya.CommunityaDAL(CommunityID);
        }
    }
}