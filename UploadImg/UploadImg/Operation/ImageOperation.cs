using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using UploadImg.Interface;
using UploadImg.Models;


namespace UploadImg.Operation
{
    public class ImageOperation : IImage, ICRUD<tb_image>
    {
        // 宣告 資料庫連線類別變數
        private readonly DemoEntities _db = new DemoEntities();

        //新增圖檔
        public bool Create(tb_image oImage)
        {
            try
            {
                _db.DbSetImage.Add(oImage);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //刪除圖檔
        public bool Delete(int? Id)
        {
            try
            {
                tb_image oImage = _db.DbSetImage.Find(Id);
                _db.DbSetImage.Remove(oImage);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //透過Id讀取圖檔
        public tb_image Read(int? Id)
        {
            try
            {
                tb_image oImage = _db.DbSetImage.Where(s => s.ImageId == Id).FirstOrDefault();
                return oImage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //更新圖檔
        public bool Update(tb_image oImage)
        {
            try
            {
                _db.Entry(oImage).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //透過Keyword讀取圖檔
        public IQueryable<tb_image> ReadByKeyword(string Keyword)
        {
            try
            {
                IQueryable<tb_image> ImageList = from _ImageList in _db.DbSetImage
                                                 where _ImageList.Title.Contains(Keyword)
                                                 select _ImageList;
                return ImageList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //圖檔List
        public IQueryable<tb_image> ListAll()
        {
            try
            {
                IQueryable<tb_image> ImageList = from _ImageList in _db.DbSetImage
                                                 select _ImageList ;
                return ImageList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //儲存實體檔案
        public void SaveImage(tb_image oImage)
        {
            try
            {
                // 取得不包含附檔名的圖檔
                string FileName = Path.GetFileNameWithoutExtension(oImage.ImageFile.FileName);

                //取得圖檔檔名
                string Extension = Path.GetExtension(oImage.ImageFile.FileName);

                //變更圖檔檔名，避免檔名重複
                FileName = FileName + DateTime.Now.ToString("yymmssfff") + Extension;

                oImage.ImagePath = "/UploadImg/" + FileName;

                oImage.ImageFile.SaveAs(Path.Combine(HttpContext.Current.Server.MapPath("~/UploadImg/"),FileName));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //刪除實體檔案
        public void RemoveImage(tb_image oImage)
        {
            try
            {
                string ImagePath =  HttpContext.Current.Server.MapPath(oImage.ImagePath);
                FileInfo file = new FileInfo(ImagePath);
                if (file.Exists)
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DbDispose()
        {
            _db.Dispose();
        }
    }
}