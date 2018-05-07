using System.Collections.Generic;
using System.Linq;
using BookStore.Models.ViewModels;
using BookStore.Data;

namespace BookStore.Repositories
{
    public class CartRepo
    {
        private DataContext _db;

        public CartRepo()
        {
            _db = new DataContext();
        }

        public List<CartListViewModel.CartContents> GetAllCartContents()
        {
            var contents = (from a in _db.Cart
                            select new CartListViewModel.CartContents
                            {
                                ID = a.ID,
                                Book = a.Book

                            }).ToList();
            return contents;
        }
    }
}
