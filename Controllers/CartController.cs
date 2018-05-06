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
        private int _cartQuantity;
        private BookService _bookService;

        private DataContext _db;

        public CartController()
        {
            _bookService = new BookService();
            _cartQuantity = 0;
            _db = new DataContext();
        }

        [HttpGet("/Cart/AddToCart")]
         public IActionResult AddToCart(int? ID)       
        {
            var book = _bookService.GetAllBooks().Find(x => x.ID == ID);

            book.CopiesAvailable -= 1;
            _cartQuantity += 1;
            _db.SaveChanges();

            return View(book);
        }
    }
}