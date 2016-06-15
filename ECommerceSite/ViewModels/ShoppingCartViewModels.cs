using ECommerceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceSite.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartProducts { get; set; }
        public decimal CartTotal { get; set; }
    }

    public class ShoppingCartRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ProductCount { get; set; }
        public int DeleteId { get; set; }
    }
}