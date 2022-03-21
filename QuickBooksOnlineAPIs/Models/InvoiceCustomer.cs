using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class InvoiceCustomer
    {
        public List<Line> Line { get; set; }
        public List<CustomerModel> Customers { get; set; }
        [Required]
        [Display(Name = "Customer")]
        public string CustomerID { get; set; }
    }
}