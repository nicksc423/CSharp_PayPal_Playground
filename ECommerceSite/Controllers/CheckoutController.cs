using ECommerceSite.Helpers;
using ECommerceSite.Infrastructure;
using ECommerceSite.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceSite.Models;
using ECommerceSite.Configuration;

namespace ECommerceSite.Controllers
{
    //[Authorize]
    public class CheckoutController : Controller
    {
        ECommerceSiteDB dbContext = new ECommerceSiteDB();
        //const string PromoCode = "FREE";

        //
        // GET: Checkout
        public ActionResult AddressAndPayment()
        {
            ViewBag.Months = PayPalHelper.Months;

            ViewBag.Years = PayPalHelper.Years;

            ViewBag.CreditCardTypes = PayPalHelper.CreditCardTypes;

            ViewBag.Countries = PayPalHelper.Countries;

            return View(new OrderViewModel());
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(OrderViewModel orderViewModel)
        {

            if(!ModelState.IsValid)
            {
                ViewBag.Months = PayPalHelper.Months;

                ViewBag.Years = PayPalHelper.Years;

                ViewBag.CreditCardTypes = PayPalHelper.CreditCardTypes;

                ViewBag.Countries = PayPalHelper.Countries;

                return View(orderViewModel);
            }

            try
            {
                //create the order to store information in our database
                var cart = ShoppingCart.GetCart(this.HttpContext);
                Order order = new Order();
                decimal orderTotal = 0;
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;
                order.OrderDetails = new List<OrderDetail>();

                var cartProducts = cart.GetCartProducts();
                // Iterate over the products in the cart, 
                // adding the order details for each
                foreach (var product in cartProducts)
                {
                    var orderDetail = new OrderDetail
                    {
                        ProductId = product.ProductId,
                        OrderId = order.OrderId,
                        UnitPrice = product.Product.Price,
                        Quantity = product.Count
                    };
                    // Set the order total of the shopping cart
                    orderTotal += (product.Count * product.Product.Price);
                    order.OrderDetails.Add(orderDetail);
                }
                // Set the order's total to the orderTotal count
                order.Total = orderTotal;

                //add everything to the DB
                dbContext.Orders.Add(order);
                dbContext.OrderDetails.AddRange(order.OrderDetails);

                //proccess to paypal
                List<PayPal.Api.Item> items = new List<PayPal.Api.Item>();
                foreach(OrderDetail orderDetail in order.OrderDetails)
                {
                    PayPal.Api.Item item = new PayPal.Api.Item();
                    item.name = dbContext.Products.Single(p => p.ProductId == orderDetail.ProductId).Name;
                    item.currency = "USD";
                    item.price = orderDetail.UnitPrice.ToString();
                    item.quantity = orderDetail.Quantity.ToString();
                    item.sku = orderDetail.ProductId.ToString();

                    items.Add(item);
                }
                PayPal.Api.ItemList itemList = new PayPal.Api.ItemList();
                itemList.items = items;

                PayPal.Api.Address address = new PayPal.Api.Address();
                address.city = orderViewModel.City;
                address.country_code = orderViewModel.Country;
                address.line1 = orderViewModel.Address;
                address.postal_code = orderViewModel.PostalCode.ToString();
                address.state = orderViewModel.State;

                PayPal.Api.CreditCard creditCard = new PayPal.Api.CreditCard();
                creditCard.billing_address = address;
                creditCard.cvv2 = orderViewModel.CSC.ToString();
                creditCard.expire_month = Int32.Parse(orderViewModel.ExpirationMonth);
                creditCard.expire_year = Int32.Parse(orderViewModel.ExpirationYear);
                creditCard.first_name = orderViewModel.FirstName;
                creditCard.last_name = orderViewModel.LastName;
                creditCard.number = orderViewModel.CreditCardNumber;
                creditCard.type = orderViewModel.CcType;

                PayPal.Api.Details details = new PayPal.Api.Details();
                details.shipping = "1";
                details.subtotal = order.Total.ToString();
                details.tax = "1";
                
                PayPal.Api.Amount amount = new PayPal.Api.Amount();
                amount.currency = "USD";
                amount.total = (order.Total + 2).ToString();
                amount.details = details;

                PayPal.Api.Transaction transaction = new PayPal.Api.Transaction();
                transaction.amount = amount;
                transaction.description = "Description goes here";
                transaction.item_list = itemList;
                transaction.invoice_number = order.OrderId.ToString();

                List<PayPal.Api.Transaction> transactionList = new List<PayPal.Api.Transaction>();
                transactionList.Add(transaction);

                PayPal.Api.FundingInstrument fundInstrument = new PayPal.Api.FundingInstrument();
                fundInstrument.credit_card = creditCard;

                List<PayPal.Api.FundingInstrument> fundingList = new List<PayPal.Api.FundingInstrument>();
                fundingList.Add(fundInstrument);

                PayPal.Api.Payer payer = new PayPal.Api.Payer();
                payer.funding_instruments = fundingList;
                payer.payment_method = "credit_card";

                PayPal.Api.Payment payment = new PayPal.Api.Payment();
                payment.intent = "sale";
                payment.payer = payer;
                payment.transactions = transactionList;

                try
                {
                    //getting context from the paypal
                    //basically we are sending the clientID and clientSecret key in this function
                    //to the get the context from the paypal API to make the payment
                    //for which we have created the object above.

                    //Basically, apiContext object has a accesstoken which is sent by the paypal
                    //to authenticate the payment to facilitator account.
                    //An access token could be an alphanumeric string

                    PayPal.Api.APIContext apiContext = PayPalConfig.GetAPIContext();

                    //Create is a Payment class function which actually sends the payment details
                    //to the paypal API for the payment. The function is passed with the ApiContext
                    //which we received above.

                    PayPal.Api.Payment createdPayment = payment.Create(apiContext);

                    //if the createdPayment.state is "approved" it means the payment was successful else not

                    if (createdPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
                catch (PayPal.PayPalException ex)
                {
                    //Logger.Log("Error: " + ex.Message);
                    return View("FailureView");
                }


                cart.EmptyCart();
                return RedirectToAction("Complete", new { id = order.OrderId });

            }
            catch(Exception ex)
            {
                //Invalid - redisplay with errors
                //return View(order);
            }
            return View();
        }

        [HttpGet]
        public string GetUsStateCodes()
        {
            return PayPalHelper.getUsStates();
        }

        [HttpGet]
        public string GetCaStateCodes()
        {
            return PayPalHelper.getCaStates();
        }

        private void processPayPal()
        {

        }
    }
}