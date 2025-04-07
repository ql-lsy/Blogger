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
    public class ApiLoginController : ApiController
    {
        /*验证登录*/
        public Object Get()
        {
            return BLL.UserInfoBLL.LoginBLL();
        }


        public bool Get(string zh,string mima) 
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {

                var data = db.UserInfo.FirstOrDefault(x => x.UserAccount == zh&&x.UserPassword== mima);
                if (data!=null)
                {
                    HttpContext.Current.Session["User"] = data;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /*手机号登录*/
        public Object Get(string zcsjh)
        {
            return BLL.UserInfoBLL.LoginBLL(zcsjh);
        }
    }
}
