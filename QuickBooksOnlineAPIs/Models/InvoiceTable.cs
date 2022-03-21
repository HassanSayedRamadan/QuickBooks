using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class InvoiceTable
    {
        public string DocNumber { get; set; }
        public string CustomerName { get; set; }
        public string Balance { get; set; }
        public string Total { get; set; }
        public string Date { get; set; }
        public string DueDate { get; set; }
        public string Id { get; set; }
    }
}