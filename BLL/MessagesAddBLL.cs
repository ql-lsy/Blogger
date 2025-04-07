using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Blogger.BLL
{
    public class MessagesAddBLL
    {
        public static object AddBLL([FromBody] Messages m)
        {
            return DAL.MessagesAddDAL.AddDAL(m);
        }
    }
}