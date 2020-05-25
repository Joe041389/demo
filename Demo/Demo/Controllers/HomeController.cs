using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using Demo.Services;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        location_service location_operation = new location_service();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Demo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Demo_add_data(string dt, List<dt_value> dt_values)
        {
            bool add_bool = location_operation.add_value(dt, dt_values);
            //return View();
            return Json(add_bool, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}