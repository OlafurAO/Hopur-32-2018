using System.Collections.Generic;
using BookStore.Models.ViewModels;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class CartService
    {
        private CartRepo _cartRepo;


        public CartService()
        {
            _cartRepo = new CartRepo();

        }

        public List<CartListViewModel.CartContents> GetAllCartContents()
        {
            var contents = _cartRepo.GetAllCartContents();
            return contents;
        }
    }
}  