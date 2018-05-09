using System;
using System.Collections.Generic;
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
        string streetName, string houseNumber, string city, string country, string zipCode)
        {
            Console.WriteLine("working");

            var order = new Order{
                        FirstName = firstName,
                        LastName = lastName,
                        Address = shippingAddress,
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
            _orderDb.Orders.Add(order);
            _orderDb.SaveChanges();
        }

       /* public Order GetOrder()
        {
            
        }*/

    }
}  