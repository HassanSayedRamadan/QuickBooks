using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class PaymentTable
    {
        public string CustomerName { get; set; }
        public string Total { get; set; }
        public string Date { get; set; }
        public string Id { get; set; }
        public bool Delete { get; set; }
    }
}