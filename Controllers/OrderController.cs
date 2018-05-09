using System;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        CartService _cart;
        OrderService _order;

        public OrderController()
        {
            _cart = new CartService();
            _order = new OrderService();
        }

        [HttpGet("/Order/UserInfo")]
        public IActionResult UserInfo(int? ID)
        {
            var cartContents = _cart.GetAllItems();
            return View(cartContents);
        }

        [HttpGet("/Order/Review")]
        public IActionResult Review(string FirstName, string LastName, string ShippingAddress, string BillingAddress, 
        string StreetName, string HouseNumber, string City, string Country, string ZipCode)
        {
            var cartContents = _cart.GetAllItems();

            var order = _order.SaveOrder(_cart, cartContents, FirstName, LastName, ShippingAddress, 
                                        BillingAddress, StreetName, HouseNumber, City, Country, ZipCode);

            return View(order);
        }

        [HttpGet("/Order/ConfirmOrder")]
        public IActionResult ConfirmOrder(Order order)
        {
            //send email

            _order.ConfirmOrder(order);
            _cart.ClearCart();
            return View();
        }
    }
}