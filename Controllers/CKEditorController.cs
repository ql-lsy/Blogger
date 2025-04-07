using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogger.Controllers
{
    public class CKEditorController : Controller
    {
        // GET: CKEditor
        public ActionResult Upload()
        {
            var File=Request.Files[0];
            string filename = File.FileName;
            string suffix = filename.Remove(0, filename.LastIndexOf(".") - 1);
            string name = "File" + DateTime.Now.ToString().Replace("/", ".").Replace(" ", "-").Replace(":", "-") + suffix;
            if (File.ContentLength > 10485760)
            {
                return Json(new { error = "上传异常,图片过大", uploaded = 0 });
            }
            File.SaveAs(Server.MapPath("~/Upload/BlogCkeditor/") + name);
            string Url = "/Upload/BlogCkeditor/" + name;
            if (HttpContext.Session["BlogCkeditor"] != null)
            {
                HttpContext.Session["BlogCkeditor"] = null;
            }
            HttpContext.Session["BlogCkeditor"] = name;
            return Json(new { uploaded=1, url=Url });
        }
    }
}