//https://github.com/OlafurAO/Hopur-32-2018

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using BookStore.Data.EntityModels;
using BookStore.Data;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {   var host = BuildWebHost(args);
            SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void SeedData()
        {
            var db = new DataContext();

            if(!db.Authors.Any())
            {
                var initialAuthors = new List<Author>()
                {
                    new Author {Name = "J.R.R. Tolkien"},
                    new Author {Name = "George R.R Martin"},
                    new Author {Name = "J.K Rowling"},
                    new Author {Name = "Stephen King"},
                    new Author {Name = "Sun Tzu"},
                    new Author {Name = "Terry Pratchet"}
                };

                db.AddRange(initialAuthors);
                db.SaveChanges();
            }

            if(!db.Books.Any())
            {            
                var initialBooks = new List<Book>()
                {
                    new Book {Name = "The Hobbit", Author = "J.R.R. Tolkien", AuthorID = 1,  Category = "Fantasy", YearPublished = "1937", Price = 19.99, Rating = 4.7, CopiesAvailable = 107, CopiesSold = 320},
                    new Book {Name = "Art of War", Author = "Sun Tzu", AuthorID = 5,  Category = "Philosophy", YearPublished = "500 BC", Price = 9.99, Rating = 4.7, CopiesAvailable = 107, CopiesSold = 320},
                    new Book {Name = "The Colour of Magic", Author = "Terry Pratchet", AuthorID = 6,  Category = "Fantasy", YearPublished = "1984", Price = 19.99, Rating = 4.6, CopiesAvailable = 200, CopiesSold = 150},
                    new Book {Name = "The Great Gatsby", Author = "F. Scott Fitzgerald", AuthorID = 7,  Category = "Romance", YearPublished = "1925", Price = 9.99, Rating = 3.6, CopiesAvailable = 200, CopiesSold = 150},
                };

                db.AddRange(initialBooks);
                db.SaveChanges();   
            }
        }
    }
}
