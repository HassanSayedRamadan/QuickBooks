using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class TxnTaxDetail
    {
        public double TotalTax { get; set; }
        public TxnTaxCodeRef TxnTaxCodeRef { get; set; }
        public List<TaxLine> TaxLine { get; set; }
    }
}