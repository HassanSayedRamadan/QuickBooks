using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class QueryResponse
    {
        public List<CustomerModel> Customer { get; set; }
        public double startPosition { get; set; }
        public double maxResults { get; set; }
    }
}