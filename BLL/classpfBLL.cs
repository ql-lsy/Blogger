using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.BLL
{
    public class classpfBLL
    {
        public static object classpfBLLq(int courseelpf, string courseelcontent, int courseId)
        {

            return DAL.classpf.classpfDAL(courseelpf, courseelcontent, courseId);
        }
    }
}