using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiStudyController : ApiController
    {
        public Object GET(string Id)
        {
            try
            {
                int ID = Convert.ToInt32(Id);
                return BLL.Study.StudyBLL(ID);
            }
            catch (Exception)
            {

                return false;

            }
        }
    }
}
