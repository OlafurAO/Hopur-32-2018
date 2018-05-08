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
    public class AuthorController : Controller
    {
        private BookService _bookService;
        private AuthorService _authorService;

        public AuthorController()
        {
            _bookService = new BookService();
            _authorService = new AuthorService();
        }

        [HttpPost("/Author/Details")]
        public IActionResult Details(int? ID)
        {
            Console.WriteLine(ID);
            var books = _authorService.FindBooksByAuthor(ID);

            return View(books);
        }

        
    }
}
