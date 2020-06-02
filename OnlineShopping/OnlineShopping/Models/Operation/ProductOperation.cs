using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping.Models.Interface;

namespace OnlineShopping.Models.Operation
{
    public class ProductOperation : ICRUD<Products>
    {
        private readonly OnlineShoppingEntities _db = new OnlineShoppingEntities();
        public bool Create(Products oProducts)
        {
            try
            {
                _db.DbSetProducts.Add(oProducts);
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
                Products oProducts = _db.DbSetProducts.Find(Id);
                _db.DbSetProducts.Remove(oProducts);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Products> ListAll()
        {
            try
            {
                IQueryable<Products> ProductList = from _ProductList in _db.DbSetProducts
                                                            select _ProductList;
                return ProductList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Products ReadById(int? Id)
        {
            try
            {
                Products oProducts = _db.DbSetProducts.Where(s => s.Id == Id).FirstOrDefault();
                return oProducts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Products ReadByProductID(string Pid)
        {
            try
            {
                Products oProducts = _db.DbSetProducts.Where(s => s.PId == Pid).FirstOrDefault();
                return oProducts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Products> ReadByKeyword(string Keyword)
        {
            IQueryable<Products> ProductList = from _ProductList in _db.DbSetProducts
                                           where (_ProductList.Name.Contains(Keyword) )
                                           select _ProductList;
            return ProductList;
        }

        public bool Update(Products oProducts)
        {
            try
            {
                _db.Entry(oProducts).State = System.Data.Entity.EntityState.Modified;
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