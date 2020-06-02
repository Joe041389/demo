using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models.ViewModel
{
    public class VMOrdersDetails
    {
        public IEnumerable<Orders> OrderList { get; set; }

        public IEnumerable<OrderDetails> OrderDetailsList { get; set; }
    }
}