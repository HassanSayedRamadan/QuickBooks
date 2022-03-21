using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class PaymentDeleteReq
    {
        public string SyncToken { get; set; }
        public string Id { get; set; }
    }
}