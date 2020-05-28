using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Demo.Models.Interface;

namespace WebAPI_Demo.Models.Operation
{
    public class CustomerOperation : ICRUD<tCustomer>
    {
        private readonly CustomerEntities _db = new CustomerEntities();
        // 建立客戶資料
        public bool Create(tCustomer oCustomer)
        {
            try
            {
                _db.DbSetCusomter.Add(oCustomer);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //刪除客戶資料
        public bool Delete(int Id)
        {
            try
            {
                tCustomer oCustomer = _db.DbSetCusomter.Find(Id);
                _db.DbSetCusomter.Remove(oCustomer);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //透過Id取得客戶資料
        public tCustomer ReadById(int? Id)
        {
            try
            {
                tCustomer oCustomer = _db.DbSetCusomter.Where(s => s.fId == Id).FirstOrDefault();
                return oCustomer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //更新客戶資料
        public bool Update(tCustomer oCustomer)
        {
            try
            {
                _db.Entry(oCustomer).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //取得全部客戶資料列表
        public IQueryable<tCustomer> ListAll()
        {
            try
            {
                IQueryable<tCustomer> CustomerList = from _CustomerList in _db.DbSetCusomter
                                                 select _CustomerList;
                return CustomerList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // 透過關鍵字取得多筆客戶資料
        public IQueryable<tCustomer> ReadByKeyword(string Keyword)
        {
            try
            {
                IQueryable<tCustomer> CustomerList = from _CustomerList in _db.DbSetCusomter
                                                     where (_CustomerList.fName.Contains(Keyword)
                                                     || _CustomerList.fEmail.Contains(Keyword)
                                                     || _CustomerList.fPhone.Contains(Keyword)
                                                     )
                                                 select _CustomerList;
                return CustomerList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}