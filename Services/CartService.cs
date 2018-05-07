using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data;
using BookStore.Models.ViewModels;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class CartService
    {
        DataContext _cartDb;
        public int CartID  { get; set; }
        public CartService()
        {
            _cartDb = new DataContext();
        }

        public void AddToCart(BookListViewModel book)
        {
            var item = _cartDb.Carts.SingleOrDefault(
                                     c => c.ID == CartID
                                     && c.BookID == book.ID);

            Console.WriteLine(item.BookID);
        }
    }
}  