using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class InvoiceSalesItemLineDetail
    {
        public ItemRef ItemRef { get; set; }
        public ItemAccountRef ItemAccountRef { get; set; }
        public TaxCodeRef TaxCodeRef { get; set; }
        public double? UnitPrice { get; set; }
        public double? Qty { get; set; }
        public string ServiceDate { get; set; }
    }
}