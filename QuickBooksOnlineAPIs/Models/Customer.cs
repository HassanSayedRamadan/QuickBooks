using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class Customer
    {
        [Required]
        [Display(Name = "Fully Qualified Name")]
        public string FullyQualifiedName { get; set; }
        [Required]
        public PrimaryEmailAddr PrimaryEmailAddr { get; set; }
        [Required]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }
        [Required]
        public string Suffix { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        [Display(Name = "Family Name")]
        public string FamilyName { get; set; }
        [Required]
        public PrimaryPhone PrimaryPhone { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        public BillAddr BillAddr { get; set; }
        [Required]
        [Display(Name = "Given Name")]
        public string GivenName { get; set; }
    }
}