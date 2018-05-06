using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Data.EntityModels;
using BookStore.Services;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private BookService _bookService;

        public CartController()
        {
            _bookService = new BookService();
        }
         public IActionResult AddToCart(int? ID)       
        {
            var book = _bookService.GetAllBooks().Find(x => x.ID == ID);
            Console.WriteLine(book);

            return View(book);
        }
    }
}