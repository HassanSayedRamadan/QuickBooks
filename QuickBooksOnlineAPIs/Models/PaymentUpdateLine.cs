using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class PaymentUpdateLine
    {
        public double Amount { get; set; }
        public List<LinkedTxn> LinkedTxn { get; set; }
    }
}