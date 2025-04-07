using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiclasspfController : ApiController
    {
        public Object GET(int courseelpf, string courseelcontent, int courseId)
        {
            try
            {
                return BLL.classpfBLL.classpfBLLq(courseelpf, courseelcontent, courseId);
            }
            catch (Exception)
            {

                return false;

            }
        }
    }
}
