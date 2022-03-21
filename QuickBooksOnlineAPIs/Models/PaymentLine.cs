using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class PaymentLine
    {
        public double Amount { get; set; }
        public List<LinkedTxn> LinkedTxn { get; set; }
        public LineEx LineEx { get; set; }
    }
}