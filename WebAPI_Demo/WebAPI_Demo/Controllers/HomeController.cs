using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI_Demo.Models;
using WebAPI_Demo.Models.Operation;

namespace WebAPI_Demo.Controllers
{
    public class HomeController : Controller
    {
        public readonly CustomerOperation _CustomerOperation = new CustomerOperation();
        // GET: Home
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int? Id)
        {
            if (Id != null)
            {
                tCustomer oCusomter = _CustomerOperation.ReadById(Id);
                return View(oCusomter);
            }
            else {
                return RedirectToAction("List");
            }
            
        }

        public ActionResult Delete(int? Id)
        {
            if (Id != null)
            {
                tCustomer oCusomter = _CustomerOperation.ReadById(Id);
                return View(oCusomter);
            }
            else
            {
                return RedirectToAction("List");
            }
        }
    }
}