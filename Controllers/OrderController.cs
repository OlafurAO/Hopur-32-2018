using System;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        CartService _cart;
        OrderService _order;
        OrderHistoryService _orderHistory;

        public OrderController()
        {
            _cart = new CartService();
            _order = new OrderService();
            _orderHistory = new OrderHistoryService();
        }

        [HttpGet("/Order/UserInfo")]
        public IActionResult UserInfo(int? ID)
        {
            var cartContents = _cart.GetAllItems();

            return View(cartContents);
        }

        [HttpGet("/Order/Review")]
        public IActionResult Review(string FirstName, string LastName, string ShippingAddress, string BillingAddress, 
        string City, string Country, string ZipCode)
        {
            var cartContents = _cart.GetAllItems();

            var order = _order.SaveOrder(_cart, cartContents, FirstName, LastName, ShippingAddress, 
                                        BillingAddress, City, Country, ZipCode);

            return View(order);
        }

        [HttpGet("/Order/ConfirmOrder")]
        public IActionResult ConfirmOrder(Order order)
        {
            order.Cart = _cart.GetAllItems();
            _cart.Save();
            
            _order.ConfirmOrder(order);
            _cart.ClearCart();
            
            return View();
        }

        [HttpGet("/Order/History")]
        public IActionResult GetOrderHistory()
        {
            var orders = _order.GetOrderHistory();

            return View(orders);
        }
    }
}