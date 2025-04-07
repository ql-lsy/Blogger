using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiFriendsController : ApiController
    {
        public object Get(int friendId)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {

                var data = db.UserInfo.FirstOrDefault(x => x.UserID == friendId);
                return data.UserName;
            }
        }

        public object post([FromBody] Messages m)
        {
            return BLL.MessagesAddBLL.AddBLL(m);
        }

    }
}
