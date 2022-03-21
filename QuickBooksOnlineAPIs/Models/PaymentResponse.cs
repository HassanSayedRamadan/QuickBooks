using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class PaymentResponse
    {
        public PaymentQueryResponse QueryResponse { get; set; }
        public DateTime time { get; set; }
    }
}