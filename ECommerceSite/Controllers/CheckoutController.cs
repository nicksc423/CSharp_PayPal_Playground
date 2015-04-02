using ECommerceSite.Infrastructure;
using ECommerceSite.Models;
using ECommerceSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSite.Controllers
{
    //[Authorize]
    public class CheckoutController : Controller
    {
        ECommerceSiteDB dbContext = new ECommerceSiteDB();
        const string PromoCode = "FREE";

        //
        // GET: Checkout
        public ActionResult AddressAndPayment()
        {
            ViewBag.Months = new List<SelectListItem>() { 
                new SelectListItem() { Text="Jan", Value="01" },
                new SelectListItem() { Text="Feb", Value="02" },
                new SelectListItem() { Text="Mar", Value="03" },
                new SelectListItem() { Text="Apr", Value="04" },
                new SelectListItem() { Text="May", Value="05" },
                new SelectListItem() { Text="Jun", Value="06" },
                new SelectListItem() { Text="Jul", Value="07" },
                new SelectListItem() { Text="Aug", Value="08" },
                new SelectListItem() { Text="Sep", Value="09" },
                new SelectListItem() { Text="Oct", Value="10" },
                new SelectListItem() { Text="Nov", Value="11" },
                new SelectListItem() { Text="Dec", Value="12" },
            };

            ViewBag.Years = new SelectList(Enumerable.Range(DateTime.Today.Year, 15));

            ViewBag.CreditCardTypes = new List<SelectListItem>() {
                new SelectListItem() { Text="Visa", Value="visa" },
                new SelectListItem() { Text="Mastercard", Value="mastercard" },
                new SelectListItem() { Text="Discover", Value="discover" },
                new SelectListItem() { Text="American Express", Value="amex" },
            };

            return View(new OrderViewModel());
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(OrderViewModel orderViewModel)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;

                //Save Order
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
                //Process the order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(order);

                return RedirectToAction("Complete", new { id = order.OrderId });

            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }
    }
}