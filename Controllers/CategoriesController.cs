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
        private CategoryService _categoryService;
                public CategoriesController()
        {
            _bookService = new BookService();
            _categoryService = new CategoryService();
        }

        [HttpGet("/Book/FilteredSearch")]
        public IActionResult FilteredSearch()
        {
            var filterd = _categoryService.GetCategories();
            return View(filterd);
        }
        [HttpGet("/Categories/Details")]
        public IActionResult Details(int? ID){
          var categories = _categoryService.Filter(ID);
          Console.WriteLine("ja");
          return View(categories);

        }    

        }
}
