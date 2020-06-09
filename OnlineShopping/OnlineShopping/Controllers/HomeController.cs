using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models.Operation;
using OnlineShopping.Models;
using OnlineShopping.Models.ViewModel;
using System.Text;

namespace OnlineShopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductOperation _ProudctOperation = new ProductOperation();
        private readonly MemberOperation _MemberOperation = new MemberOperation();
        private readonly OrderDetailsOperation _OrderDetailsOperation = new OrderDetailsOperation();
        private readonly OrderOperation _OrderOperation = new OrderOperation();
        // GET: Home

        protected override void Dispose(bool disposing)
        {
            _ProudctOperation.DBDispose();
            _MemberOperation.DBDispose();
            _OrderDetailsOperation.DBDispose();
            _OrderOperation.DBDispose();
            base.Dispose(disposing);    
        }

        public ActionResult Index()
        {
            IQueryable<Products> ProductList = _ProudctOperation.ListAll();
            if (Session["Member"] == null)
            {
                return View("Index", "_Layout", ProductList.ToList());
            }

            return View("Index","LayoutMember",ProductList.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Members oMembers)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Members oMember = _MemberOperation.ReadByEmail(oMembers.Email);
            if (oMember == null)
            {
               bool CreateResult=  _MemberOperation.Create(oMembers);
                if (CreateResult)
                {
                    return RedirectToAction("Login");
                }
            }

            ViewBag.Message = "此帳號已有人使用";
            return View();

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email,string Pwd)
        {
            Members oMember = _MemberOperation.Login(Email, Pwd);
            if (oMember == null)
            {
                ViewBag.Message = "帳號密碼有誤，請再重新確認";
                return View();
            }

            Session["WelCome"] = oMember.Name + "歡迎光臨";
            Session["Member"] = oMember;
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult ShoppingCar()
        {
            if (Session["Member"] == null)
            {
                return RedirectToAction("Index");
            }

            int MemberId = ((Members)Session["Member"]).Id;
            IQueryable<OrderDetails> oShoppingCarItems = _OrderDetailsOperation.ShoppingCarItems(MemberId);
            foreach (OrderDetails item in oShoppingCarItems)
            {
                Products oProducts = _ProudctOperation.ReadByProductID(item.PId);
                item.PName = oProducts.Name;
                item.PPrice = oProducts.Price;
            }

            if (oShoppingCarItems.Count() == 0)
            {
                return RedirectToAction("Index");
            }

            return View("ShoppingCar", "LayoutMember", oShoppingCarItems);
        }

        [HttpPost]
        public ActionResult ShoppingCar(Orders oOrders)
        {
            int MemberId = ((Members)Session["Member"]).Id;
            string guid = Guid.NewGuid().ToString();
            oOrders.MemberId = MemberId;
            oOrders.OrderId = guid;
            oOrders.OrderDate = DateTime.Now;
            bool AddHeaderResult = _OrderOperation.Create(oOrders);
            if (!AddHeaderResult)
            {
                return RedirectToAction("ShoppingCar");
            }

            _OrderDetailsOperation.UpdateDetailsOrderID(MemberId, guid);

            //IQueryable<OrderDetails> oShoppingCarItems = _OrderDetailsOperation.ShoppingCarItems(MemberId);

            //foreach (OrderDetails item in oShoppingCarItems)
            //{
            //    item.OrderId = guid;
            //    item.IsApproved = 1;

            //    _OrderDetailsOperation.Update(item);
            //}

            return RedirectToAction("OrderList");
        }


        public ActionResult AddCar(string Pid)
        {
            if (Session["Member"] == null)
            {
                return RedirectToAction("Login");
            }

            if (string.IsNullOrWhiteSpace(Pid))
            {
                return RedirectToAction("Index");
            }

            int MemberId = ((Members)Session["Member"]).Id;
            OrderDetails oShoppingCarItem = _OrderDetailsOperation.CurrentCar(Pid, MemberId);
            if (oShoppingCarItem == null)
            {
                Products oProducts = _ProudctOperation.ReadByProductID(Pid);
                OrderDetails oOrdreDetails = new OrderDetails()
                {
                    MemberId = MemberId,
                    PId = oProducts.PId,
                    Qty = 1,
                    IsApproved = 0,

                };

                _OrderDetailsOperation.Create(oOrdreDetails);
            }
            else
            {
                oShoppingCarItem.Qty += 1;
                _OrderDetailsOperation.Update(oShoppingCarItem);
            }
            return RedirectToAction("ShoppingCar");
        }

        public ActionResult DeleteCar(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index"); 
            }

            _OrderDetailsOperation.Delete(Id);
            return RedirectToAction("ShoppingCar");

        }

        public ActionResult OrderList(string OrderId)
        {
            if (Session["Member"] == null)
            {
                return RedirectToAction("Login");
            }

            int MemberId = ((Members)Session["Member"]).Id;

            IQueryable<OrderDetails> oOrderDetailsList = null;

            if (!string.IsNullOrWhiteSpace(OrderId))
            {
                oOrderDetailsList = _OrderDetailsOperation.ReadByOrderID(OrderId);
                foreach (OrderDetails item in oOrderDetailsList)
                {
                    Products oProducts = _ProudctOperation.ReadByProductID(item.PId);
                    item.PName = oProducts.Name;
                    item.PPrice = oProducts.Price;
                    item.Image = oProducts.Image;
                }
            }

            VMOrdersDetails oVMOrdersDetails = new VMOrdersDetails()
            {
                OrderList = _OrderOperation.ReadByMemberId(MemberId),
                OrderDetailsList = oOrderDetailsList
            };
            //IQueryable<Orders> OrderList = _OrderOperation.ReadByMemberId(MemberId);

            return View("OrderList", "LayoutMember", oVMOrdersDetails);
        }

        public ActionResult OrderDetail(string OrderId)
        {
            if (string.IsNullOrWhiteSpace(OrderId))
            {
                return RedirectToAction("Index");
            }

            IQueryable<OrderDetails> OrderDetailsList = _OrderDetailsOperation.ReadByOrderID(OrderId);
            foreach (OrderDetails item in OrderDetailsList)
            {
                Products oProducts = _ProudctOperation.ReadByProductID(item.PId);
                item.PName = oProducts.Name;
                item.PPrice = oProducts.Price;
            }
            return View("OrderDetail", "LayoutMember", OrderDetailsList);
        }
    }
}