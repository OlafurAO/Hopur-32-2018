using System.Collections.Generic;
using BookStore.Models.ViewModels;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class AuthorService
    {
        private AuthorRepo _authorRepo;

        public AuthorService()
        {
            _authorRepo = new AuthorRepo();
        }

        public List<AuthorListViewModel> GetAllAuthors()
        {
            var authors = _authorRepo.GetAllAuthors();
            return authors;
        }
    }
}