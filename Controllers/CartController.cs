using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Data.EntityModels;
using BookStore.Services;
using BookStore.Data;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private BookService _bookService;

        private Cart _cart;

        private DataContext _db;

        public CartController()
        {
            _bookService = new BookService();
            _cart = new Cart();
            _db = new DataContext();
        }

        [HttpGet("/Cart/AddToCart")]
        public IActionResult AddToCart(int ID)       
        {
           var book = _bookService.GetAllBooks().Find(x => x.ID == ID);
           //var book = _bookService.FindBook(ID);

            _cart._quantity += 1;



            //_db.Add(new Cart.CartContents{Book = book});
            _db.SaveChanges();

            return View(book);
        }

        [HttpGet("/Cart/CartView")]
        public IActionResult CartView()
        {
            
            return View();
        }
    }
}