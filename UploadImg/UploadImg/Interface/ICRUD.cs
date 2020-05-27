using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadImg.Interface
{
    interface ICRUD<M> where M: class,new()
    {
        bool Create(M Item);

        //讀取圖檔
        M Read(int? Id);

        IQueryable<M> ReadByKeyword(string Keyword);

        //刪除圖檔
        bool Update(M Item);

        //刪除圖檔
        bool Delete(int? Id);

        IQueryable<M> ListAll();

        void DbDispose();
    }
}
