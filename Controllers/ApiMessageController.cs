using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiMessageController : ApiController
    {
        public Object Get()
        {
            return BLL.MessageBLL.PlBLL();
        }

        public Object Like()
        {
            return BLL.MessageBLL.LikeBLL();
        }

        public Object Favorite()
        {
            return BLL.MessageBLL.FavoriteBLLL();
        }
    }
}
