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
            var books = _bookService.GetAllBooks();

            return View(books);
        }

        [HttpGet("/AboutUs/")]
        public IActionResult About()
        {
            return View("~/Views/AboutUs/About.cshtml");
        }

        [HttpGet("/AboutUs/Employees")]
        public IActionResult Employees()
        {
            return View("~/Views/AboutUs/Employees.cshtml");
        }

        [HttpGet("/AboutUs/Jobs")]
        public IActionResult Jobs()
        {
            return View("~/Views/AboutUs/Jobs.cshtml");
        }

        [HttpGet("/AboutUs/Terms")]
        public IActionResult Terms()
        {
            return View("~/Views/AboutUs/Terms.cshtml");
        }

        [HttpGet("/Support/FAQ")]
        public IActionResult FAQ()
        {
            return View("~/Views/Support/FAQ.cshtml");
        }






            
    }
}
