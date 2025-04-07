using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Blogger.BLL
{
    public class UpdateBLL
    {
        public static object AddBLL([FromBody] Download d)
        {
            return DAL.UpdateDAL.AddDAL(d);
        }
    }
}