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
    }
}