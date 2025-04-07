using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blogger.Models;

namespace Blogger.BLL
{
    public class BlogBLL
    {
        public static Object AddBlogBLL(Blog b)
        {

            return DAL.BlogDAL.AddBlogDAL(b);

        }
        public static Object GetBlogDAL(int b)
        {
            return DAL.BlogDAL.GetBlogDAL(b);
        }
    }
}