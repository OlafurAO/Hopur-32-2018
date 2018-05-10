using System.Collections.Generic;
using System.Linq;
using BookStore.Models.ViewModels;
using BookStore.Data;


namespace BookStore.Repositories
{
    public class AuthorRepo
    {
        private DataContext _db;

        public AuthorRepo()
        {
            _db = new DataContext();
        }
        
        public List<AuthorListViewModel> GetAllAuthors()
        {
           var authors = (from a in _db.Authors
                         select new AuthorListViewModel
                         {
                             ID = a.ID,
                             Name = a.Name
                         }).ToList();

            return authors;
        }

        public List<BookListViewModel> FindBooksByAuthor(int? ID)
        {
            var books = (from b in _db.Books
                         join a in _db.Authors on ID equals a.ID
                         where b.AuthorID == ID
                         select new BookListViewModel
                         {
                            ID = b.ID,
                            Name = b.Name,
                            Author = b.Author,
                            AuthorID = b.AuthorID,
                            Category = b.Category,
                            YearPublished = b.YearPublished,
                            Price = b.Price,
                            Rating = b.Rating,
                            CopiesAvailable = b.CopiesAvailable,
                            CopiesSold = b.CopiesSold
                         }).ToList();

            return books;
        }
    }
}