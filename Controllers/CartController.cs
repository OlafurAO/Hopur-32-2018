using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Data.EntityModels;
using BookStore.Services;
using BookStore.Data;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private BookService _bookService;

        private CartService _cartService;

        private DataContext _db;

        public CartController()
        {
            _bookService = new BookService();
            _cartService = new CartService();
            _db = new DataContext();
        }

        [HttpGet("/Cart/AddToCart")]
        public IActionResult AddToCart(int ID)       
        {
            var book = _bookService.GetAllBooks().Find(x => x.ID == ID);
            _cartService.AddToCart(book);
                        
            //_db.SaveChanges();
            return View(book);
        }

        [HttpGet("/Cart/CartView")]
        public IActionResult CartView()
        {
            var items = _cartService.GetAllItems();

            if(items == null)
            {
                Console.WriteLine("Empty Cart");
            }

            return View(items);
        }

        [HttpGet("/Cart/RemoveCartItem")]
        public IActionResult RemoveCartItem(int? ID)
        {                       
            _cartService.RemoveCartItem(ID);
            return View();
        }
    }
}