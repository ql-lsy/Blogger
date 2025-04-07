using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiBlogxdzController : ApiController
    {
        public Object Get(int Bid)
        {

            return DAL.BlogDAL.BlogxdzDAL(Bid);
        }
    }
}
