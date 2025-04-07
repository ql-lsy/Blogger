using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiBlogdzController : ApiController
    {
        public object Get(int Bid)
        {
            return DAL.BlogDAL.BlogdzDAL(Bid);
        }
    }
}
