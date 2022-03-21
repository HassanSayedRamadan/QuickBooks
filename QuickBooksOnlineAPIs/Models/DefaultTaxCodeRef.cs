using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class DefaultTaxCodeRef
    {
        [Required]
        [Display(Name = "Value")]
        public string value { get; set; }
    }
}