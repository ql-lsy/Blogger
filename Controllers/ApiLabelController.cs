using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    public class ApiLabelController : ApiController
    {
        public Object Get() {
            return BLL.LabelBLL.SelectALLBLL();
        }
    }
}
