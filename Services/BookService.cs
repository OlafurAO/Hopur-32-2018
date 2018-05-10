using System;
using System.Collections.Generic;
using BookStore.Data.EntityModels;
using BookStore.Models.ViewModels;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class BookService
    {
        private BookRepo _bookRepo;
        private CategoryRepo _categoriesrepo;

        public BookService()
        {
            _bookRepo = new BookRepo();
            _categoriesrepo = new CategoryRepo();
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

        public List<BookListViewModel> GetTopRated()
        {
            return _bookRepo.GetTopRated();
        }

        public List<CategoryListViewModel> GetCategories(){
            return _categoriesrepo.GetAllCategories();
        }

        public void AddRating(int? ID, double Rating)
        {
            _bookRepo.AddRating(ID, Rating);
        }

        public void ChangeCopies(List<CartListViewModel> cart)
        {
            _bookRepo.ChangeCopies(cart);
        }
    }
}  