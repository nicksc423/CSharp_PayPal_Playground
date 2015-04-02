﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSite.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {

        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Address line 1")]
        [StringLength(70)]
        public string AddressLine1 { get; set; }

        [StringLength(70)]
        [DisplayName("Address line 2")]
        public string AddressLine2 { get; set; }

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

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public string Phone { get; set; }

        [Display(Name = "Credit Card Number")]
        [NotMapped]
        [Required]
        [DataType(DataType.CreditCard)]
        public String CreditCardNumber { get; set; }

        [Display(Name = "CSC")]
        [NotMapped]
        [Required]
        [StringLength(3)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "CSC is is not valid.")]
        public String csc { get; set; }

        [Display(Name = "Experation Date")]
        [NotMapped]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Experation { get; set; }


        [Display(Name = "Credit Card Type")]
        [NotMapped]
        public String CcType { get; set; }

        public bool SaveInfo { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public PayPal.Api.CreditCard creditCard { get; set; }
    }
}