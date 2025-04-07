using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.BLL
{
    public class LabelBLL
    {
        public static Object SelectALLBLL()
        {
            return DAL.LabelDAL.SelectALLDAL();
        }
    }
}