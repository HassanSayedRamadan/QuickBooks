using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class InvoiceResponse
    {
        public DateTime time { get; set; }
        public InvoiceQueryResponse QueryResponse { get; set; }
    }
}