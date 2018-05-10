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

        [HttpGet("/Book/Index")]
        public IActionResult Index(string SortBy){
        ViewBag.SortNameParameter = string.IsNullOrEmpty(SortBy) ? "Name desc" : "";
            
        if(SortBy == "Name desc"){
            var books = (from  book in _bookService.GetAllBooks() orderby book.Name descending select book).ToList();
            return View(books);
            }else {
                 var bookss = (from  book in _bookService.GetAllBooks() orderby book.Name ascending select book).ToList(); 
                 return View(bookss);
            }
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

        [HttpGet("/Book/TopRated")]
        public IActionResult TopRated()
        {
            var bookList = _bookService.GetTopRated();

            
            
            return View(bookList);
        }

        }
}
