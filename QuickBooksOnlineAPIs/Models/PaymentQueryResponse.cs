using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class PaymentQueryResponse
    {
        public List<PaymentModel> Payment { get; set; }
        public double startPosition { get; set; }
        public double maxResults { get; set; }
    }
}