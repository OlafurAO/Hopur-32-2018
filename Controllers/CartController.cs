using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Data.EntityModels;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
         public IActionResult AddToCart(Book book)       
        {
            Console.WriteLine("Hello World!");
            return View();
        }
    }
}