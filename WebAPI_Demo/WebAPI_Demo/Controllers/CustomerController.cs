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
        // GET: api/Customer
        public IQueryable<tCustomer> Get()
        {
            IQueryable<tCustomer> CustomerList = _CustomerOperation.ListAll();
            return CustomerList;

        }

        // GET: api/Customer/5
        public tCustomer Get(int Id)
        {
            tCustomer oCustomer =  _CustomerOperation.ReadById(Id);
            return oCustomer;
        }

        // Post: api/Customer/
        public IQueryable<tCustomer> GetCustomSearch(string Keyword)
        {
            IQueryable<tCustomer> CustomerList = _CustomerOperation.ReadByKeyword(Keyword);
            return CustomerList;
        }

        // POST: api/Customer
        public bool Post(tCustomer oCustomer)
        {
            bool AddResult = _CustomerOperation.Create(oCustomer);
            return AddResult;
        }

        // PUT: api/Customer/
        public bool Put(tCustomer oCustomer)
        {
            bool UpdateResult = _CustomerOperation.Update(oCustomer);
            return UpdateResult;
        }

        // DELETE: api/Customer/1
        public bool Delete(int Id)
        {
            bool DeleteResult = _CustomerOperation.Delete(Id);
            return DeleteResult;
        }
    }
}
