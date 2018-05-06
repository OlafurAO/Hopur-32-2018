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
    [Authorize]
    public class HomeController : Controller
    {
        private AuthorService _authorService;
        private BookService _bookService;

        public HomeController()
        {
            _authorService = new AuthorService();
            _bookService = new BookService();
        }

        public IActionResult Index()
        {
            //var authors = _authorService.GetAllAuthors();
            var books = _bookService.GetAllBooks();

            return View(books);
        }        
    }
}
