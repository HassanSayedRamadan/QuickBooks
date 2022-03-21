using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class InvoiceLine
    {
        public string Id { get; set; }
        public double LineNum { get; set; }
        public double Amount { get; set; }
        public string DetailType { get; set; }
        public SalesItemLineDetail SalesItemLineDetail { get; set; }
        public string SubTotalLineDetail { get; set; }
        public string Description { get; set; }
        public List<LinkedTxn2> LinkedTxn { get; set; }
        public DiscountLineDetail DiscountLineDetail { get; set; }

    }
}