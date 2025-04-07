using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.BLL
{
    public class Study
    {
        public static object StudyBLL(int ID)
        {
            return DAL.Study.StudyDAL(ID);
        }
    }
}