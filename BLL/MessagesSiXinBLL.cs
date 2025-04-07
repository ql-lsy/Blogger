using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.BLL
{
    public class MessagesSiXinBLL
    {
        public static object SelectBLL()
        {
            return DAL.MessagesSiXinDAL.SelectDAL();
        }

        public static object SelectXinXIBLL(int friendId)
        {
            return DAL.MessagesSiXinDAL.SelectXinXIDAL(friendId);
        }
    }
}