using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiSignController : ApiController
    {
        //验证是否今天第一次登录，是则签到
        public Object Post()
        {
            return BLL.UserInfoBLL.SignInBLL();//调用签到方法
        }

    }
}
