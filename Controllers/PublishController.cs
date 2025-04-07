using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogger.Controllers
{
    public class PublishController : Controller
    {
        // GET: Publish
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult BlogCkeditor()
        {
            return View();
        }
        public ActionResult Resource()
        {
            return View();
        }
        public ActionResult Issue()
        {
            return View();
        }

        public ActionResult Update()
        { return View(); }

        [HttpPost]
        public ActionResult Upload()
        {
            string path = "~/Upload/Update/";
            try
            {
                var file = Request.Files[0]; //获取选中文件  
                var filecombin = file.FileName.Split('.');
                if (file == null || String.IsNullOrEmpty(file.FileName) || file.ContentLength == 0 || filecombin.Length < 2)
                {
                    return Json(new { msg = "上传出错", code = 1 });
                }

                //项目相对路径
                string local = path.Replace("~/", "").Replace('/', '\\');
                //物理路径
                string localPath = Path.Combine(HttpRuntime.AppDomainAppPath, local);
                //文件名称
                var saveName = file.FileName;
                //扩展名
                var extension = filecombin[filecombin.Length - 1];
                string Url = saveName;
                FileInfo fl = new FileInfo(Url);
                string path1 = fl.Extension;
                string name = saveName.Substring(saveName.LastIndexOf("\\") + 1, (saveName.LastIndexOf(".") - saveName.LastIndexOf("\\") - 1));
                //新名称(GUID格式)
                var uName = (name + DateTime.Now.ToString() + path1).Replace(":", "-").Replace(" ", "-").Replace("/", "-");
                //判断文件存放路径是否存在
                if (!System.IO.Directory.Exists(localPath))
                {
                    System.IO.Directory.CreateDirectory(localPath);
                }
                //文件保存路径
                string localURL = Path.Combine(local, uName + "." + extension);
                //保存文件
                file.SaveAs(Path.Combine(localPath, uName + "." + extension));

                return Json(new { msg = "上传成功", code = 0, Name = saveName, uName1 = uName });

            }
            catch (Exception e)
            {
                return Json(new { msg = "上传异常" + e.Message, code = 1 });
            }

        }
    }
}