using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UploadImg.Models;

namespace UploadImg.Interface
{
    interface IImage
    {
        // 儲存實體檔案
        void SaveImage(tb_image oImage);

        // 移除實體檔案
        void RemoveImage(tb_image oImage);

        // 新增圖檔
       
    }
}
