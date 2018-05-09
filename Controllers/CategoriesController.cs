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
    public class CategoriesController : Controller
    {
        private BookService _bookService;
        private Search _CategoryService;
                public CategoriesController()
        {
            _bookService = new BookService();
            _CategoryService = new Search();
        }

        [HttpGet("/Book/FilteredSearch")]
        public IActionResult FilteredSearch()
        {
            var filterd = _bookService.GetCategories();
            return View(filterd);
        }
        [HttpGet("/Categories/Details")]
        public IActionResult FilteredSearch(int? ID){
          var categories = _CategoryService.Filter(ID);
          Console.WriteLine("ja");
          return View(categories);

        }    

        }
}
