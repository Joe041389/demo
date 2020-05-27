using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UploadImg.Models;
using UploadImg.Operation;

namespace UploadImage.Controllers
{
    public class UploadController : Controller
    {
        private readonly ImageOperation _ImageOperation = new ImageOperation();


        protected override void Dispose(bool disposing)
        {
            _ImageOperation.DbDispose();
            base.Dispose(disposing);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            Redirect("http://localhost:56956/");

            base.HandleUnknownAction(actionName);
        }

        public ActionResult List(string search)
        {
            IQueryable<tb_image> ImageList;
            if (!string.IsNullOrWhiteSpace(search))
            {
                ImageList = _ImageOperation.ReadByKeyword(search);
            }
            else
            {
                ImageList = _ImageOperation.ListAll();
               
            }
            return View(ImageList.ToList());
        }

        // GET: Upload
        public ActionResult SaveImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveImage(tb_image Image)
        {
            if (Image != null &&　ModelState.IsValid)
            {
                if (Image.ImageFile.ContentLength > 0)
                {
                    _ImageOperation.SaveImage(Image);
                    bool UploadResult = _ImageOperation.Create(Image);
                    if (UploadResult)
                    {
                        ViewBag.Result = "檔案上傳成功";
                    }
                    else
                    {
                        ViewBag.Result = "檔案上傳失敗";
                    }
                }
                else
                {
                    ViewBag.Result = "無效的檔案";
                }
                return View();
            }
            else
            {
                ViewBag.Result = "無效的檔案";
                return View();
            }
        }

        public ActionResult Edit(int? Id)
        {
            if (Id != null)
            {
                tb_image oImage = _ImageOperation.Read(Id);
                return View(oImage);
            }
            else
            {
                return RedirectToAction("List");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_image oImage)
        {

            if (oImage != null && ModelState.IsValid)
            {
                if (oImage.ImageFile != null)
                {
                    _ImageOperation.SaveImage(oImage);
                    bool UploadResult = _ImageOperation.Update(oImage);
                    if (UploadResult)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ViewBag.Result = "檔案上傳失敗";
                    }
                }
                else
                {
                    bool UploadResult = _ImageOperation.Update(oImage);
                    if (UploadResult)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ViewBag.Result = "資料更新失敗";
                    }
                }
                return View();
            }
            else
            {
                ViewBag.Result = "無效的檔案";
                return View();
            }
        }

        public ActionResult Details(int? Id)
        {
            if (Id != null)
            {
                tb_image oImage = _ImageOperation.Read(Id);
                return View(oImage);
            }
            else
            {
                return RedirectToAction("List");
            }
            
        }

        public ActionResult Delete(int? Id)
        {
            if (Id != null)
            {
                tb_image oImage = _ImageOperation.Read(Id);
                if (oImage != null)
                {
                    _ImageOperation.RemoveImage(oImage);
                }
                _ImageOperation.Delete(Id);

            }
           
            return RedirectToAction("List");
           
        }

    }
}