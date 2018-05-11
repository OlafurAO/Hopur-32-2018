using System;
using System.Linq;
using System.Collections.Generic;
using BookStore.Data;
using BookStore.Data.EntityModels;
using BookStore.Models;
using BookStore.Models.ViewModels;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class OrderHistoryService
    {
        DataContext _orderHistoryDb;
        OrderListViewModel _orderList;

        public OrderHistoryService()
        {
            _orderHistoryDb = new DataContext();
            _orderList = new OrderListViewModel();
        }

        public void SaveOrder(Order order)
        {
            _orderHistoryDb.AddRange( new OrderHistory { Order = order });
                
            _orderHistoryDb.SaveChanges();
        }

        public List<Order> GetOrderHistory()
        {
            var order = (from a in _orderHistoryDb.Orders
                          select a.Cart);

            Console.WriteLine(order.First().First().Book.Name);
            
            var orders = (from a in _orderHistoryDb.Orders
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