using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data;
using BookStore.Data.EntityModels;
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

            if(item == null)
            {
                item = new Cart
                {
                    BookID = book.ID,
                    ID = CartID,
                    Quantity = 1,
                };
                _cartDb.Carts.Add(item);
            }

            _cartDb.SaveChanges();
        }

        public List<CartListViewModel> GetCartItems()
        {
            //return _cartDb.Carts.Where(
              //  c => c.ID == CartID).ToList();

            var items = (from a in _cartDb.Carts
                        select new CartListViewModel
                        {
                            ID = a.ID,
                            Book = a.Book,
                            Quantity = a.Quantity
                        }).ToList();

            return items;
        }
    }
}  