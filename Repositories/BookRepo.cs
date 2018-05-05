using System.Collections.Generic;
using System.Linq;
using BookStore.Models.ViewModels;
using BookStore.Data;

namespace BookStore.Repositories
{
    public class BookRepo
    {
        private DataContext _db;

        public BookRepo()
        {
            _db = new DataContext();
        }

        public List<BookListViewModel> GetAllBooks()
        {
           var books = (from a in _db.Books
                        join auth in _db.Authors on a.AuthorID equals auth.ID
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


    }
}