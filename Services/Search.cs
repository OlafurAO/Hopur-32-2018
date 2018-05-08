using System.Collections.Generic;
using System.Linq;
using BookStore.Models.ViewModels;
using BookStore.Data;
using BookStore.Repositories;

namespace BookStore.Services
{
  public class Search
  {

        private DataContext _db;

    public Search() => _db = new DataContext();
    public List<BookListViewModel> Filter()
        {
            string category = "Fantasy"; 
              var books = (from a in _db.Books
               where a.Category == category
                        select new BookListViewModel
                         {
                             ID = a.ID,
                             Name = a.Name,
                             Author = a.Author,
                             AuthorID = a.AuthorID,
                             Category = a.Category,
                             YearPublished = a.YearPublished,
                             Price = a.Price,
                             Rating = a.Rating,
                             CopiesAvailable = a.CopiesAvailable,
                             CopiesSold = a.CopiesSold
                         }).ToList();
             return books;
             }
    public static List<string> GetCategories(){
        List<string> categories = new List<string>();
            categories.Add("Fantasy");
            categories.Add("Philosofy");
            return categories;
    }
    }

}