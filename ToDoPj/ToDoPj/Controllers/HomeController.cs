using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ToDoPj.Models;
using ToDoPj.Models.Operation;

namespace ToDoPj.Controllers
{
    public class HomeController : Controller
    {
        ToDoOperation _ToDoOperation = new ToDoOperation();

        // 關閉資料庫連線
        protected override void Dispose(bool disposing)
        {
            ToDoDBContext _db = _ToDoOperation.GetDBContext();
            _db.Dispose();
            base.Dispose(disposing);
        }
        

        // Get: ToDoList
        public ActionResult Index()
        {
            IQueryable<tToDo> ToDoList = _ToDoOperation.ListAll();
            return View(ToDoList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tToDo oToDo)
        {
            if (oToDo != null && ModelState.IsValid)
            {
                bool CreateResult = _ToDoOperation.Create(oToDo);
                return RedirectToAction("Index");
            }
            else {
                return View();
            }
            
        }

        public ActionResult ReadByKeyword()
        {
            return View();
        }


        [HttpPost,ActionName("ReadByKeyword")]
        [ValidateAntiForgeryToken]
        public ActionResult ReadByKeywordResult(tToDo oToDo)
        {
            var Title = oToDo.fTitle;
            var Image = oToDo.fImage;
            var Weights = "";
            switch (Image)
            {
                case "1.png":
                    Weights = "普通";
                    break;
                case "0.png":
                    Weights = "重要";
                    break;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("搜尋條件:");
            if (!string.IsNullOrWhiteSpace(Title))
            {
                sb.Append(Title);
                sb.Append("、");
            }

            if (!string.IsNullOrWhiteSpace(Image))
            {
                sb.Append(Weights);
            }

            IQueryable<tToDo> ToDoList = _ToDoOperation.ReadByKeyword(oToDo);

            if (ToDoList.ToList().Count == 0)
            {
                sb.Append(" 查無資料");
                ViewBag.SearchResult = sb.ToString();
                return View("ReadByKeyword");
            }

            sb.Append(" 結果如下");
            ViewBag.SearchResult = sb.ToString();
            return View("ReadByKeywordResult", ToDoList);
        }


        public ActionResult ReadByID(int Id=1)
        {

            tToDo oToDo = _ToDoOperation.ReadById(Id);
            return View(oToDo);
        }

  
        public ActionResult Update(int Id=1)
        {
            tToDo oToDo = _ToDoOperation.ReadById(Id);
            return View(oToDo);
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateConfirm(tToDo oToDo)
        {
            if (oToDo != null && ModelState.IsValid)
            {
                _ToDoOperation.Update(oToDo);
                return RedirectToAction("Index");
            }

            return View();

        }

        public ActionResult Delete(int Id)
        {
            _ToDoOperation.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}