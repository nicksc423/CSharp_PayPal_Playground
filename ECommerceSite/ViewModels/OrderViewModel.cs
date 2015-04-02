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

        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public string Country { get; set; }

        [Display(Name = "Credit Card")]
        [NotMapped]
        [Required]
        [CreditCard]
        public String CreditCardNumber { get; set; }

        [Display(Name = "Credit Card Type")]
        [NotMapped]
        public String CcType { get; set; }

        [Display(Name = "Expiration Month")]
        [NotMapped]
        public String ExpirationMonth { get; set; }

        [Display(Name = "Expiration Year")]
        [NotMapped]
        public string ExpirationYear { get; set; }

        [NotMapped]
        public bool SaveInfo { get; set; }
    }
}