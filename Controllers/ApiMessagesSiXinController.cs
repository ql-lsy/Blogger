using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiMessagesSiXinController : ApiController
    {
        public Object Get()
        {
            return BLL.MessagesSiXinBLL.SelectBLL();
        }

        public Object Get(int friendId)
        {
            return BLL.MessagesSiXinBLL.SelectXinXIBLL(friendId);
        }



    }
}
