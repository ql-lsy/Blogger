using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.BLL
{
    public class MessageBLL
    {
        public static object PlBLL()
        {
            return DAL.MessageDAL.PlDAL();
        }

        public static object LikeBLL()
        {
            return DAL.MessageDAL.LikeDAL();
        }

        
            public static object FavoriteBLLL()
        {
            return DAL.MessageDAL.FavoriteDAL();
        }
    }
}