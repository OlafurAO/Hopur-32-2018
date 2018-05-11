using System.Collections.Generic;
using System.Linq;
using BookStore.Models.ViewModels;
using BookStore.Data;
using BookStore.Data.EntityModels;
using System;
using BookStore.Services;

namespace BookStore.Repositories
{
    public class BookRepo
    {
        private DataContext _db;
        private CartService _cs;

        public BookRepo()
        {
            _db = new DataContext();
            _cs = new CartService();
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

        public List<BookListViewModel> SearchBooks(string searchString)
        {
        
            var books = (from a in _db.Books
                        where a.Name.Contains(searchString)
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

        public List<BookListViewModel> GetTopRated()
        {
            var books = (from a in _db.Books
                        orderby a.Rating descending
                        join auth in _db.Authors on a.AuthorID equals auth.ID 
                        join cat in _db.Categories on a.Category equals cat.Name
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
                        }).Take(10).ToList();

            return books;
        }

        public void AddRating(int? ID, double Rating)
        {
            _db.Books
            .Where(x => x.ID.Equals(ID))
            .ToList()
            .ForEach(x => x.Rating += (Rating - x.Rating) * 5/(x.CopiesSold + 1));

            _db.SaveChanges();
        }

        public void ChangeCopies()
        {           
            var cartItems = (from a in _db.Carts
                             where _cs.ID == a.CartID
                             select a.BookID).ToList();

            foreach(var item in cartItems)
            {
                Console.WriteLine(item);
                _db.Books
                .Where(x => x.ID.Equals(item))
                .ToList()
                .ForEach(x => x.CopiesAvailable -= 1);

                _db.Books
                .Where(x => x.ID.Equals(item))
                .ToList()
                .ForEach(x => x.CopiesSold += 1);
            }
            _db.SaveChanges();
        }
    }
}