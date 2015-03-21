using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceSite.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }

        [DisplayName("Category")]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}