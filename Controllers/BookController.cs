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
        private CommentService _commentService;

        public BookController()
        {
            _bookService = new BookService();
            _commentService = new CommentService();
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

        [HttpGet("/Book/GetComments")]
        public IActionResult GetComments(int? ID)
        {
            var comments = _commentService.GetComments(ID);
            return View(comments);
        }

        [HttpGet("/Book/CommentPage")]
        public IActionResult CommentPage(int? ID)
        {
            return View(ID);
        }

        [HttpGet("/Book/AddComment")]
        public IActionResult AddComment(string Name, string CommentBody, int ID)
        {
            Console.WriteLine(ID);
            _commentService.AddComment(ID, Name, CommentBody);
            return View(ID);
        }

        [HttpGet("/Book/Rate")]
        public IActionResult Rate(int? ID)
        {
            _bookService.AddRating(ID);
            return View();
        }

        //[Authorize]

    }
}
