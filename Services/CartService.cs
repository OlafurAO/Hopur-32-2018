using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data;
using BookStore.Data.EntityModels;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace BookStore.Services
{
    public class CartService
    {
        DataContext _cartDb;
        public int CartID  { get; set; }
        public string ID;

        public CartService()
        {
            _cartDb = new DataContext();
            ID = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString(); 
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
                    CartID = ID,
                    Quantity = 1,
                };
                _cartDb.AddRange(item);
                _cartDb.SaveChanges();
            }   
        }

        public List<CartListViewModel> GetAllItems()
        {
            var items = (from a in _cartDb.Carts
                        where a.CartID == ID
                        select new CartListViewModel
                        {
                            ID = a.ID,
                            CartID = ID,
                            Book = a.Book,
                            Quantity = a.Quantity
                        }).ToList();

            return items;
        }

        public void RemoveCartItem(int? bookID)
        {
            var removedItem = _cartDb.Carts.First(c => c.CartID == ID
                                                    && c.BookID == bookID);
            
            if(removedItem != null)
            {
                _cartDb.Carts.RemoveRange(removedItem);
                _cartDb.SaveChanges();
            }
        }

        public void ClearCart()
        {
            var remove = (from a in _cartDb.Carts
                          where a.CartID == ID
                          select a).ToList();

            if(remove != null)
            {
                _cartDb.RemoveRange(remove);
                _cartDb.SaveChanges();
            }
        }

        public double GetTotalCartPrice()
        {
            double total = 0;

            foreach(var price in _cartDb.Carts.Where(x => x.CartID == ID))
            {
                total += price.Book.Price;
            }

            return total;
        }

        public int GetNumberOfItems()
        {
            int total = 0;

            foreach(var item in _cartDb.Carts.Where(x => x.CartID == ID))
            {
                total++;
            }

            return total;
        }

        public void Save()
        {
            _cartDb.SaveChanges();
        }
    }
}  