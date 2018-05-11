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
        BookService _bService;

        public OrderService()
        {
            _orderDb = new DataContext();
            _bService = new BookService();
        }

        public Order SaveOrder(CartService cs, List<CartListViewModel> cart, string firstName, string lastName, string shippingAddress, string billingAddress, 
        string city, string country, string zipCode)
        {
            //Not empty

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

        public void ConfirmOrder(Order orders)
        {
            _orderDb.Orders.Add(orders);
            _bService.ChangeCopies();
            _orderDb.SaveChanges();            
        }

        public List<Order> GetOrderHistory()
        {            
            var orders = (from a in _orderDb.Orders
                          select new Order
                          {
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                ShippingAddress = a.ShippingAddress,
                                BillingAddress = a.BillingAddress,
                                City = a.City,
                                Total = a.Total,
                                Country = a.Country,
                                ZipCode = a.ZipCode,
                                OrderDate = a.OrderDate,
                                Cart = a.Cart
                          }).ToList();

            foreach(var a in orders)
            {
                if(a.Cart == null)
                {
                    Console.WriteLine(a.BillingAddress);
                }
            }

            return orders;
            
        }
    }
}  