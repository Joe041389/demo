using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UploadImg.Models;
using UploadImg.Operation;

namespace UploadImg.Controllers
{
    public class HomeController : Controller
    {
        private readonly ImageOperation _ImageOperation = new ImageOperation();
        public ActionResult Index()
        {
            return View();
        }
    }
}