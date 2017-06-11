using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPL.Controllers
{
    public class ChangeController : Controller
    {
        private IService<ImageEntity> imageService;

        public ChangeController(IService<ImageEntity> _imageService)
        {
            imageService = _imageService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FileUpload()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FileUpload(HttpPostedFileBase uploadFile, int postId)
        {
            if (uploadFile.ContentLength > 0)
            {
                string relativePath = "~/img/" + Path.GetFileName(uploadFile.FileName);
                string physicalPath = Server.MapPath(relativePath);
                uploadFile.SaveAs(physicalPath);
                imageService.Create(new ImageEntity()
                {
                    Path = relativePath,
                    PostId = postId
                });
                return View((object)relativePath);
            }
            return View();
        }
    }
}