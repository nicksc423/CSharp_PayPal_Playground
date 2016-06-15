using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceSite.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [StringLength(70)]
        [Required]
        public string Line1 { get; set; }

        [StringLength(70)]
        public string Line2 { get; set; }

        [StringLength(40)]
        [Required]
        public string City { get; set; }

        [StringLength(2)]
        [Required]
        public string State { get; set; }

        [StringLength(9)]
        [Required]
        public string PostalCode { get; set; }

        [StringLength(2)]
        [Required]
        public string Country { get; set; }
    }
}