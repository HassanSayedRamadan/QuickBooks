using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class Payment
    {
        public double TotalAmt { get; set; }
        public CustomerRef CustomerRef { get; set; }
    }
}