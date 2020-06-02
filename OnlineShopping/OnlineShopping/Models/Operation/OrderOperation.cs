using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping.Models.Interface;

namespace OnlineShopping.Models.Operation
{
    public class OrderOperation : ICRUD<Orders>
    {
        private readonly OnlineShoppingEntities _db = new OnlineShoppingEntities();
        public bool Create(Orders oOrder)
        {
            try
            {
                _db.DbSetOrders.Add(oOrder);
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
                Orders oOrder = _db.DbSetOrders.Find(Id);
                _db.DbSetOrders.Remove(oOrder);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Orders> ListAll()
        {
            try
            {
                IQueryable<Orders> OrderList = from _OrderList in _db.DbSetOrders
                                               select _OrderList;
                return OrderList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Orders ReadById(int? Id)
        {
            try
            {
                Orders oOrder = _db.DbSetOrders.Where(s => s.Id == Id).FirstOrDefault();
                return oOrder;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Orders> ReadByMemberId(int Mid)
        {
            try
            {
                IQueryable<Orders> OrderList = from _OrderList in _db.DbSetOrders
                                               where (_OrderList.MemberId == Mid)
                                               select _OrderList;

                 return OrderList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Orders> ReadByKeyword(string Keyword)
        {
            IQueryable<Orders> OrderList = from _OrderList in _db.DbSetOrders
                                           where (_OrderList.ReceiverEmail.Contains(Keyword)
                                           || _OrderList.RecevierAddr.Contains(Keyword)
                                           || _OrderList.Receiver.Contains(Keyword)
                                           )
                                           select _OrderList;
            return OrderList;
        }

        public bool Update(Orders oOrder)
        {
            try
            {
                _db.Entry(oOrder).State = System.Data.Entity.EntityState.Modified;
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