using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class BillAddr
    {
        [Required]
        [Display(Name = "Country Sub Division Code")]
        public string CountrySubDivisionCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        public string Line1 { get; set; }
        [Required]
        public string Country { get; set; }
        public string Id { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}