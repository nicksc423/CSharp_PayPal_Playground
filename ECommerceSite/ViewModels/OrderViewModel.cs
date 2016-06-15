using ECommerceSite.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSite.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string City { get; set; }

        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [IntegerLength(10)]
        public int PostalCode { get; set; }

        [Display(Name = "Credit Card")]
        [Required]
        [CreditCard]
        public string CreditCardNumber { get; set; }

        [Required]
        public int CSC { get; set; }

        [Display(Name = "Credit Card Type")]
        public string CcType { get; set; }

        [Display(Name = "Expiration Month")]
        public string ExpirationMonth { get; set; }

        [Display(Name = "Expiration Year")]
        public string ExpirationYear { get; set; }

        public bool SaveInfo { get; set; }
    }
}