using System.Collections.Generic;
using BookStore.Data.EntityModels;
using BookStore.Models.ViewModels;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class BookService
    {
        private BookRepo _bookRepo;

        public BookService()
        {
            _bookRepo = new BookRepo();
        }

        public List<BookListViewModel> GetAllBooks()
        {
            var books = _bookRepo.GetAllBooks();
            return books;
        }

        public List<BookListViewModel> SearchBooks(string searchString)
        {
            return _bookRepo.SearchBooks(searchString);
        }

/*        public Book FindBook(int ID)
        {
            return _bookRepo.FindBook(ID);
        }
*/
    }
}  