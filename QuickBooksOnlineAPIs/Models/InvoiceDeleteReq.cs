using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class InvoiceDeleteReq
    {
        public string SyncToken { get; set; }
        public string Id { get; set; }
    }
}