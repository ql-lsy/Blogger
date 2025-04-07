using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiCreationUserInfoController : ApiController
    {
        public Object Get(int Type)
        {
            if (Type == 0)
            {
                return BLL.UserInfoBLL.SelectALLUserInfoBLL();
            }
            else if (Type == 1)
            {
                return BLL.DownloadBLL.SelectCountDownloadKunCoinObtainBLL();
            }else if (Type == 2)
            {
                return BLL.FollowersBLL.SelectCountFollowersDAL();
            }
            else if (Type == 3)
            {
                return BLL.FavoriteBLL.SelectFavoriteCountDAL();
            }
            else
            {
                return BLL.UserInfoBLL.SelectALLUserInfoBLL();
            }
        }
    }
}
