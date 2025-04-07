using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Blogger.Controllers
{
    public class ApiDownloadController : ApiController
    {
        public Object Get()
        {
            return BLL.DownloadBLL.PlBLL();
        }

        //public object KuncoinGet(int UserKunCoin)
        //{
        //    return BLL.DownloadBLL.KuncoinBLL(UserKunCoin);
        //}
    }
}
