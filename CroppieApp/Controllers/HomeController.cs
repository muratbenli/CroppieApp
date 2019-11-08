using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CroppieApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveImage(string ImgBase64)
        {
            byte[] data = Convert.FromBase64String(ImgBase64.Substring(22));
            string fileName = Guid.NewGuid() + ".jpg";
            string savePath = Path.Combine(
                Server.MapPath("~/Upload"), fileName
                );
            System.IO.File.WriteAllBytes(savePath, data);

            return RedirectToAction("ShowImage", new { FileName = fileName});
        }

        public ActionResult ShowImage(string fileName)
        {
            ViewBag.fileName = fileName;
            return View();
        }
    }
}