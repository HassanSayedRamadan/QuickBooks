using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class PrimaryPhone
    {
        [Required]
        [Display(Name = "Free Form Number")]
        public string FreeFormNumber { get; set; }
    }
}