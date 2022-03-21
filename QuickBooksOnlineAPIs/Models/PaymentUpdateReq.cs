using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class PaymentUpdateReq
    {
        public string SyncToken { get; set; }
        public PaymentMethodRef PaymentMethodRef { get; set; }
        public string PaymentRefNum { get; set; }
        public bool sparse { get; set; }
        public List<PaymentUpdateLine> Line { get; set; }
        public CustomerRef CustomerRef { get; set; }
        public string Id { get; set; }
        public MetaData MetaData { get; set; }
    }
}