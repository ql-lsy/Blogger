using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blogger.Models;

namespace Blogger.DAL
{
    public class LabelDAL
    {
        public static Object SelectALLDAL()
        {
            using(BoKeDBEntities db= new BoKeDBEntities())
            {
                var data = db.Label.ToList();
                return data;
            }
        }
    }
}