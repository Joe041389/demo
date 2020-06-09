using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Demo.Models;
using WebAPI_Demo.Models.Operation;

namespace WebAPI_Demo.Controllers
{
    public class CustomerController : ApiController
    {
        public readonly CustomerOperation _CustomerOperation = new CustomerOperation();
        
        /// <summary>
        /// 取得顧客列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("List")]
        // GET: api/Customer
        public IQueryable<tCustomer> Get()
        {
            IQueryable<tCustomer> CustomerList = _CustomerOperation.ListAll();
            return CustomerList;

        }

        /// <summary>
        /// 透過顧客ID取得顧客資料
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetByID")]
        // GET: api/Customer/5
        public tCustomer Get(int Id)
        {
            tCustomer oCustomer =  _CustomerOperation.ReadById(Id);
            return oCustomer;
        }

        /// <summary>
        /// 透過關鍵字取得顧客資料
        /// </summary>
        /// <param name="Keyword"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetByKeyword")]
        // GET: api/Customer/xxxx
        public IQueryable<tCustomer> GetCustomSearch(string Keyword)
        {
            IQueryable<tCustomer> CustomerList = _CustomerOperation.ReadByKeyword(Keyword);
            return CustomerList;
        }


        /// <summary>
        /// 新增顧客資料
        /// </summary>
        /// <param name="oCustomer"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Add")]
        // POST: api/Customer
        public bool Post(tCustomer oCustomer)
        {
            bool AddResult = _CustomerOperation.Create(oCustomer);
            return AddResult;
        }

        /// <summary>
        /// 修改顧客資料
        /// </summary>
        /// <param name="oCustomer"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Edit")]
        // PUT: api/Customer/
        public bool Put(tCustomer oCustomer)
        {
            bool UpdateResult = _CustomerOperation.Update(oCustomer);
            return UpdateResult;
        }


        /// <summary>
        /// 刪除顧客資料
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Delete")]
        // DELETE: api/Customer/1
        public bool Delete(int Id)
        {
            bool DeleteResult = _CustomerOperation.Delete(Id);
            return DeleteResult;
        }
    }
}
