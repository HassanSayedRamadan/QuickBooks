using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class DiscountLineDetail
    {
        public bool PercentBased { get; set; }
        public double DiscountPercent { get; set; }
        public DiscountAccountRef DiscountAccountRef { get; set; }
    }
}