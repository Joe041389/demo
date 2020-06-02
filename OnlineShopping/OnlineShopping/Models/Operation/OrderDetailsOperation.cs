using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping.Models.Interface;

namespace OnlineShopping.Models.Operation
{
    public class OrderDetailsOperation : ICRUD<OrderDetails>
    {
        private readonly OnlineShoppingEntities _db = new OnlineShoppingEntities();
        public bool Create(OrderDetails oOrderDetails)
        {
            try
            {
                _db.DbSetOrderDetails.Add(oOrderDetails);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(int? Id)
        {
            try
            {
                OrderDetails oOrderDetails = _db.DbSetOrderDetails.Find(Id);
                _db.DbSetOrderDetails.Remove(oOrderDetails);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<OrderDetails> ListAll()
        {
            try
            {
                IQueryable<OrderDetails> OrderDetailsList = from _OrderDetailsList in _db.DbSetOrderDetails
                                                            select _OrderDetailsList;
                return OrderDetailsList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public OrderDetails ReadById(int? Id)
        {
            try
            {
                OrderDetails oOrderDetails = _db.DbSetOrderDetails.Where(s => s.Id == Id).FirstOrDefault();
                return oOrderDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<OrderDetails> ReadByOrderID(string oId)
        {
            try
            {
                IQueryable<OrderDetails> OrderDetailsLsit = _db.DbSetOrderDetails.Where(s => s.OrderId == oId);
                return OrderDetailsLsit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<OrderDetails> ReadByKeyword(string Keyword)
        {
            throw new NotImplementedException();
        }


        public OrderDetails CurrentCar(string Pid,int MemberId)
        {
            OrderDetails oOrderDetails = _db.DbSetOrderDetails
                .Where(
                m => m.PId == Pid && 
                m.MemberId == MemberId &&
                m.IsApproved == 0).FirstOrDefault();
            return oOrderDetails;
        }

        public IQueryable<OrderDetails> ShoppingCarItems(int MemberId)
        {
            IQueryable<OrderDetails> ShoppingCarItems = from _ShoppingCarItems in _db.DbSetOrderDetails
                                                        where _ShoppingCarItems.MemberId == MemberId && _ShoppingCarItems.IsApproved == 0
                                                        select _ShoppingCarItems;

            return ShoppingCarItems;
        }

    
        public bool UpdateDetailsOrderID(int MemberId,string guid)
        {
            IQueryable<OrderDetails> ShoppingCarItems = from _ShoppingCarItems in _db.DbSetOrderDetails
                                                        where _ShoppingCarItems.MemberId == MemberId && _ShoppingCarItems.IsApproved == 0
                                                        select _ShoppingCarItems;

            foreach (OrderDetails item in ShoppingCarItems)
            {
                item.OrderId = guid;
                item.IsApproved = 1;
            }
            _db.SaveChanges();
            return true;
        }

        public bool Update(OrderDetails oOrderDetails)
        {
            try
            {
                _db.Entry(oOrderDetails).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DBDispose()
        {
            _db.Dispose();
        }
    }
}