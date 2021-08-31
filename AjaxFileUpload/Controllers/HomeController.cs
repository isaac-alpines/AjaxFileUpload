using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxFileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (Directory.Exists(Server.MapPath("~/Files")) == false)
                    Directory.CreateDirectory(Server.MapPath("~/Files"));

                file.SaveAs(Path.Combine(Server.MapPath("~/Files"), file.FileName));

                return Json(new { hasError = false, message = "File upload success..!"  });
            }

            return Json(new { hasError = true });
        }
    }
}