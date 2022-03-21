using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class Line
    {
        [Required]
        [Display(Name = "Detail Type")]
        public string DetailType { get; set; }
        [Required]
        public double Amount { get; set; }
        public SalesItemLineDetail SalesItemLineDetail { get; set; }
    }
}