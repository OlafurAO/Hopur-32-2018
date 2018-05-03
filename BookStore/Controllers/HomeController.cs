using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Services;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private AuthorService _authorService;

        public HomeController()
        {
            _authorService = new AuthorService();
        }

        public IActionResult Index()
        {
            var authors = _authorService.GetAllAuthors();

            return View(authors);
        }

        
    }
}
