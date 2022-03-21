using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class Account
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Account Type")]
        public string AccountType { get; set; }
    }
}