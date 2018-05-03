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
        }
    }
}
