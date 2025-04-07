using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.BLL
{
    public class DownloadBLL
    {
        public static Object SelectCountDownloadKunCoinObtainBLL()
        {
            return DAL.DownloadDAL.SelectCountDownloadKunCoinObtainDAL();
        }

        public static object PlBLL()
        {
            return DAL.DownloadDAL.PlDAL();
        }

        public static object KuncoinBLL(int UserKunCoin)
        {
            return DAL.DownloadDAL.KuncoinDAL(UserKunCoin);
        }
        public static object AddKuncoinBLL(int uploaderid, int kuncoin,int did)
        {
            return DAL.DownloadDAL.AddKuncoinDAL(uploaderid, kuncoin,did);
        }
    }
}