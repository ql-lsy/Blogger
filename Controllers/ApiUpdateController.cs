using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiUpdateController : ApiController
    {
        public Object post([FromBody] Download d)
        {
            return BLL.UpdateBLL.AddBLL(d);
        }


        //下载计算币
        [HttpGet]
        public object KuncoinGet(int UserKunCoin)
        {
            return BLL.DownloadBLL.KuncoinBLL(UserKunCoin);
        }

        [HttpGet]
        public object AddKuncoinGet(int uploaderid, int kuncoin,int did)
        {
            return BLL.DownloadBLL.AddKuncoinBLL(uploaderid, kuncoin,did);
        }
    }
}
