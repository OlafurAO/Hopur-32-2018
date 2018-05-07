using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;

        public BookController()
        {
            _bookService = new BookService();
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();

            return View(books);
        }

        [HttpGet("/Book/Details")]
        public IActionResult Details(int? ID)
        {
            var book = _bookService.GetAllBooks().Find(x => x.ID == ID);

            Console.WriteLine("book controller working");

            return View(book);
        } 


        [HttpGet("/Book/Search")]
        public IActionResult Search(string searchString)
        {
            if(string.IsNullOrEmpty(searchString))
            {
                Console.WriteLine("empty string!");
            }

            var bookList = _bookService.SearchBooks(searchString);
            return View(bookList);
        }
    }
}
