using System.Collections.Generic;
using System.Linq;
using BookStore.Models.ViewModels;
using BookStore.Data;
using System;

namespace BookStore.Repositories
{
    public class CategoryRepo
    {
        private DataContext _db;
        public CategoryRepo()
        {
            _db = new DataContext();
        }
        public List<CategoryListViewModel> GetAllCategories()
        {
           var categories = (from a in _db.Categories
                         select new CategoryListViewModel
                         {
                             Id = a.ID,
                             Name = a.Name
                         }).ToList();

            return categories;
        }
        public List<BookListViewModel> FindBooksByCategory(int? id)
        {
            var books = (from a in _db.Books 
                         join b in _db.Categories on id equals b.ID
                         where a.Category == b.Name
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