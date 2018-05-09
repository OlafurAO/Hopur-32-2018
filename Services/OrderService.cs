using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data;
using BookStore.Data.EntityModels;
using BookStore.Models;
using BookStore.Models.ViewModels;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class OrderService
    {
        DataContext _orderDb;

        public OrderService()
        {
            _orderDb = new DataContext();
        }

        public Order SaveOrder(CartService cs, List<CartListViewModel> cart, string firstName, string lastName, string shippingAddress, string billingAddress, 
        string city, string country, string zipCode)
        {
            var order = new Order{
                        FirstName = firstName,
                        LastName = lastName,
                        ShippingAddress = shippingAddress,
                        BillingAddress = billingAddress,
                        City = city,
                        Total = cs.GetTotalCartPrice(),
                        Country = country,
                        ZipCode = zipCode,
                        OrderDate = DateTime.Now,
                        Cart = cart
            };

            return order;
        }

        public void ConfirmOrder(Order order)
        {
            /*  
            if(order != null)
            {
                order.Cart.All(x => { x.Book.CopiesAvailable--; return true; });
                order.Cart.All(x => { x.Book.CopiesSold++; return true; });
            }

            else
            {
                Console.WriteLine("empty");
            }
             */
            
            _orderDb.Add(order);
            _orderDb.SaveChanges();
        }
    }
}  