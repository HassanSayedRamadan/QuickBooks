using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class Invoice
    {
        public List<Line> Line { get; set; }
        public CustomerRef CustomerRef { get; set; }
    }
}