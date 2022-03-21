using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class TaxLine
    {
        public double Amount { get; set; }
        public string DetailType { get; set; }
        public TaxLineDetail TaxLineDetail { get; set; }
    }
}