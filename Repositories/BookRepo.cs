using System.Collections.Generic;
using System.Linq;
using BookStore.Models.ViewModels;
using BookStore.Data;
using BookStore.Data.EntityModels;
using System;

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

        public void ChangeCopies(List<CartListViewModel> order)
        {
            if(order != null)
            {
                foreach(var o in order)
                {
                    _db.Books
                    .Where(x => x.ID.Equals(o.Book.ID))
                    .ToList()
                    .ForEach(x => x.CopiesAvailable--);

                    _db.Books
                    .Where(x => x.ID.Equals(o.Book.ID))
                    .ToList()
                    .ForEach(x => x.CopiesSold++);
                }
            } 

            else
            {
                Console.WriteLine("empty");
            }           
        }
    }
}