using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class CustomerResponse
    {
        public DateTime time { get; set; }
        public QueryResponse QueryResponse { get; set; }
    }
}