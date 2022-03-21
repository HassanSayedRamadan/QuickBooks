using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class Any
    {
        public string name { get; set; }
        public string declaredType { get; set; }
        public string scope { get; set; }
        public ValueClass value { get; set; }
        public bool nil { get; set; }
        public bool globalScope { get; set; }
        public bool typeSubstituted { get; set; }
    }
}