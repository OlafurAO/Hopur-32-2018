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

            
                var initialBooks = new List<Book>()
                {
                    new Book {Name = "The Lord of The Rings", Author = "J.R.R. Tolkien", AuthorID = 1,  Category = "Fantasy", YearPublished = "1939", Price = 19.99},
                    new Book {Name = "Art of War", Author = "Sun Tzu", AuthorID = 5,  Category = "Philosophy", YearPublished = "Chinese times", Price = 9.99},
                };

                db.AddRange(initialBooks);
                db.SaveChanges();

            
  
            
        }
    }
}
