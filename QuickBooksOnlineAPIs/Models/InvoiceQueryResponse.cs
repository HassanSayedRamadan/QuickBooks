using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class InvoiceQueryResponse
    {
        public List<InvoiceModel> Invoice { get; set; }
        public double startPosition { get; set; }
        public double maxResults { get; set; }
        public double totalCount { get; set; }
    }
}