using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class TaxLineDetail
    {
        public TaxRateRef TaxRateRef { get; set; }
        public bool PercentBased { get; set; }
        public double TaxPercent { get; set; }
        public double NetAmountTaxable { get; set; }
    }
}