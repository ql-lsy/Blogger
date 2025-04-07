using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Blogger.Controllers
{
    public class UploadController : Controller
    {

        [HttpPost]
        public Object Upload(HttpPostedFileBase File)
        {
            string filename = File.FileName;
            string suffix = filename.Remove(0, filename.LastIndexOf(".") - 1);
            string name = "File" + DateTime.Now.ToString().Replace("/", ".").Replace(" ", "-").Replace(":", "-") + suffix;
            if (File.ContentLength > 10485760)
            {
                return "BigImage";
            }
            File.SaveAs(Server.MapPath("~/Upload/BlogImage/") + name);
            if (HttpContext.Session["ImageName"] != null)
            {
                HttpContext.Session["ImageName"] = null;
            }
            HttpContext.Session["ImageName"] = name;
            return name;
        }
    }
}